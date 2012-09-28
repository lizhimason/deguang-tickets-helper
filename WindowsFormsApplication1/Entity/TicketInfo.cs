using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 列车车票数量信息
    /// </summary>
    public class TicketInfo
    {
        /// <summary>
        /// 选择
        /// </summary>
        public bool Selected { get; set; }    
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string StationTrainCode { get; set; }
        /// <summary>
        /// 发站
        /// </summary>
        public string DepartureStation { get; set; }
        /// <summary>
        /// 开车时间
        /// </summary>
        public string DrivingTime { get; set; }
        /// <summary>
        /// 到站
        /// </summary>
        public string DestinationStation { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string ArrivalTime { get; set; }
        /// <summary>
        /// 历时
        /// </summary>
        public string ElapsedTime { get; set; }
        /// <summary>
        /// 座位信息
        /// </summary>
        public Dictionary<SeatType, int> SeetInfos { get; set; }

        #region 各类座位信息
        string businessBlock;
        /// <summary>
        /// 商务
        /// </summary>
        public string BusinessBlock
        {
            get
            {
                return businessBlock;
            }
            set
            {
                if (businessBlock != value)
                {
                    businessBlock = value;
                    UpdateSeatInfo(SeatType.BusinessBlock, value);
                }
            }
        }
        string principalSeat;
        /// <summary>
        /// 特等
        /// </summary>
        public string PrincipalSeat
        {
            get
            {
                return principalSeat;
            }
            set
            {
                if (principalSeat != value)
                {
                    principalSeat = value;
                    UpdateSeatInfo(SeatType.PrincipalSeat, value);
                }
            }
        }
        string firstClassSeat;
        /// <summary>
        /// 一等
        /// </summary>
        public string FirstClassSeat
        {
            get
            {
                return firstClassSeat;
            }
            set
            {
                if (firstClassSeat != value)
                {
                    firstClassSeat = value;
                    UpdateSeatInfo(SeatType.FirstClassSeat, value);
                }
            }
        }
        string secondClassSeat;
        /// <summary>
        /// 二等
        /// </summary>
        public string SecondClassSeat
        {
            get
            {
                return secondClassSeat;
            }
            set
            {
                if (secondClassSeat != value)
                {
                    secondClassSeat = value;
                    UpdateSeatInfo(SeatType.SecondClassSeat, value);
                }
            }
        }
        string advancedSoftSleeper;
        /// <summary>
        /// 高级软卧
        /// </summary>
        public string AdvancedSoftSleeper
        {
            get
            {
                return advancedSoftSleeper;
            }
            set
            {
                if (advancedSoftSleeper != value)
                {
                    advancedSoftSleeper = value;
                    UpdateSeatInfo(SeatType.AdvancedSoftSleeper, value);
                }
            }
        }
        string softSleeper;
        /// <summary>
        /// 软卧
        /// </summary>
        public string SoftSleeper
        {
            get
            {
                return softSleeper;
            }
            set
            {
                if (softSleeper != value)
                {
                    softSleeper = value;
                    UpdateSeatInfo(SeatType.SoftSleeper, value);
                }
            }
        }
        string hardSleeper;
        /// <summary>
        /// 硬卧
        /// </summary>
        public string HardSleeper
        {
            get
            {
                return hardSleeper;
            }
            set
            {
                if (hardSleeper != value)
                {
                    hardSleeper = value;
                    UpdateSeatInfo(SeatType.HardSleeper, value);
                }
            }
        }
        string softSeat;
        /// <summary>
        /// 软座
        /// </summary>
        public string SoftSeat
        {
            get
            {
                return softSeat;
            }
            set
            {
                if (softSeat != value)
                {
                    softSeat = value;
                    UpdateSeatInfo(SeatType.SoftSeat, value);
                }
            }
        }
        string hardSeat;
        /// <summary>
        /// 硬座
        /// </summary>
        public string HardSeat
        {
            get
            {
                return hardSeat;
            }
            set
            {
                if (hardSeat != value)
                {
                    hardSeat = value;
                    UpdateSeatInfo(SeatType.HardSeat, value);
                }
            }
        }
        string noSeat;
        /// <summary>
        /// 无座
        /// </summary>
        public string NoSeat
        {
            get
            {
                return noSeat;
            }
            set
            {
                if (noSeat != value)
                {
                    noSeat = value;
                    UpdateSeatInfo(SeatType.NoSeat, value);
                }
            }
        }
        string other;
        /// <summary>
        /// 其他
        /// </summary>
        public string Other
        {
            get
            {
                return other;
            }
            set
            {
                if (other != value)
                {
                    other = value;
                    UpdateSeatInfo(SeatType.Other, value);
                }
            }
        }
        #endregion

        private string jsInfoString;
        /// <summary>
        /// 页面中预订按钮点击时JS包含的信息,用于预订车票 
        /// javascript:getSelected('2102#01:07#09:02#150000210602#TAP#VAP#10:09#通州西#北京北#1001100276300620000340094000091001103424')
        /// </summary>
        public string JsInfoString
        {
            get
            {
                return jsInfoString;
            }
            set
            {
                if (jsInfoString != value)
                {
                    jsInfoString = value;
                    string[] infos = jsInfoString.Split('#');
                    TrainDate = infos[1];
                    TrainNo = infos[1+3];
                    DepartureStationTelCode = infos[1+4];
                    DestinationStationTelCode = infos[1+5];
                    InfoDetail = infos[1+9];
                    MmStr = infos[1+10];
                }
            }
        }

        #region 从jsInfo中得到的属性
        /// <summary>
        /// 列车编号
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 列车日期
        /// </summary>
        public string TrainDate { get; set; }
        /// <summary>
        /// 发站编号
        /// </summary>
        public string DepartureStationTelCode { get; set; }
        /// <summary>
        /// 到站编号
        /// </summary>
        public string DestinationStationTelCode { get; set; }
        /// <summary>
        /// ypInfoDetail
        /// </summary>
        public string InfoDetail { get; set; }
        /// <summary>
        /// mmStr
        /// </summary>
        public string MmStr { get; set; }
        #endregion

        /// <summary>
        /// 更新剩余票信息
        /// </summary>
        /// <param name="seatType"></param>
        /// <param name="value"></param>
        private void UpdateSeatInfo(SeatType seatType, string value)
        {
            int seatCount;
            if (Int32.TryParse(value,out seatCount)==false)
            {
                if (value == "有")
                {
                    seatCount = int.MaxValue;
                }
                else
                {
                    seatCount = 0;
                }
            }
            if (SeetInfos == null)
            {
                SeetInfos = new Dictionary<SeatType, int>();
            }
            if (SeetInfos.ContainsKey(seatType) == true)
            {
                if (SeetInfos[seatType] != seatCount)
                {
                    SeetInfos[seatType] = seatCount;
                }
            }
            else
            {
                SeetInfos.Add(seatType, seatCount);
            }
        }
        /// <summary>
        /// 有票
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                bool result=false;
                foreach (var item in SeetInfos)
                {
                    if (item.Value > 0)
                    {
                        result= true;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 有票
        /// </summary>
        /// <param name="seatType"></param>
        /// <returns></returns>
        public bool IsAvailable_Seat(params SeatType[] seatType)
        {
            bool result = false;
            if (seatType == null || seatType.Length == 0)
            {

            }
            else
            {
                foreach (var item in SeetInfos)
                {
                    if (Array.IndexOf(seatType,item.Key)!=-1&&item.Value > 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
