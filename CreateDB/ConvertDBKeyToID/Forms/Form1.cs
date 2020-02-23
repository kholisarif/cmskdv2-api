using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConvertDBKeyToID.DB;
using System.Threading;

namespace ConvertDBKeyToID
{
  public partial class FormMain : Form
  {
    Thread t = null;

    public FormMain()
    {
      InitializeComponent();
    }

    private void connectToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      if (this.btnRun.Text == "Run")
      {
        this.btnRun.Text = "Cancel";
        this.backgroundWorker2.RunWorkerAsync(2000);
      }
      else
      {
        this.btnRun.Text = "Run";
        this.backgroundWorker2.CancelAsync();
      }
      
    }

    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (t!=null && t.IsAlive)
      {
        t.Abort();
      }
      t = null;

      this.btnRun.Text = "Run";

      if (e.Cancelled)
      {
        MessageBox.Show("Operation was canceled");
      }
      else if (e.Error != null)
      {
        string msg = String.Format("An error occurred: {0}", e.Error.Message);
        MessageBox.Show(msg);
      }
      else
      {
        string msg = String.Format("Result = {0}", e.Result);
        MessageBox.Show(msg);
      }
    }

    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bw = new BackgroundWorker();

      int arg = (int)e.Argument;

      e.Result = TimeConsumingOperation(bw, 200);

      if (bw.CancellationPending)
      {
        e.Cancel = true;
      }
    }

    private int TimeConsumingOperation(BackgroundWorker bw,int sleepPeriod)
    {
      int result = 0;
      Thread t = new Thread(() =>
      {
        using (var con = DbUtils.GetConnection())
        {
          if (con.State == ConnectionState.Closed)
          {
            con.Open();
          }
          IDbTransaction tran;
          tran = null; //con.BeginTransaction();
          //using ()
          {
            try
            {
              DbUtils.ConvertKeyToID(con,tran);
              //tran.Commit();
            }
            catch (Exception ex)
            {
              //tran.Rollback();
            }
          }
        }
      });
      t.IsBackground = true;
      t.Name = "RUNNER";
      t.Start();
      Thread.Sleep(300);

      while (!bw.CancellationPending)
      {
        bool exit = false;
        if (!t.IsAlive)
        {
          exit = true;
          break;
        }
        Thread.Sleep(sleepPeriod);
      }
      return result;
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      DbUtils.OnLog += new DbUtils.logDelegate(OutLog);
    }

    

    public void OutLog(string newText)
    {
      this.BeginInvoke(new MethodInvoker(()=>
      {
        this.txtConsolole.AppendText(newText + "\r\n");
      }));
    }

    private void btnClearConsole_Click(object sender, EventArgs e)
    {

      this.txtConsolole.Clear();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      for(int i=1;i<10;i++){
        OutLog("test");
      }
    }

  }
}
