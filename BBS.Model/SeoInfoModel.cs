using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    public  class SeoInfoModel
    {
        /// <summary>
        /// ID
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 页面名称
        /// </summary>

        public string PName { get; set; }
        /// <summary>
        /// 页面关键词
        /// </summary>

        public string KeyWord { get; set; }
        /// <summary>
        /// 页面描述
        /// </summary>

        public string PDescription { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>

        public int PStatus { get; set; }
        /// <summary>
        /// 页面标题
        /// </summary>

        public string PTitle { get; set; }
    }
}
