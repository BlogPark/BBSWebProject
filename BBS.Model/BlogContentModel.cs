using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
   public class BlogContentModel
    {
        /// <summary>
        /// ID
        /// </summary>

        public int BID { get; set; }
        /// <summary>
        /// BTitleName
        /// </summary>

        public string BTitleName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>

        public DateTime BPublishTime { get; set; }
        /// <summary>
        /// 标签
        /// </summary>

        public string BTags { get; set; }
        /// <summary>
        /// 博主ID
        /// </summary>

        public int BMemberID { get; set; }
        /// <summary>
        /// 博主名称
        /// </summary>

        public string BMemberName { get; set; }
        /// <summary>
        /// 主图URL
        /// </summary>

        public string BMainPicURL { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>

        public int BCommendCount { get; set; }
        /// <summary>
        /// 点击数量
        /// </summary>

        public int BClickCount { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>

        public string BDsummary { get; set; }
        /// <summary>
        /// 描述
        /// </summary>

        public string BSummary { get; set; }
        /// <summary>
        /// 状态（10 未审核 20 已审核）
        /// </summary>

        public int BStatus { get; set; }
        /// <summary>
        /// 来源
        /// </summary>

        public string BFrom { get; set; }
        /// <summary>
        /// 来源URL
        /// </summary>

        public string BFromURL { get; set; }
        /// <summary>
        /// 内容
        /// </summary>

        public string BContent { get; set; }
        /// <summary>
        /// 内容文本
        /// </summary>

        public string BDetailText { get; set; }
    }
}
