using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.News.Models
{
    public class CatePageViewModel
    {
        public List<ArticleInfo> News { get; set; }
        public int TotalPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int Pagecount { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageCurrent { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }

    }
}