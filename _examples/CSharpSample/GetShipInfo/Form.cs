using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void GetPageData(object sender, EventArgs e)
        {
            try
            {

                WebClient MyWebClient = new WebClient
                {   //获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                    Credentials = CredentialCache.DefaultCredentials
                };

                Byte[] pageData = MyWebClient.DownloadData("https://www.baidu.com/"); //下载数据
                string pageHtml = Encoding.UTF8.GetString(pageData); //网站页面采用的是UTF-8，则使用这句

                using (StreamWriter sw = new StreamWriter("D:\\ouput.html"))    //写入文本

                {
                    sw.Write(pageHtml);

                }
                this.rtb_to.Text = pageHtml;
            }
            catch (WebException webEx)
            {

                Console.WriteLine(webEx.Message.ToString());

            }
        }
        
        private void GetPosInfo(object sender, EventArgs e)
        {
            ShipMng translator = new ShipMng();
            this.rtb_to.Text = translator.GetPosInfo(this.tb_url.Text);
        }


        private void GetShipInfo(object sender, EventArgs e)
        {
            ShipMng translator = new ShipMng();
            this.rtb_to.Text = translator.GetShipInfo(this.tb_url.Text);
        }


        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}