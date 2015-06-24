using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.News.Models
{
    public class NewsDetailViewModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string TitleName { get; set; }
       /// <summary>
       /// 作者
       /// </summary>
        public string Author { get; set; }
       /// <summary>
       /// 标签
       /// </summary>
        public List<string> tags { get; set; }
       /// <summary>
       /// 发布时间
       /// </summary>
        public string PublishTime { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public List<CommentInfo> Comments { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string NewsContent { get; set; }
        /// <summary>
        /// 主图
        /// </summary>
        public string MainPic { get; set; }
    }
}