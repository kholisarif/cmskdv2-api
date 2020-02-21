using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
//using Dapper.Contrib.Extensions;


namespace ConvertDBKeyToID.Models
{
  public class Constrain
  {
    public string Name { get; set; }
    public List<string> Cols = new List<string>();
  }
  public class Table
  {
    public string Name {get;set;}
    public Constrain PK_Constrains = new Constrain();
    public List<string> Cols = new List<string>();
    public bool isIDColExist = false;
    public bool isIDColPK = false; 
  }

  public class Relationship
  {
    public string FKName {get;set;}
    public string Table {get;set;}
    public List<string> TableCols = new List<string>();
    public string RefrencedTable { get; set; }
    public List<string> RefrencedTableCols = new List<string>();

  }
}
