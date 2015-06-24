using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.BlogPark.Models
{
    public class BlogIndexViewModel
    {
        public List<MemberInfo> BlogMembers { get; set; }
    }
}