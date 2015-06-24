using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string iconname { get; set; }
        public List<ArticleInfo> Articles { get; set; }
    }
}