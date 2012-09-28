using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryTicketParam
    {
        /// <summary>
        /// 查询车票参数类
        /// </summary>
        /// <param name="trainDate">列车日期</param>
        /// <param name="formstationtelecode">出发站</param>
        /// <param name="tostationtelecode">目的站</param>
        /// <param name="trainno">列车编号</param>
        /// <param name="trainPassType">列车类型</param>
        /// <param name="trainClass">席别</param>
        /// <param name="startTimeStr">时间范围</param>
        public QueryTicketParam(string trainDate, 
            string formstationtelecode, 
            string tostationtelecode, 
            string trainno, 
            string trainPassType,
            string trainClass, 
            string startTimeStr)
        {
            TrainDate = trainDate;
            FormStationTelecode = formstationtelecode;
            ToStationTelecode = tostationtelecode;
            TrainNo = trainno;
            TrainPassType = trainPassType;
            TrainClass = trainClass;
            StartTimeStr = startTimeStr;
        }
        /// <summary>
        /// 列车日期
        /// </summary>
        public string TrainDate { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        public string FormStationTelecode { get; set; }
        /// <summary>
        /// 目的站
        /// </summary>
        public string ToStationTelecode { get; set; }
        /// <summary>
        /// 列车编号
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 列车类型
        /// </summary>
        public string TrainPassType { get; set; }
        /// <summary>
        /// 席别
        /// </summary>
        public string TrainClass { get; set; }
        /// <summary>
        /// 列车时间段
        /// </summary>
        public string StartTimeStr { get;set; }
        private TicketInfo ticketInfo;
        /// <summary>
        /// 列车信息
        /// </summary>
        public TicketInfo TicketInfo
        {
            get
            {
                return ticketInfo;
            }
            set
            {
                ticketInfo = value;
                TrainNo = ticketInfo.TrainNo;
            }
        }

        public override string ToString()
        {
            return TrainDate+" "+TicketInfo.StationTrainCode+":"+TicketInfo.DepartureStation+">"+TicketInfo.DestinationStation;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return false;
            }
            QueryTicketParam queryTicketParam = obj as QueryTicketParam;
            return TrainDate == queryTicketParam.TrainDate &&
                TicketInfo.TrainNo == queryTicketParam.TicketInfo.TrainNo;
        }
    }
}
