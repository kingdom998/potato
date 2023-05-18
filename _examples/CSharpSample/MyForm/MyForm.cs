using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyForm;
using System.Data.SQLite;

namespace MyForm
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            //// 打开文件对话框
            //// 如果为可执行文件则运行
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"所有文件|*.*|Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|以逗号分隔的值(*.csv;*.CSV)|*.csv;*.CSV)";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                string strFileName = ofd.FileName;
                if (strFileName.EndsWith(".exe"))
                {
                    string msg = strFileName.Substring(0, strFileName.Length - 4);
                    if (DialogResult.OK == MessageBox.Show("Open " + msg, "Information", MessageBoxButtons.OKCancel))
                    {
                        System.Diagnostics.Process.Start(strFileName);
                    }
                }
                else
                {
                    m_rtb.Text = ofd.FileName;
                }
            }

            // 链接数据库
            Sqlite mySqlite = new Sqlite();           
        }

        //private void ProcessCmdKey(object sender, KeyEventArgs e)
        //{
        //    Keys key = e.KeyCode;
        //    if (e.Control!=true)//如果没按Ctrl键
        //        return;
        //    switch (key)
        //    {
        //        case Keys.NumPad0:
        //            //按下小键盘0以后
        //            m_txt.Text = "NumPad0 is pressed!";
        //            break;
        //        case Keys.NumPad1:
        //            //按下小键盘1以后
        //            break;
        //        case Keys.S:
        //            //按下S键以后
        //            break;
        //        case Keys.Up:
        //            //按下向下键以后
        //            break;
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    MessageBox.Show("Right");
                    break;
                case Keys.Left:
                    MessageBox.Show("Left");
                    break;
                case Keys.Up:
                    MessageBox.Show("up");
                    break;
                case Keys.Down:
                    MessageBox.Show("down");
                    break;
                case Keys.Space:
                    MessageBox.Show("space");
                    break;
                case Keys.Enter:
                    MessageBox.Show("enter");
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            return false;
        }

        private void mnColor_Click(object sender, EventArgs e)
        {
            m_cDlg.ShowDialog();
        }

        private void mnFont_Click(object sender, EventArgs e)
        {
            m_fDlg.ShowDialog();
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            //数据库文件路径  
            var datapath = "E:/tmp.sqlite";
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = datapath;

            //建立数据库连接  
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = connstr.ToString();
            conn.Open();

            //查询语句  
            string sqlCommandString = "select * from geometry_columns";
            //利用 Adapter 转换结果到 datagrid  
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommandString, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataView dv = ds.Tables[0].DefaultView;
            m_dgv.DataSource = dv;
        }

        private void mnTranslate_Click(object sender, EventArgs e)
        {
            TranslateForm translateForm = new TranslateForm();
            translateForm.ShowDialog();
        }

        private void mnCut_Click(object sender, EventArgs e)
        {
            MyFile myFile = new MyFile();
            myFile.fileStream();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            MyFile myFile = new MyFile();
            myFile.directoryInfo();
        }
        
    }

   
}
