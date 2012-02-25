using System;
using System.Collections.Generic;
using System.Text;

namespace DeGuangTicketsHelper.Entity
{
    /// <summary>
    /// 火车站
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 火车站
        /// </summary>
        /// <param name="pinyin">拼音</param>
        /// <param name="name">名称</param>
        /// <param name="code">代码</param>
        /// <param name="id">编号</param>
        public Station(string pinyin,string name,string code,int id)
        {
            Pinyin = pinyin;
            Name = name;
            Code = code;
            ID = id;
        }
        /// <summary>
        /// 拼音缩写
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
    }
}
