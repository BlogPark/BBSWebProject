using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS.Web.Models
{
    public class ArticleDetailViewModel
    {
        public string TitleName { get; set; }

        public string AuthorName { get; set; }
        public DateTime PublishTime { get; set; }

        public string CategoryName { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int ClickCount { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string ACountent { get; set; }
    }
}