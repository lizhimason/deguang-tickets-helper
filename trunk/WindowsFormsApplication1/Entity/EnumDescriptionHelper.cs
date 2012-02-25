using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 枚举描述
    /// </summary>
    public class SeatTypeDescriptionHelper
    {
        private static Dictionary<SeatType, string> description;
        public static Dictionary<SeatType, string> Description
        {
            get
            {
                if (description == null)
                {
                    description = new Dictionary<SeatType, string>();
                    description.Add(SeatType.BusinessBlock, "商务座");
                    description.Add(SeatType.PrincipalSeat, "特等座");
                    description.Add(SeatType.FirstClassSeat, "一等座");
                    description.Add(SeatType.SecondClassSeat, "二等座");
                    description.Add(SeatType.AdvancedSoftSleeper, "高级软卧");
                    description.Add(SeatType.SoftSleeper, "软卧");
                    description.Add(SeatType.HardSleeper, "硬卧");
                    description.Add(SeatType.SoftSeat, "软座");
                    description.Add(SeatType.HardSeat, "硬座");
                    description.Add(SeatType.NoSeat, "无座");
                    description.Add(SeatType.Other, "其他");
                }
                return description;
            }
        }
    }
}
