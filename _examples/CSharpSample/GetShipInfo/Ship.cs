using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WindowsFormsApp1
{
    class ShipMng
    {
        Dictionary<string, string> param;
        private string host = "www.chinaports.com";
        private string refer = "http://www.chinaports.com/shiptracker/olv3/index.jsp";
        private string agent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.104 Safari/537.36 Core/1.53.4549.400 QQBrowser/9.7.12900.400";

        private string shipinit = "http://www.chinaports.com/shiptracker/shipinit.do";
        private string shipquery = "http://www.chinaports.com/shiptracker/newshipquery.do";


        public ShipMng()
        {
            param = new Dictionary<string, string>();
        }

        //URL编码
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        public string GetShipId(string mmsi)
        {
            string shipId;
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "method", "search" },
                { "isall", "0" },
                { "cnqp", mmsi },
                { "vession", "0" },
                { "queryParam", mmsi }
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(shipquery);
            request.Method = "Post";
            request.Host = host;
            request.Referer = refer;
            request.UserAgent = agent;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF - 8";

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dict)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                shipId = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            response.Close();

            List<List<string>> infolist = JsonConvert.DeserializeObject<List<List<string>>>(shipId);
            shipId = infolist[0][1];


            System.Diagnostics.Debug.WriteLine(shipId);

            return shipId;
        }
        

        public string GetPosInfo(string mmsi)
        {
            string posinfo = "";

            string shipId = GetShipId(mmsi);
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "method", "pospoint" },
                { "type", "1" },
                {"shipid", shipId }
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(shipinit);
            request.Method = "Post";
            request.Host = host;
            request.Referer = refer;
            request.UserAgent = agent;
            request.ContentType = "application/x-www-form-urlencoded";

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dict)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                posinfo = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            response.Close();
            System.Diagnostics.Debug.WriteLine(posinfo);

            return posinfo;

        }

        public string GetShipInfo(string mmsi)
        {
            string shipInfo;
            string userId = GetShipId(mmsi);            
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long num = (long)ts.TotalMilliseconds;
 

            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "method", "shipInfo" },
                { "userid", userId },
                { "source", "0" },
                { "num", num.ToString() }
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(shipinit);
            request.Method = "Post";
            request.Host = host;
            request.Referer = refer;
            request.UserAgent = agent;
            request.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数  
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dict)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            request.ContentLength = data.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                shipInfo = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            response.Close();
            System.Diagnostics.Debug.Write(shipInfo);

            return shipInfo;
        }
    }
}
