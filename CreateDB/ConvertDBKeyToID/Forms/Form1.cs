using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConvertDBKeyToID.DB;

namespace ConvertDBKeyToID
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void connectToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      using (var con = DbUtils.GetConnection())
      {
        var tbls = DbUtils.GetTables(con);
      }
    }
  }
}
