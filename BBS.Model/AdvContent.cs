using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //广告内容表

    public class AdvContent
    {
        /// <summary>
        /// ID
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 位置ID
        /// </summary>

        public int AdvPID { get; set; }
        /// <summary>
        /// 广告内容
        /// </summary>

        public string ContentCode { get; set; }
        /// <summary>
        /// 广告图片
        /// </summary>

        public string AdvPicUrl { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>

        public DateTime Starttime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>

        public DateTime Endtime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>

        public DateTime Addtime { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>

        public int ClickCount { get; set; }
        /// <summary>
        /// 链接到地址
        /// </summary>
        public string LinkToUrl { get; set; }
        /// <summary>
        /// 图注
        /// </summary>
        public string PicAlt { get; set; }
        /// <summary>
        /// 图片摘要
        /// </summary>
        public string PicSummary { get; set; }
        /// <summary>
        /// 广告位类型（10 图  20 文  30 图文 40 列表）
        /// </summary>
        public int AdvType { get; set; }
        /// <summary>
        /// 广告位代码
        /// </summary>
        public string AdvCode { get; set; }

    }
}
