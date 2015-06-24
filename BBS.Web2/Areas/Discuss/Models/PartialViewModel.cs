using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.Discuss.Models
{
    public class PartialViewModel
    {
        /// <summary>
        /// 点击量最高话题
        /// </summary>
        public List<DiscussInfo> TopLickDiscuss { get; set; }
     }
}