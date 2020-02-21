using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConvertDBKeyToID.Models;
using Dapper;

namespace ConvertDBKeyToID.DB
{
  public class DbUtils
  {
    public static string conStr = "Data Source=.;Initial Catalog=V@LID49V6_CMS_2020;User id = sa; password = password123!";
    public static string qAllTables = string.Format(@"SELECT upper(TABLE_NAME) as Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME NOT LIKE 'sys%'");
    public static string qPK = @"SELECT TABLE_NAME, CONSTRAINT_NAME CONSTNAME, COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                                WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1";

    public static string qCols = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where table_name = '{0}'";

    public static string qRel = @"SELECT
                                fk.name 'FKName',
                                tp.name 'Table',
                                cp.name TableCol, 
                                tr.name 'ReferencedTable',
                                cr.name ReferencedTableCol
                            FROM 
                                sys.foreign_keys fk
                            INNER JOIN 
                                sys.tables tp ON fk.parent_object_id = tp.object_id
                            INNER JOIN 
                                sys.tables tr ON fk.referenced_object_id = tr.object_id
                            INNER JOIN 
                                sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
                            INNER JOIN 
                                sys.columns cp ON fkc.parent_column_id = cp.column_id AND fkc.parent_object_id = cp.object_id
                            INNER JOIN 
                                sys.columns cr ON fkc.referenced_column_id = cr.column_id AND fkc.referenced_object_id = cr.object_id
                            ORDER BY
                                tp.name, cp.column_id";


    public static IDbConnection GetConnection()
    {
      return new SqlConnection(conStr);
    }

    public static List<Table> GetTables(IDbConnection con)
    {

      // Rename Column ID in 'JURNAL_ROLE'
      con.Execute("exec sp_RENAME 'JURNAL_ROLE.ID', 'IDJR', 'COLUMN'",null,null,60);


      var tbls = new List<Table>();
      Dictionary<string, Constrain> kk = new Dictionary<string, Constrain>();
      IEnumerable<dynamic> pks = con.Query<dynamic>(qPK).ToList();
      foreach(var r in pks)
      {
        var f = r as IDictionary<string, object>;
        var tbname = f["TABLE_NAME"].ToString();
        var konstname = f["CONSTNAME"].ToString();
        var col = f["COLUMN_NAME"].ToString();
        var tb = tbls.Find(i => i.Name == tbname);
        if (tb == null)
        {
          tb = new Table();
          tb.Name = tbname;
          tb.PK_Constrains.Name = konstname;
          tbls.Add(tb);
        }
        if (!tb.PK_Constrains.Cols.Contains(col))
        {
          tb.PK_Constrains.Cols.Add(col);
        }
      }

      
      // collect columns and add AK
      foreach (var tb in tbls)
      {
        // 1. collect columns
        tb.Cols = con.Query<string>(string.Format(qCols,tb.Name)).ToList<string>();
        
        // 1. cek if ID column exist
        var id = tb.Cols.Find(i => i.ToUpper() == "ID");
        if (id != null)
        {
          tb.isIDColExist = true;
          // if ID is PK
          if (tb.PK_Constrains.Cols.Count == 1 && tb.PK_Constrains.Cols[0].ToUpper() == "ID")
          {
            tb.isIDColPK = true;
            continue;
          }
        }

        // 1. Add AK
        string addAK = string.Format("ALTER TABLE {0} ADD CONSTRAINT AK_{1} UNIQUE (",tb.Name, tb.PK_Constrains.Name);
        foreach(string s in tb.PK_Constrains.Cols)
        {
          addAK += s+",";
        }
        addAK = addAK.Substring(0,addAK.Length -1) +")";
        con.Execute(addAK, null, null, 60);
      }

      // collect relationship
      var rels = new List<Relationship>();
      Dictionary<string, Constrain> jj = new Dictionary<string, Constrain>();
      IEnumerable<dynamic> relq = con.Query<dynamic>(qRel).ToList();
      foreach(var r in relq)
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
        string dropRel = string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", rel.Table, rel.FKName);
        con.Execute(dropRel, null, null, 60);
      }

      foreach (var tb in tbls)
      {
        // 2. remove PK
        string dropPK = string.Format("ALTER TABLE {0} DROP CONSTRAINT {1}", tb.Name, tb.PK_Constrains.Name);
        con.Execute(dropPK, null, null, 60);

        // 3. add ID if not exist
        if (!tb.isIDColExist)
        {
          string addID = string.Format("ALTER TABLE {0} ADD ID bigint IDENTITY(1,1)", tb.Name);
          con.Execute(addID,null,null,60);
          tb.isIDColExist = true;
        }

        // 
        // make ID primary key
        //if (!tb.isIDColPK)
        {
          string addPK = string.Format("ALTER TABLE {0} ADD CONSTRAINT PK_{0} PRIMARY KEY CLUSTERED ([ID])", tb.Name);
          con.Execute(addPK, null, null, 60);
          tb.isIDColPK = true;
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

        string addRel = string.Format("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3} ({4}) ",
          rel.Table, rel.FKName, tblCols, rel.RefrencedTable, refCols);

        try
        {
          con.Execute(addRel, null, null, 60);
        }
        catch (Exception ex)
        {
        }
      }

      return tbls;
    }

  }
}
