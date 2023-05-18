using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;

namespace MyForm
{
    public partial class TranslateForm : Form
    {
        public TranslateForm()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            translate(txtOriginal.Text.ToString());
        }

        private void postdata()
        {
           
            try {
                WebClient MyWebClient = new WebClient();
        
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

                Byte[] pageData = MyWebClient.DownloadData("http://www.163.com"); //从指定网站下载数据

                string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

                //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

                Console.WriteLine(pageHtml);//在控制台输入获取的内容

                using (StreamWriter sw = new StreamWriter(@"f:\\ouput.html"))//将获取的内容写入文本
                {
                    sw.Write(pageHtml);
                }
                Console.ReadLine(); //让控制台暂停,否则一闪而过了    
            }

            catch (WebException webEx) {

                Console.WriteLine(webEx.Message.ToString());

            }
        }

        /* 
            调用：http://fanyi.youdao.com/openapi.do?keyfrom=sasfasdfasf&key=1177596287&type=data&doctype=json&version=1.1&q=中国人
            返回的json格式如下：
            {"translation":["The Chinese"],"basic":{"phonetic":"zhōng guó rén","explains":["Chinese","Chinaman","Chinese people","Chinee","chow"]}
             * ,"query":"中国人","errorCode":0,"web":[{"value":["Chinaren","Chinese people","The Chinese","Chinese person"],"key":"中国人"},
             * {"value":["中国人"],"key":"中國人"},{"value":["CHINA LIFE","LFC","china life insurance","YZC"],"key":"中国人寿"},{"value":["Human Rights in China","HRIC"],"key":"中国人权"},
             * {"value":["China Life Insurance Company","China Life Insurance","China Life","China Life Insurance Co Ltd"],"key":"中国人寿保险"},
             * {"value":["Chinese name","Chinese Names in English","Courtesy Name"],"key":"中国人名"},{"value":["Chinese Names"],"key":"中国人的名字"},
             * {"value":["CJOL"],"key":"中国人才热线"},{"value":["American Born Chinese"],"key":"美生中国人"},{"value":["Chinese Characteristics"],"key":"中国人德行"}]}*/

        private void translate(string original)
        {            
            string serverUrl = @"http://fanyi.youdao.com/openapi.do?keyfrom=sasfasdfasf&key=1177596287&type=data&doctype=json&version=1.1&q=" + HttpUtility.UrlEncode(original);
            WebRequest request = WebRequest.Create(serverUrl);
            WebResponse response = request.GetResponse();
            string jsonText = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            Console.WriteLine(jsonText);
            //JsonReader reader = new JsonTextReader(new StringReader(jsonText));
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
            //}
        }
    }
}
