using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Authentication;
using System.Runtime.InteropServices;
using System.Threading;

namespace DeGuangTicketsHelper
{
    /// <summary>
    /// 项目名称:德广火车票助手
    /// 公司:深圳市德广信息技术有限公司
    /// 作者:武广敬
    /// 此项目目前开源,所以请注意以下几点
    /// 请保留此版权信息.
    /// 自由再散布（Free Distribution）：允许获得源代码的人可自由再将此源代码散布。
    /// 源代码（Source Code）：程序的可执行文件在散布时，必需以随附完整源代码或是可让人方便的事后取得源代码。
    /// 派生著作（Derived Works）：让人可依此源代码修改后，在依照同一授权条款的情形下再散布。
    /// 原创作者程序源代码的完整性（Integrity of The Author’s Source Code）：意即修改后的版本，需以不同的版本号码以与原始的代码做分别，保障原始的代码完整性。
    /// 不得对任何人或团体有差别待遇（No Discrimination Against Persons or Groups）：开放源代码软件不得因性别、团体、国家、族群等设置限制，但若是因为法律规定的情形则为例外（如：美国政府限制高加密软件的出口）。
    /// 对程序在任何领域内的利用不得有差别待遇（No Discrimination Against Fields of Endeavor）：意即不得限制商业使用。
    /// 散布授权条款（Distribution of License）：若软件再散布，必需以同一条款散布之。
    /// 授权条款不得专属于特定产品（License Must Not Be Specific to a Product）：若多个程序组合成一套软件，则当某一开放源代码的程序单独散布时，也必需要符合开放源代码的条件。
    /// 授权条款不得限制其他软件（License Must Not Restrict Other Software）：当某一开放源代码软件与其他非开放源代码软件一起散布时（例如放在同一光盘），不得限制其他软件的授权条件也要遵照开放源代码的授权。
    /// 授权条款必须技术中立（License Must Be Technology-Neutral）：意即授权条款不得限制为电子格式才有效，若是纸本的授权条款也应视为有效。
    /// </summary>
    public partial class frmTicketsHelper : Form
    {


        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        public delegate void LoggedDelegate1();
        public delegate void showMsgDelegate1(string msg);
        public delegate bool focusDelegate1();
        public LoggedDelegate1 LoggedDelegate;
        public showMsgDelegate1 showMsgDelegate;
        public focusDelegate1 focusDelegate;

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; Trident/4.0; .NET CLR 1.1.4322; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        private static readonly string DefaultAccept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
        private static readonly string DefaultContentType = "text/html; charset=GBK";
        CookieContainer cookieContainer;
        CookieCollection cookieCollection;
        string cookieStr;
        string html;
        private static bool stop = false;
        private static int count = 0;

        public frmTicketsHelper()
        {
            InitializeComponent();
            LoggedDelegate = new LoggedDelegate1(openie);
            showMsgDelegate = new showMsgDelegate1(showInfo);
            focusDelegate = new focusDelegate1(Focus);
            cookieContainer = new CookieContainer();
            cookieCollection = new CookieCollection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void getVerificationCode()
        {
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            //string url = "http://www.12306.cn/mormhweb/kyfw/";

            //HttpWebRequest request1 = HttpWebResponseUtility.CreateGetHttpResponse(url, cookieContainer) ;

            string url = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=lrand";
            HttpWebRequest request2 = HttpWebResponseUtility.CreateGetHttpResponse(url, cookieContainer, "https://dynamic.12306.cn/otsweb/loginAction.do?method=login");
            HttpWebResponse response=null;
            try
            {
                response = (HttpWebResponse)request2.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接12306.cn网站出错!","异常", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            if (response != null)
            {
                Stream responseStream = response.GetResponseStream();

                response.Cookies = request2.CookieContainer.GetCookies(new Uri(url));

                cookieCollection = response.Cookies;

                if (string.IsNullOrEmpty(cookieStr) == true)
                {
                    cookieStr = response.Headers.Get("Set-Cookie");
                }
                cookieContainer.SetCookies(new Uri(url), cookieStr);

                Image original = Image.FromStream(responseStream);

                picValidImg.Image = original;
 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("目前是单线程版本,所以程序可能没有反应,此为正常现象,待登录成功后,即会自动弹出IE浏览器.");
             if (picValidImg.Image == null)
            {
                getVerificationCode();
            }
            else
            {
                if (validate() == true)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(login));   
                }
            }
        }

        private bool validate()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) == true)
            {
                MessageBox.Show("请输入登录名!");
                return false;
            }else if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                MessageBox.Show("请输入密码!");
                return false;
            }
            return true;
        }

        private void login()
        {
            login(null);
        }

        private void login(object obj)
        {
            if (obj != null)
            {
                Thread.CurrentThread.Name = obj.ToString();
            }
            if (stop == true)
            {
                if (MessageBox.Show("您已经登录,您需要再次进入12306网站吗?需要您已经退出,就需要重新登录!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Invoke(LoggedDelegate);
                    //openie();
                }
                return;
            }
               
            Trace.WriteLine("login()");
            count++;
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            // this is what we are sending
            string post_data = "loginUser.user_name=tony12306cn&nameErrorFocus=&user.password=tony1234&passwordErrorFocus=&randCode=" + txtVerificationCode.Text + "&randErrorFocus=focus";

            // this is where we will send it
            string uri = "https://dynamic.12306.cn/otsweb/loginAction.do?method=login";

            // create a request
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            //request.CookieContainer = cookieContainer;
            //request.KeepAlive = false;
            //request.ProtocolVersion = HttpVersion.Version10;
            //request.Method = "POST";

            //// turn our request string into a byte stream
            //byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

            //// this is important - make sure you specify type this way
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = postBytes.Length;
            //Stream requestStream = request.GetRequestStream();

            //// now send it
            //requestStream.Write(postBytes, 0, postBytes.Length);
            //requestStream.Close();

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("loginUser.user_name", txtUserName.Text);
            param.Add("nameErrorFocus", string.Empty);
            param.Add("user.password", txtPassword.Text);
            param.Add("passwordErrorFocus", string.Empty);
            param.Add("randCode", txtVerificationCode.Text);
            param.Add("randErrorFocus", "focus");

            HttpWebResponse response=null;
            try
            {
                response = HttpWebResponseUtility.CreatePostHttpResponse(uri, param, null, null, Encoding.ASCII, cookieCollection, uri);
            }
            catch (Exception ex)
            {
                this.Invoke(this.showMsgDelegate, ex.Message);
                //showInfo(ex.Message);
            }

            if (response != null)
            {
                // grab te response and print it out to the console along with the status code
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (html.IndexOf("当前访问用户过多") > 0)
                {
                    this.Invoke(this.showMsgDelegate, "当前访问用户过多");
                    login();
                }
                else if (html.IndexOf("请输入正确的验证码") > 0)
                {
                    MessageBox.Show("请输入正确的验证码!");
                    this.Invoke(this.showMsgDelegate, "请输入正确的验证码!");
                    getVerificationCode();
                }
                else if (html.IndexOf("登录名不存在") > 0)
                {
                    MessageBox.Show("登录名不存在!!");
                    this.Invoke(this.showMsgDelegate, "登录名不存在!!");
                }
                else if (html.IndexOf("密码输入错误") > 0)
                {
                    MessageBox.Show("密码输入错误,如果多次输入错误可能会被锁定帐户!");
                    this.Invoke(this.showMsgDelegate, "密码输入错误");
                }
                else if (html.IndexOf("我的12306") > 0)
                {
                    stop = true;
                    this.Invoke(focusDelegate);
                    
                    MessageBox.Show("登录成功!点击确定帮您打开12306网站,您可以直接点击\"车票预订\"啦!祝你回家一路顺风!", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Invoke(LoggedDelegate);
                    //openie();
                    this.Invoke(this.showMsgDelegate, "登录成功!");
                }
                else
                {
                    Trace.WriteLine(html);
                    login();
                }
                Trace.WriteLine(response.StatusCode);
            }
            else
            {
                login();
            }
        }

        private void openie()
        {
            foreach (Cookie cookie in cookieContainer.GetCookies(new Uri("https://dynamic.12306.cn/otsweb/loginAction.do?method=login")))
            {
                InternetSetCookie(
                    "https://" + cookie.Domain.ToString(),
                    cookie.Name.ToString(),
                    cookie.Value.ToString() + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
            string url="https://dynamic.12306.cn/otsweb/";
            TickerWebBrowser tw = new TickerWebBrowser();
            tw.Url = url;
            tw.ShowDialog();
            //System.Diagnostics.Process.Start("IExplore.exe", url);
        }

        private void showInfo(string info)
        {
            info = count+"-" +DateTime.Now.ToString("HH:mm:ss")+ info;

            if (lstMsg.Items.Count > 100)
            {
                lstMsg.Items.RemoveAt(100);
            }
            lstMsg.Items.Insert(0, info);
        }

        private void frmTicketsHelper1_Load(object sender, EventArgs e)
        {
            getVerificationCode();
        }

        private void frmTicketsHelper1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void linkComPany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.9inf.com");
        }
    }

    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint,
          X509Certificate certificate, WebRequest request,
          int certificateProblem)
        {
            //Return True to force the certificate to be accepted.
            return true;
        }
    }
}
