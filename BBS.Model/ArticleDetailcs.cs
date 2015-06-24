using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //文章明细

    public class ArticleDetail
    {
        /// <summary>
        /// 文章ID
        /// </summary>

        public int AID { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>

        public int CategoryID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>

        public string CategoryName { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>

        public string AContent { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>

        public string Summary { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>

        public string Authorname { get; set; }
        public string ADetailtext { get; set; }

    }
}
