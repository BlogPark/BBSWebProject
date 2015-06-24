using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.DAL;
using BBS.Model;

namespace BBS.BLL
{
    public class RightSideDataBLL
    {
        private ReightSideData rdal = new ReightSideData();
        /// <summary>
        /// 得到最新评论的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetNewComment()
        {
            return rdal.GetNewComment();
        }
        /// <summary>
        /// 得到大家都在说的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetTopComment()
        {
            return rdal.GetTopComment();
        }
        /// <summary>
        /// 得到猜你喜欢的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetUserLikeComment()
        {
            return rdal.GetUserLikeComment();
        }
        /// <summary>
        /// 查找首页的右侧广告列表
        /// </summary>
        /// <returns></returns>
        public List<AdvContent> GetPageindexAdv()
        {
            return rdal.GetPageindexAdv();
        }
        /// <summary>
        /// 得到友情链接
        /// </summary>
        /// <returns></returns>
        public List<FriendLink> GetFriendLink()
        {
            return rdal.GetFriendLink();
        }
        #region for web2
         /// <summary>
        /// 得到具体新闻的评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommentInfo> GetNewsCommentByNewsid(int id)
        {
            return rdal.GetNewsCommentByNewsid(id);
        }
        /// <summary>
        /// 得到页面的阅读排行数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<ArticleInfo>> GetRankingData()
        {
            return rdal.GetRankingData();
        }
        /// <summary>
        /// 得到右侧最新评论的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetNewCommentforright() 
        {
            return rdal.GetNewCommentforright();
        }
          /// <summary>
        /// 得到最新发表的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetLastPublish()
        {
            return rdal.GetLastPublish();
        }
        #endregion
    }
}
