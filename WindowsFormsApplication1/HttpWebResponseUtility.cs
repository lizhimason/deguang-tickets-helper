﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;

namespace DeGuangTicketsHelper
{
    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public class HttpWebResponseUtility
    {
        //private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; Trident/4.0; .NET CLR 1.1.4322; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        private static readonly string DefaultAccept = "*/*";
        private static readonly string DefaultContentType = "text/html; charset=GBK";
        private static readonly int DefaultTimeOut = 10000;

        public static HttpWebRequest CreateGetHttpResponse(string url)
        {
            return CreateGetHttpResponse(url, null, null, null, null);
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebRequest CreateGetHttpResponse(string url, CookieContainer cookieContainer)
        {
            return CreateGetHttpResponse(url, null, null, cookieContainer,null);
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookieContainer">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <param name="referer"></param>
        /// <returns></returns> 
        public static HttpWebRequest CreateGetHttpResponse(string url, CookieContainer cookieContainer,string referer)
        {
            return CreateGetHttpResponse(url, null, null, cookieContainer, referer);
        }

        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        //public static HttpWebRequest CreateGetHttpResponse(string url,  CookieContainer cookieContainer, string referer)
        //{
        //    return CreateGetHttpResponse(url, null, null, cookieContainer, referer);
        //}
        
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebRequest CreateGetHttpResponse(string url, int? timeout, CookieContainer cookieContainer)
        {
            return CreateGetHttpResponse(url, timeout, null, cookieContainer, null);
        }
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebRequest CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieContainer cookieContainer, string referer)
        {
            Debug.WriteLine("CreateGetHttpResponse url:" + url);
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.KeepAlive = true;
            request.Accept = DefaultAccept;
            request.UserAgent = DefaultUserAgent;
            request.Headers.Add("Accept-Language: zh-CN");
            request.Headers.Add("Accept-Encoding: gzip, deflate");
            //request.Headers.Add("Connection: Keep-Alive");
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            else
            {
                request.Timeout = DefaultTimeOut;
            }
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }
            if (!string.IsNullOrEmpty(referer))
            {
                request.Referer = referer;
            }
            //if (cookies != null)  
            //{  
            //    request.CookieContainer = new CookieContainer();  
            //    request.CookieContainer.Add(cookies);  
            //}
            return request;
        }
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, List<KeyValuePair<string,string>> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies,string referer)
        {
            Debug.WriteLine("CreatePostHttpResponse url:" + url);
            HttpWebResponse response = null;

                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                if (requestEncoding == null)
                {
                    throw new ArgumentNullException("requestEncoding");
                }
                HttpWebRequest request = null;
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(url) as HttpWebRequest;
                }

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                request.Headers.Add("Accept-Language: zh-cn");
                request.Headers.Add("Accept-Encoding: gzip, deflate");

                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                else
                {
                    request.UserAgent = DefaultUserAgent;
                }

                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                else
                {
                    request.Timeout = DefaultTimeOut;
                }
                if (cookies != null)
                {
                    request.CookieContainer = CommData.cookieContainer;
                    //request.CookieContainer = new CookieContainer();
                    //request.CookieContainer.Add(cookies);
                }
                if (!string.IsNullOrEmpty(referer))
                {
                    request.Referer = referer;
                }

                //如果需要POST数据  
                if (!(parameters == null || parameters.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    
                    foreach (var keyvalue in parameters)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", keyvalue.Key, keyvalue.Value);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", keyvalue.Key, keyvalue.Value);
                        }
                        i++;
                    }
                    byte[] data = requestEncoding.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                response= request.GetResponse() as HttpWebResponse;
            return response;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }  
}
