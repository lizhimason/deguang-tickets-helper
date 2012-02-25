using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 座位类型
    /// </summary>
    public enum SeatType
    {
        /// <summary>
        /// 商务
        /// </summary>
        BusinessBlock,
        /// <summary>
        /// 特等
        /// </summary>
        PrincipalSeat,
        /// <summary>
        /// 一等
        /// </summary>
        FirstClassSeat,
        /// <summary>
        /// 二等
        /// </summary>
        SecondClassSeat,
        /// <summary>
        /// 高级软卧
        /// </summary>
        AdvancedSoftSleeper,
        /// <summary>
        /// 软卧
        /// </summary>
        SoftSleeper,
        /// <summary>
        /// 硬卧
        /// </summary>
        HardSleeper,
        /// <summary>
        /// 软座
        /// </summary>
        SoftSeat,
        /// <summary>
        /// 硬座
        /// </summary>
        HardSeat,
        /// <summary>
        /// 无座
        /// </summary>
        NoSeat,
        /// <summary>
        /// 其他
        /// </summary>
        Other,
    }
}
