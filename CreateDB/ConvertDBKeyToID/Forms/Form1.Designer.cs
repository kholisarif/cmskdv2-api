namespace ConvertDBKeyToID
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.mnMain = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btnRun = new System.Windows.Forms.Button();
      this.txtConsolole = new System.Windows.Forms.TextBox();
      this.btnClearConsole = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
      this.mnMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // mnMain
      // 
      this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.mnMain.Location = new System.Drawing.Point(0, 0);
      this.mnMain.Name = "mnMain";
      this.mnMain.Size = new System.Drawing.Size(727, 24);
      this.mnMain.TabIndex = 1;
      this.mnMain.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // connectToolStripMenuItem
      // 
      this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
      this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
      this.connectToolStripMenuItem.Text = "Connect";
      this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
      // 
      // btnRun
      // 
      this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRun.Location = new System.Drawing.Point(640, 351);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(75, 23);
      this.btnRun.TabIndex = 2;
      this.btnRun.Text = "Run";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // txtConsolole
      // 
      this.txtConsolole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtConsolole.Location = new System.Drawing.Point(12, 27);
      this.txtConsolole.Multiline = true;
      this.txtConsolole.Name = "txtConsolole";
      this.txtConsolole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtConsolole.Size = new System.Drawing.Size(703, 318);
      this.txtConsolole.TabIndex = 3;
      // 
      // btnClearConsole
      // 
      this.btnClearConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnClearConsole.Location = new System.Drawing.Point(12, 351);
      this.btnClearConsole.Name = "btnClearConsole";
      this.btnClearConsole.Size = new System.Drawing.Size(75, 23);
      this.btnClearConsole.TabIndex = 4;
      this.btnClearConsole.Text = "Clear Console";
      this.btnClearConsole.UseVisualStyleBackColor = true;
      this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(93, 351);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(94, 23);
      this.button1.TabIndex = 5;
      this.button1.Text = "Test Console";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // backgroundWorker2
      // 
      this.backgroundWorker2.WorkerSupportsCancellation = true;
      this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
      this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(727, 386);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.btnClearConsole);
      this.Controls.Add(this.txtConsolole);
      this.Controls.Add(this.btnRun);
      this.Controls.Add(this.mnMain);
      this.MainMenuStrip = this.mnMain;
      this.Name = "FormMain";
      this.Text = "Sql Server Key Converter";
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.mnMain.ResumeLayout(false);
      this.mnMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtConsolole;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

