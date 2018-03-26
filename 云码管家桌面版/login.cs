using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using 云码管家桌面版.urer;

namespace 云码管家桌面版
{
    public partial class login : DSkinForm
    {
        public login()
        {
            InitializeComponent();
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            string urere=System.Web.HttpUtility.UrlEncode(dSkinTextBox1.Text);
            string namme=http("http://www.pituber.com/session", "login="+ urere + "&password="+ dSkinTextBox2.Text);
            if (namme.IndexOf("服务器出现问题") == -1)
            {
                urer.urer.name = namme.Split(new string[] { "name" }, StringSplitOptions.None)[5].Split(',')[0].Replace("\"", "").Replace(":", "");
                urer.urer.img = Properties.Resources._32;
                urer.urer.login = true;
                urer.urer.urere = dSkinTextBox1.Text;
                urer.urer.passd = dSkinTextBox2.Text;
                MessageBox.Show("登陆成功！！" + urer.urer.name);
                this.Close();
            }
            else { MessageBox.Show("登陆失败账号或者密码错误或者服务器出现问题！！" + urer.urer.name); }
        }
        public string http(string url,string data)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式
            request.Method = "POST";
            // 内容类型
            request.Accept = "*/*";
            request.Referer = "http://www.pituber.com/";
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("Cookie", "_forum_session=NW93UHhGWTh4L0lWbzljdXUzNVVOQndoMHNnTFpiVDVjWHlWb1BtazV0OEp0dSsrY2huK1dUR3BhWjgybko2T1Q1cUxRY2NmY0NxS2YvcUFZQUJwZ0lYZk1hc1U0S21kdXVFWGdiUVZWVGJHUytBL082cktNVEdPdk9IVnJBRko5QmVvZ25mcW5QenU0T1hhZ1REOGQ2OENCNVVSSFVxRURFTDlOS3RlWHlyc3pqTHZTQ3dYa1RXSy80STRCQlhLLS0yMHBOL0pib00rRWVMUUg1cFNJTWFBPT0%3D--ae862911c5a57881219075d11d7075bb2599ea25");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:52.0) Gecko/20100101 Firefox/52.0";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("X-CSRF-Token", "7dBhn5Yluf9/STUU3LZl3cxpvayVKjO4rME4EdqMRAL+QRS6euqIaAOWETsLsMnEbjjk0zdIpW6kSuvjjMAQbQ==");
            // 参数经过URL编码
            string paraUrlCoded = data;//System.Web.HttpUtility.UrlEncode("keyword");
            //paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode("多月");
            byte[] payload;
            //将URL编码后的字符串转化为字节
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的 ContentLength 
            request.ContentLength = payload.Length;
            //获得请 求流
            System.IO.Stream writer = request.GetRequestStream();
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            // 关闭请求流
            writer.Close();
            System.Net.HttpWebResponse response;
            // 获得响应流
            string responseText = string.Empty;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseText = myreader.ReadToEnd();
                myreader.Close();
            }
            catch (Exception e)
            {
                responseText = "服务器出现问题！！请五分钟后尝试";
            }
            //MessageBox.Show(responseText);
            return responseText;//
            
        }
        bool k = false;
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (k)
            {
                if (webBrowser1.Document.Cookie.IndexOf("skey=@") == -1)
                {
                    MessageBox.Show("登陆失败！！！");
                }
                else
                {
                    string qq = webBrowser1.Document.Cookie.Split(new string[] { "pt2gguin=" }, StringSplitOptions.None)[1].Split(';')[0].Replace("o", "");
                    urer.urer.name = http("http://r.pengyou.com/fcg-bin/cgi_get_portrait.fcg?uins=" + qq).Split('"')[5];
                    urer.urer.img = img("http://q2.qlogo.cn/headimg_dl?bs=[qq]&dst_uin=[qq]&dst_uin=[qq]&;dst_uin=[qq]&spec=100&url_enc=0&referer=bu_interface&term_type=PC".Replace("[qq]", qq));
                    urer.urer.urere = qq;
                    urer.urer.login = true;
                    this.Close();
                }           
            }
        }

        private Image img(string url)
        {
            Bitmap img = null;
            HttpWebRequest req;
            HttpWebResponse res = null;
            try
            {
                System.Uri httpUrl = new System.Uri(url);
                req = (HttpWebRequest)(WebRequest.Create(httpUrl));
                req.Timeout = 180000; //设置超时值10秒
                //req.UserAgent = "XXXXX";
                //req.Accept = "XXXXXX";
                req.Method = "GET";
                res = (HttpWebResponse)(req.GetResponse());
                img = new Bitmap(res.GetResponseStream());//获取图片流   
            }
            catch {

            }
            return img;
        }

        private string http(string v)
        {
            string strURL = v;
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //request.Method="get";
            System.Net.HttpWebResponse response;
            
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            return responseText;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            k = true;
        }
    }
}
