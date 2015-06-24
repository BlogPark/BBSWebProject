using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.Discuss.Models
{
    public class DiscuessIndexViewModel
    {
        /// <summary>
        /// 话题列表
        /// </summary>
        public List<DiscussInfo> dislist { get; set; }
        /// <summary>
        /// 置顶列表
        /// </summary>
        public List<DiscussInfo> toplist { get; set; }
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
        public int PageSize {get;set; }
    }
}