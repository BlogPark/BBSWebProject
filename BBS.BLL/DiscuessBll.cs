using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using BBS.DAL;

namespace BBS.BLL
{
    public class DiscuessBll
    {
        private DiscuessOperate dal = new DiscuessOperate();

        #region For Web2
        /// <summary>
        /// 得到最新修改的话题
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetDiscuessesForIndex(int pageindex, int pagesize)
        {
            return dal.GetInternetNewsForIndex(pageindex, pagesize);
        }
         /// <summary>
        /// 得到最新的置顶的话题
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetTopDiscuess()
        {
            return dal.GetTopDiscuess();
        }
         /// <summary>
        /// 得到独立的讨论信息
        /// </summary>
        /// <returns></returns>
        public DiscussInfo GetDiscuessByID(int ID)
        {
            return dal.GetDiscuessByID(ID);
        }
        /// <summary>
        /// 根据ID查找用户评论
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<DiscussComment> GetDiscussCommentByID(int did)
        {
            return dal.GetDiscussCommentByID(did);
        }
         /// <summary>
        /// 查询点击率较高的15条记录
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetTopDiscuss()
        {
            return dal.GetTopDiscuss();
        }
         /// <summary>
        /// 根据会员ID查找会员的话题
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<DiscussInfo> GetDiscussByMemberid(int memberid)
        {
            return dal.GetDiscussByMemberid(memberid);
        }
        /// <summary>
        /// 发表讨论话题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDiscuss(DiscussInfo model)
        {
            return dal.AddDiscuss(model);
        }
          /// <summary>
        /// 添加用户评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDiscussComment(DiscussComment model)
        {
            return dal.AddDiscussComment(model);
        }
         /// <summary>
        /// 增加话题评论的支持数
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public int UpdateCommentSupput(int commentid)
        {
            return dal.UpdateCommentSupput(commentid);
        }
        /// <summary>
        /// 增加话题评论的反对数
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public int UpdateCommentAgainstCount(int commentid)
        {
            return dal.UpdateCommentAgainstCount(commentid);
        }
        /// <summary>
        /// 增加话题的点击数量
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public int UpdateDiscussClickCount(int did)
        {
            return dal.UpdateDiscussClickCount(did);
        }
        /// <summary>
        /// 增加话题的评论数量
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public int UpdateDiscussCommentCount(int did)
        {
            return dal.UpdateDiscussCommentCount(did);
        }
        #endregion
    }
}
