using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using mshtml;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Web.UI;
using System.Diagnostics;
using System.Collections.Specialized;

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
    public class CommUitl
    {
        public static void SetElementValue(HtmlElement htmlElement, string value)
        {
            if (htmlElement != null)
            {
                htmlElement.SetAttribute("value", value);
            }
        }

        /// <summary>
        /// 得到验证码图片
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ImgName"></param>
        /// <returns></returns>
        public static Image GetPic(HtmlDocument doc, string ImgName)
        {
            Image RegImg;
            HTMLDocument domDoc = (HTMLDocument)doc.DomDocument;

            HTMLBody body = (HTMLBody)domDoc.body;
            IHTMLControlRange rang = (IHTMLControlRange)body.createControlRange();
            IHTMLControlElement Img;


            Img = (IHTMLControlElement)doc.All[ImgName].DomElement;

            rang.add(Img);
            rang.execCommand("Copy", false, null);
            RegImg = Clipboard.GetImage();
            Clipboard.Clear(); return RegImg;
        }

        public static string getString(string url)
        {
            return getString(url, null);
        }

        public static string getString(string url, CookieContainer cookieContainer)
        {
            return getString(url, cookieContainer, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string getString(string url, CookieContainer cookieContainer, string referer)
        {
            string result=string.Empty;
            HttpWebRequest request = HttpWebResponseUtility.CreateGetHttpResponse(url,cookieContainer,referer);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                result = getResponseString( response);
                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        private static string getResponseString(HttpWebResponse response)
        {
            string result = string.Empty;
            if (response != null)
            {
                Stream responseStream = response.GetResponseStream();
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                using (StreamReader streamReader = new StreamReader(responseStream)) //, Encoding.GetEncoding(response.ContentEncoding
                {
                    result = streamReader.ReadToEnd();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
            }
            return result;
        }

        public static string postString(string url, List<KeyValuePair<string,string>> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies, string referer)
        {
            string result = string.Empty;
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, timeout, userAgent, requestEncoding, cookies, referer);
                result = getResponseString(response);
                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public static string ReplaceHTMLAttributes(string html)
        {
            //删除脚本
            html = Regex.Replace(html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            //删除HTML
            html = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //html = Regex.Replace(html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"-->", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<!--.*", "", RegexOptions.IgnoreCase);

            html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            html.Replace("<", "");
            html.Replace(">", "");

            return html;
        }

        /// <summary>
        /// 得到枚举值的数量
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static int GetEnumCount(Type enumType)
        {
            return Enum.GetValues(enumType).Length;
        }

        /// <summary>
        /// 是否在执行选中事件.防止重复执行
        /// </summary>
        private static bool isCheckBox_Click=false;
        /// <summary>
        /// 包括选中所有复选框的复选框列表
        /// </summary>
        /// <param name="currentCheckBox">点击的复选框</param>
        /// <param name="selectAllCheckBox">选择所有筛选框</param>
        /// <param name="checkboxCollection">其他的复选框</param>
        public static void SelectAllChkChange(CheckBox currentCheckBox, CheckBox selectAllCheckBox, System.Windows.Forms.Control.ControlCollection checkboxCollection)
        {
            if (isCheckBox_Click == false)
            {
                isCheckBox_Click = true;
                if (currentCheckBox == selectAllCheckBox)
                {
                    foreach (var item in checkboxCollection)
                    {
                        if (item is CheckBox)
                        {
                            (item as CheckBox).Checked = currentCheckBox.Checked;
                        }
                    }
                }
                else
                {
                    if (currentCheckBox.Checked == false)
                    {
                        selectAllCheckBox.Checked = false;
                    }
                    else
                    {
                        bool allSelected = true;
                        foreach (var item in checkboxCollection)
                        {
                            if (item is CheckBox)
                            {
                                if (item == selectAllCheckBox)
                                {
                                    continue;
                                }
                                else
                                {
                                    allSelected &= (item as CheckBox).Checked;
                                }
                            }
                        }
                        selectAllCheckBox.Checked = allSelected;
                    }
                }
                isCheckBox_Click = false;
            }
        }

        public static Image getVerificationCode(string url, CookieContainer cookieContainer, CookieCollection cookieCollection)
        {
            Image result = null;
            HttpWebRequest request2 = HttpWebResponseUtility.CreateGetHttpResponse(url, cookieContainer, "https://dynamic.12306.cn/otsweb/loginAction.do?method=init");
            HttpWebResponse response;
            string cookieStr=string.Empty;
            try
            {
                response = (HttpWebResponse)request2.GetResponse();
            }
            catch (Exception ex)
            {
                throw;
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
                cookieStr = cookieStr ?? string.Empty;
                cookieContainer.SetCookies(new Uri(url), cookieStr);

                result = Image.FromStream(responseStream);
            }
            return result;
        }
    }
}
