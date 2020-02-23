using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConvertDBKeyToID.Models;
using Dapper;
using MiniProfiler.Integrations;
using System.Threading;

namespace ConvertDBKeyToID.DB
{
  public class DbUtils
  {
    public static CustomDbProfiler profiler = CustomDbProfiler.Current;
    public delegate void logDelegate(string logText);
    public static event logDelegate OnLog;


    public static string conStr = "Data Source=.;Initial Catalog=V@LID49_LAT;User id = sa; password = password123!";
    public static string qAllColumns = @"SELECT sc.TABLE_SCHEMA +'.'+sc.TABLE_NAME AS TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS sc 
                                        INNER JOIN INFORMATION_SCHEMA.TABLES tb on tb.TABLE_SCHEMA = sc.TABLE_SCHEMA and tb.TABLE_NAME = sc.TABLE_NAME
                                        WHERE sc.TABLE_NAME NOT LIKE 'SYS%' and tb.TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME, ORDINAL_POSITION";
    public static string qContraints = @"SELECT tc.TABLE_SCHEMA+'.'+tc.TABLE_NAME as TABLE_NAME, tc.CONSTRAINT_NAME , ccu.COLUMN_NAME, tc.CONSTRAINT_TYPE
                                          FROM
                                              INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc
                                              JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS ccu ON ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME
                                          WHERE
                                              (TC.CONSTRAINT_TYPE = 'UNIQUE' OR TC.CONSTRAINT_TYPE = 'PRIMARY KEY') AND TC.TABLE_NAME NOT LIKE 'sys%'
                                          ORDER BY TABLE_NAME, CONSTRAINT_NAME";

    public static string qRel = @"SELECT fk.name 'FKName', sc.name+'.'+ tp.name as 'Table', cp.name TableCol, sc.name+'.'+tr.name as ReferencedTable, cr.name ReferencedTableCol
                            FROM sys.foreign_keys fk
                            INNER JOIN sys.tables tp ON fk.parent_object_id = tp.object_id
                            INNER JOIN sys.tables tr ON fk.referenced_object_id = tr.object_id
							              INNER JOIN sys.schemas sc on tr.schema_id = sc.schema_id
                            INNER JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
                            INNER JOIN sys.columns cp ON fkc.parent_column_id = cp.column_id AND fkc.parent_object_id = cp.object_id
                            INNER JOIN sys.columns cr ON fkc.referenced_column_id = cr.column_id AND fkc.referenced_object_id = cr.object_id
                            ORDER BY tp.name, cp.column_id";


    public static IDbConnection GetConnection()
    {
      var factory = new SqlServerDbConnectionFactory(conStr);
      var conn = DbConnectionFactoryHelper.New(factory, profiler);
      return conn;
    }

    private static void LogLatestSqlCommand()
    {
      Log(profiler.ProfilerContext.ExecutedCommands.Last());
      //Log(profiler.ProfilerContext.FailedCommands.Last());
    }

    private static void LogLatestSqlCommandFailed()
    {
      //Log(profiler.ProfilerContext.ExecutedCommands.Last());
      Log(profiler.ProfilerContext.FailedCommands.Last());
    }

    private static void Log(string logText)
    {
      if (OnLog != null)
      {
        OnLog(logText);
        Thread.Yield();
      }
    }

    public static void ConvertKeyToID(IDbConnection con, IDbTransaction tran)
    {
      var tbls = new List<Table>();
      var rels = new List<Relationship>(); //tb.Relationships;

      con.Execute("EXEC sp_changedbowner 'sa'", null, tran, 60);
      LogLatestSqlCommand();
      con.Execute("ALTER AUTHORIZATION ON SCHEMA::SIE TO db_owner", null, tran, 60);
      LogLatestSqlCommand();
      // Rename Column ID in 'JURNAL_ROLE'
      try
      {
        con.Execute("exec sp_RENAME 'JURNAL_ROLE.ID', 'IDJR', 'COLUMN'", null, tran, 60);
        LogLatestSqlCommand();
      }
      catch
      {
        Log("JURNAL_ROLE.ID already renamed to JURNAL_ROLE.IDJR");
        LogLatestSqlCommandFailed();
      }

      IEnumerable<dynamic> cols = con.Query<dynamic>(qAllColumns, null, tran).ToList();
      LogLatestSqlCommand();
      foreach (var col in cols)
      {
        var f = col as IDictionary<string, object>;
        var tbName = f["TABLE_NAME"].ToString();
        var colName = f["COLUMN_NAME"].ToString();
        var tb = tbls.Find(i => i.Name == tbName);
        if (tb == null)
        {
          tb = new Table();
          tb.Name = tbName;
          tbls.Add(tb);
        }
        var c = tb.Cols.Find(i => i == colName);
        if (c == null)
        {
          tb.Cols.Add(colName);
        }
      }


      IEnumerable<dynamic> constraints = con.Query<dynamic>(qContraints, null, tran).ToList();
      LogLatestSqlCommand();

      foreach (var r in constraints)
      {
        var f = r as IDictionary<string, object>;
        var tbName = f["TABLE_NAME"].ToString();
        var consName = f["CONSTRAINT_NAME"].ToString();
        var colName = f["COLUMN_NAME"].ToString();
        var consType = f["CONSTRAINT_TYPE"].ToString();
        var tb = tbls.Find(i => i.Name == tbName);
        var constraint = tb.Constraints.Find(i => i.Name == consName);
        if (constraint == null)
        {
          constraint = new Constrain();
          constraint.Name = consName;
          constraint.Type = consType;
          tb.Constraints.Add(constraint);
        }
        if (!constraint.Cols.Contains(colName))
        {
          constraint.Cols.Add(colName);
        }
      }


      foreach (var tb in tbls)
      {

        // find id column and add if not found
        if (tb.Cols.Find(i => i.ToUpper() == "ID") == null)
        {
          try
          {
            con.Execute(string.Format("ALTER TABLE {0} ADD [ID] bigint IDENTITY(1,1)", Qualify(tb.Name)), null, tran);
            LogLatestSqlCommand();
            tb.Cols.Add("ID");
            tb.isIDColExist = true;
          }
          catch (Exception ex)
          {
            Log("Failed to Add ID Col " );
            LogLatestSqlCommandFailed();
          }
        }


        // find PK and check if column name == ID
        var pk = tb.Constraints.Find(i => i.Type == "PRIMARY KEY");
        if ((pk != null && pk.Cols.Count == 1 && pk.Cols[0].ToUpper() == "ID"))
        {
          tb.isIDColPK = true;
        }
      }

      // collect relationship
      IEnumerable<dynamic> relq = con.Query<dynamic>(qRel, null, tran).ToList();
      LogLatestSqlCommand();

      foreach (var r in relq)
      {
        var f = r as IDictionary<string, object>;
        var FKName = f["FKName"].ToString();
        var Table = f["Table"].ToString();
        var TableCol = f["TableCol"].ToString();
        var ReferencedTable = f["ReferencedTable"].ToString();
        var ReferencedTableCol = f["ReferencedTableCol"].ToString();

        var rel = rels.Find(i => i.FKName == FKName);
        if (rel == null)
        {
          rel = new Relationship();
          rel.FKName = FKName;
          rel.Table = Table;
          rel.RefrencedTable = ReferencedTable;
          rels.Add(rel);
        }
        if (!rel.TableCols.Contains(TableCol))
        {
          rel.TableCols.Add(TableCol);
        }
        if (!rel.RefrencedTableCols.Contains(ReferencedTableCol))
        {
          rel.RefrencedTableCols.Add(ReferencedTableCol);
        }
      }


      // drop relationship
      foreach (var rel in rels)
      {
        string dropRel1 = string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", Qualify(rel.Table), rel.FKName);
        try
        {
          int result = con.Execute(dropRel1, null, tran, 60);
          rel.NeedRebuild = true;
          LogLatestSqlCommand();
        }
        catch (Exception ex)
        {
          Log("Failed to Drop FK ");
          LogLatestSqlCommandFailed();
        }
      }

      foreach (var tb in tbls)
      {
        if (!tb.isIDColPK)
        {
          var pk = tb.Constraints.Find(i => i.Type == "PRIMARY KEY");
          if (pk != null)
          {
            // 1. Add AK
            string addAK = string.Format("ALTER TABLE {0} ADD CONSTRAINT AK_{1} UNIQUE (", Qualify(tb.Name), pk.Name);
            foreach (string s in pk.Cols)
            {
              addAK += s + ",";
            }
            addAK = addAK.Substring(0, addAK.Length - 1) + ")";
            try
            {
              con.Execute(addAK, null, tran, 60);
              LogLatestSqlCommand();
            }
            catch (Exception ex) 
            {
              Log("Failed to addi AK " );
              LogLatestSqlCommandFailed();
            }

            // Drop old Primary Key
            string dropPK = string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", Qualify(tb.Name), pk.Name);
            try
            {
              con.Execute(dropPK, null, tran, 60);
              LogLatestSqlCommand();
            }
            catch (Exception ex)
            {
              Log("Failed to drop FK constraint ");
              LogLatestSqlCommandFailed();
            }
          }

          // make ID primary Key
          string addPK = string.Format("ALTER TABLE {0} ADD CONSTRAINT PK_{1} PRIMARY KEY CLUSTERED ([ID])", Qualify(tb.Name), tb.Name.Replace(".", ""));
          try
          {
            con.Execute(addPK, null, tran, 60);
            tb.isIDColPK = true;
            LogLatestSqlCommand();
          }
          catch (Exception ex)
          {
            Log("Failed to add PK ");
            LogLatestSqlCommandFailed();
          }
        }
      }

      // recreate relationship
      foreach (var rel in rels)
      {
        string tblCols = "";
        string refCols = "";
        foreach (string c in rel.TableCols)
        {
          tblCols += c + ",";
        }
        tblCols = tblCols.Substring(0, tblCols.Length - 1);

        foreach (string c in rel.RefrencedTableCols)
        {
          refCols += c + ",";
        }
        refCols = refCols.Substring(0, refCols.Length - 1);

        string addRel = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ([{2}]) REFERENCES {3} ([{4}]) ",
          Qualify(rel.Table), rel.FKName.Replace(".", ""), tblCols, Qualify(rel.RefrencedTable), refCols);

        try
        {
          con.Execute(addRel, null, tran, 60);
          LogLatestSqlCommand();
        }
        catch (Exception ex)
        {
          Log("Failed to add FK constraint ");
          LogLatestSqlCommandFailed();
        }
      }

      return;
    }

    private static string Qualify(string p)
    {
      return "["+p.Replace(".","].[")+"]";
    }
  }
}
