using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.Member.Models
{
    public class MembermsgViewModel
    {
        /// <summary>
        /// 会员信息
        /// </summary>
        public MemberInfo member { get; set; }
        /// <summary>
        /// 会员博文信息
        /// </summary>
        public List<BlogContentModel> Blogs { get; set; }
        /// <summary>
        /// 讨论话题
        /// </summary>
        public List<DiscussInfo> Discusses { get; set; }
    }
}