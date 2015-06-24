using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Models
{
    public class HomePageViewModel
    {
        /// <summary>
        /// 新闻列表
        /// </summary>
        public List<ArticleInfo> News { get; set; }
        /// <summary>
        /// 优秀博主
        /// </summary>
        public List<MemberInfo> MemberStar { get; set; }
        /// <summary>
        /// 讨论内容
        /// </summary>
        public string DiscussInfo { get; set; }
    }
}