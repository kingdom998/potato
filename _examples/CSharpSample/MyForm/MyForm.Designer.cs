namespace MyForm
{
    partial class MyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_ms = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTool = new System.Windows.Forms.ToolStripMenuItem();
            this.mnColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ss = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_ts = new System.Windows.Forms.ToolStrip();
            this.m_dgv = new System.Windows.Forms.DataGridView();
            this.m_cDlg = new System.Windows.Forms.ColorDialog();
            this.m_fDlg = new System.Windows.Forms.FontDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.m_rtb = new System.Windows.Forms.RichTextBox();
            this.m_ms.SuspendLayout();
            this.m_ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ms
            // 
            this.m_ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.mnEdit,
            this.mnTool,
            this.mnHelp});
            this.m_ms.Location = new System.Drawing.Point(0, 0);
            this.m_ms.Name = "m_ms";
            this.m_ms.Size = new System.Drawing.Size(754, 25);
            this.m_ms.TabIndex = 2;
            this.m_ms.Text = "menuStrip1";
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnOpen,
            this.mnExit});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(58, 21);
            this.mnFile.Text = "文件(&F)";
            // 
            // mnOpen
            // 
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.Size = new System.Drawing.Size(118, 22);
            this.mnOpen.Text = "打开(&O)";
            this.mnOpen.Click += new System.EventHandler(this.mnOpen_Click);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(118, 22);
            this.mnExit.Text = "退出(&E)";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnEdit
            // 
            this.mnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnCut});
            this.mnEdit.Name = "mnEdit";
            this.mnEdit.Size = new System.Drawing.Size(59, 21);
            this.mnEdit.Text = "编辑(&E)";
            // 
            // mnCut
            // 
            this.mnCut.Name = "mnCut";
            this.mnCut.Size = new System.Drawing.Size(116, 22);
            this.mnCut.Text = "剪切(&X)";
            this.mnCut.Click += new System.EventHandler(this.mnCut_Click);
            // 
            // mnTool
            // 
            this.mnTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnColor,
            this.mnFont,
            this.mnTranslate});
            this.mnTool.Name = "mnTool";
            this.mnTool.Size = new System.Drawing.Size(59, 21);
            this.mnTool.Text = "工具(&T)";
            // 
            // mnColor
            // 
            this.mnColor.Name = "mnColor";
            this.mnColor.Size = new System.Drawing.Size(100, 22);
            this.mnColor.Text = "颜色";
            this.mnColor.Click += new System.EventHandler(this.mnColor_Click);
            // 
            // mnFont
            // 
            this.mnFont.Name = "mnFont";
            this.mnFont.Size = new System.Drawing.Size(100, 22);
            this.mnFont.Text = "字体";
            this.mnFont.Click += new System.EventHandler(this.mnFont_Click);
            // 
            // mnTranslate
            // 
            this.mnTranslate.Name = "mnTranslate";
            this.mnTranslate.Size = new System.Drawing.Size(100, 22);
            this.mnTranslate.Text = "翻译";
            this.mnTranslate.Click += new System.EventHandler(this.mnTranslate_Click);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(61, 21);
            this.mnHelp.Text = "帮助(&H)";
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(116, 22);
            this.mnAbout.Text = "关于(&A)";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // m_ss
            // 
            this.m_ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.m_ss.Location = new System.Drawing.Point(0, 369);
            this.m_ss.Name = "m_ss";
            this.m_ss.Size = new System.Drawing.Size(754, 22);
            this.m_ss.TabIndex = 4;
            this.m_ss.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // m_ts
            // 
            this.m_ts.Location = new System.Drawing.Point(0, 25);
            this.m_ts.Name = "m_ts";
            this.m_ts.Size = new System.Drawing.Size(754, 25);
            this.m_ts.TabIndex = 5;
            this.m_ts.Text = "toolStrip1";
            // 
            // m_dgv
            // 
            this.m_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgv.Location = new System.Drawing.Point(0, 50);
            this.m_dgv.Name = "m_dgv";
            this.m_dgv.RowTemplate.Height = 23;
            this.m_dgv.Size = new System.Drawing.Size(754, 319);
            this.m_dgv.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.Location = new System.Drawing.Point(0, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 319);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // m_rtb
            // 
            this.m_rtb.Location = new System.Drawing.Point(275, 127);
            this.m_rtb.Name = "m_rtb";
            this.m_rtb.Size = new System.Drawing.Size(100, 96);
            this.m_rtb.TabIndex = 8;
            this.m_rtb.Text = "";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 391);
            this.Controls.Add(this.m_rtb);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.m_dgv);
            this.Controls.Add(this.m_ts);
            this.Controls.Add(this.m_ss);
            this.Controls.Add(this.m_ms);
            this.KeyPreview = true;
            this.MainMenuStrip = this.m_ms;
            this.Name = "MyForm";
            this.Text = "MyForm";
            this.m_ms.ResumeLayout(false);
            this.m_ms.PerformLayout();
            this.m_ss.ResumeLayout(false);
            this.m_ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_ms;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.StatusStrip m_ss;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip m_ts;
        private System.Windows.Forms.DataGridView m_dgv;
        private System.Windows.Forms.ToolStripMenuItem mnEdit;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem mnTool;
        private System.Windows.Forms.ToolStripMenuItem mnColor;
        private System.Windows.Forms.ToolStripMenuItem mnHelp;
        private System.Windows.Forms.ColorDialog m_cDlg;
        private System.Windows.Forms.FontDialog m_fDlg;
        private System.Windows.Forms.ToolStripMenuItem mnFont;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem mnTranslate;
        private System.Windows.Forms.ToolStripMenuItem mnCut;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.RichTextBox m_rtb;
    }
}

