using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using BBS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace BBS.BLL
{
    public class MemberOperaterBll
    {
        private MemberOperate dal = new MemberOperate();
       /// <summary>
        /// 得到每月推荐的会员
        /// </summary>
        /// <returns></returns>
        public List<MemberInfo> GetRecommendMember()
        {
            return dal.GetRecommendMember();
        }
          #region For Web2
        /// <summary>
        /// 按照ID读取会员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public MemberInfo GetMemberInfoByID(int mid)
        {
            return dal.GetMemberInfoByID(mid);
        }
        /// <summary>
        /// 根据会员名称或邮箱和密码得到会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MemberInfo GetMemberInfo(MemberInfo model)
        {
            return dal.GetMemberInfo(model);
        }
          #endregion
    }
}
