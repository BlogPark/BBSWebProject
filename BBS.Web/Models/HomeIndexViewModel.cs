using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web.Models
{
    public class HomeIndexViewModel
    {
        /// <summary>
        /// 文章列表
        /// </summary>
        public List<ArticleInfo> ArticleInfolist { get; set; }

        /// <summary>
        /// 广告列表
        /// </summary>
        public List<AdvContent> Advlist { get; set; }
        /// <summary>
        /// 推荐文章列表
        /// </summary>
        public List<ArticleInfo> RecommendArticlelist { get; set; }
        /// <summary>
        /// 置顶文章列表
        /// </summary>
        public List<ArticleInfo> TopArticlelist { get; set; }
        /// <summary>
        /// 友情链接列表
        /// </summary>
        public List<FriendLink> FriendLinklist { get; set; }
        /// <summary>
        /// 猜你喜欢文章列表
        /// </summary>
        public List<ArticleInfo> GuessLikeArticlelist { get; set; }
    }
}