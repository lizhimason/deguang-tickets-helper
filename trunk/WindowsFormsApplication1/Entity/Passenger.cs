using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 乘客信息
    /// </summary>
    public class Passenger  
    {
        public Passenger()
        {
            IdMode = "Y";
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        //public CardType CardType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string IDCardType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// 座位类型,-1 无座;1 硬座 ;2 软座;3 硬卧;4 软卧 ;6 高级软卧;9 商务座  ;M 一等座 ;O 二等座 ;P 特等座
        /// </summary>
        public string SeatType { get; set; }
        /// <summary>
        /// 乘客票类型 1 成人票 ;2 儿童票 ;3 学生票 ;4 残军票 
        /// </summary>
        public string PassengerTicket{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public string IdMode { get; set; }
        /// <summary>
        /// 提交订单时passengerTickets参数值
        /// </summary>
        public string PassengerTickets
        {
            get
            {
                return SeatType+","+PassengerTicket+","+Name+","+IDCardType+","+CardNo+","+MobileNo+","+IdMode;
            }
        }
        /// <summary>
        /// 提交订单时oldPassengers参数值
        /// </summary>
        public string OldPassengers
        {
            get
            {
                return Name + "," + IDCardType + "," + CardNo;
            }
        }
    }
}
