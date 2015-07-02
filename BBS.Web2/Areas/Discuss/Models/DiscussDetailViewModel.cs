using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.Discuss.Models
{
    public class DiscussDetailViewModel
    {
        /// <summary>
        /// 主题信息
        /// </summary>
        public DiscussInfo Info { get; set; }
        /// <summary>
        /// 评论信息
        /// </summary>
        public List<DiscussComment> Comments { get; set; }
        /// <summary>
        /// 会员信息
        /// </summary>
        public MemberInfo MemberInfo { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageCurrent { get; set; }
    }
}