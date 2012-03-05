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

        private static Dictionary<SeatType, string> seatTypeNo;
        /// <summary>
        /// 座位类型编号
        /// </summary>
        public static Dictionary<SeatType, string> SeatTypeNo
        {
            get
            {
                if (seatTypeNo == null)
                {
                    seatTypeNo = new Dictionary<SeatType, string>();
                    seatTypeNo.Add(SeatType.NoSeat, "-1");
                    seatTypeNo.Add(SeatType.HardSeat, "1");
                    seatTypeNo.Add(SeatType.SoftSeat, "2");
                    seatTypeNo.Add(SeatType.HardSleeper, "3");
                    seatTypeNo.Add(SeatType.SoftSleeper, "4");
                    seatTypeNo.Add(SeatType.AdvancedSoftSleeper, "6");
                    seatTypeNo.Add(SeatType.BusinessBlock, "9");
                    seatTypeNo.Add(SeatType.FirstClassSeat, "M");
                    seatTypeNo.Add(SeatType.SecondClassSeat, "O");
                    seatTypeNo.Add(SeatType.PrincipalSeat, "P");
                }
                return seatTypeNo;
            }
        }
        private static Dictionary<SeatType, string> seatTypeName;
        /// <summary>
        /// 座位类型名称
        /// </summary>
        public static Dictionary<SeatType, string> SeatTypeName
        {
            get
            {
                if (seatTypeName == null)
                {
                    seatTypeName = new Dictionary<SeatType, string>();
                    seatTypeName.Add(SeatType.NoSeat, "无座");
                    seatTypeName.Add(SeatType.HardSeat, "硬座");
                    seatTypeName.Add(SeatType.SoftSeat, "软座");
                    seatTypeName.Add(SeatType.HardSleeper, "硬卧");
                    seatTypeName.Add(SeatType.SoftSleeper, "软卧");
                    seatTypeName.Add(SeatType.AdvancedSoftSleeper, "高级软卧");
                    seatTypeName.Add(SeatType.BusinessBlock, "商务座");
                    seatTypeName.Add(SeatType.FirstClassSeat, "一等座");
                    seatTypeName.Add(SeatType.SecondClassSeat, "二等座");
                    seatTypeName.Add(SeatType.PrincipalSeat, "特等座");
                }
                return seatTypeName;
            }
        }
    }
}
