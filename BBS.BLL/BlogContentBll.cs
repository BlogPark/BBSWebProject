using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.DAL;
using BBS.Model;

namespace BBS.BLL
{
    public class BlogContentBll
    {
        private BlogContentDal bdal = new BlogContentDal();

         /// <summary>
        /// 读取博客列表
        /// </summary>
        /// <returns></returns>
        public List<MemberInfo> GetBlogMembers()
        {
            return bdal.GetBlogMembers();
        }
        #region  For Web2
         /// <summary>
        /// 得到某个会员的所有文章列表
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<BlogContentModel> GetBlogsByMemberid(int memberid)
        {
            return bdal.GetBlogsByMemberid(memberid);
        }
        #endregion
    }
}
