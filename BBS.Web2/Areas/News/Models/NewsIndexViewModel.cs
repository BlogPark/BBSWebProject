using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Areas.News.Models
{
    public class NewsIndexViewModel
    {
        /// <summary>
        /// 互联网新闻列表
        /// </summary>
        public List<ArticleInfo> InternetNewslist { get; set; }
        /// <summary>
        /// 开发新闻列表
        /// </summary>
        public List<ArticleInfo> DevelopNewslist { get; set; }
        /// <summary>
        /// 国内新闻列表
        /// </summary>
        public List<ArticleInfo> DomesticNewslist { get; set; }
        /// <summary>
        /// 国际新闻列表
        /// </summary>
        public List<ArticleInfo> WorldNewslist { get; set; }
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