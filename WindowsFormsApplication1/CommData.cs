using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using DeGuangTicketsHelper.Entity;

namespace DeGuangTicketsHelper
{
    public class CommData
    {
        /// <summary>
        /// cookie容器
        /// </summary>
        public static CookieContainer cookieContainer=new CookieContainer();
        /// <summary>
        /// cookie集合
        /// </summary>
        public static CookieCollection cookieCollection=new CookieCollection();

        private static int seatTypeCount=-1;
        public static int SeatTypeCount
        {
            get
            {
                if (seatTypeCount == -1)
                {
                    seatTypeCount = CommUitl.GetEnumCount(typeof(SeatType));
                }
                return seatTypeCount;
            }
        }
    }
}
