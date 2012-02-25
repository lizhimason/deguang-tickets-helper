using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 监控实体
    /// </summary>
    public class MonitorEntity
    {
        /// <summary>
        /// 需要监控的车次
        /// </summary>
        public List<string> Tickets{get;set;}
        /// <summary>
        /// 需要监控的座位类型
        /// </summary>
        public List<SeatType> SeatTypies { get; set; }
        /// <summary>
        /// 需要监控的日期
        /// </summary>
        public List<DateTime> Date { get; set; }
    }
}
