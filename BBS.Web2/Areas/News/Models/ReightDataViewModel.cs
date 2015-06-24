using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.News.Models
{
    public class ReightDataViewModel
    {
        public List<ArticleInfo> threedayData { get; set; }
        public List<ArticleInfo> sevendayData { get; set; }
        public List<ArticleInfo> thirtydayData { get; set; }

        public List<CommentInfo> Newcomment { get; set; }

        public List<ArticleInfo> Lastpublish { get; set; }

    }
}