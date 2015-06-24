using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web.Models
{
    public class ReightParticalViewModel
    {
        /// <summary>
        /// 最新评论的文章记录
        /// </summary>
        public List<CommentInfo> NewComment { get; set; }
        /// <summary>
        /// 猜你喜欢的文章
        /// </summary>
        public List<CommentInfo> GetLikeArticle { get; set; }
        /// <summary>
        /// 大家都在说的文章
        /// </summary>
        public List<CommentInfo> TopComment { get; set; }
        /// <summary>
        /// 广告列表
        /// </summary>
        public List<AdvContent> AdvList { get; set; }

        public List<FriendLink> FriendLinks { get; set; }
    }
}