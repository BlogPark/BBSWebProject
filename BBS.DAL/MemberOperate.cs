using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BBS.Model;

namespace BBS.DAL
{
    public class MemberOperate
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到每月推荐的会员
        /// </summary>
        /// <returns></returns>
        public List<MemberInfo> GetRecommendMember()
        {
            string sqltxt = @"SELECT top 5  MID ,
        Name ,
        HeadPic ,
        Email ,
        Birthday ,
        Addtime ,
        UpdateTime ,
        mURL ,
        [DESCRIPTION] ,
        sex ,
        Tags ,
        Likes ,
        IsRecommend
FROM    qds157425440_db.dbo.MemberInfo WITH ( NOLOCK )
WHERE   [Status] = 20
        AND IsRecommend = 1";
            List<MemberInfo> result = new List<MemberInfo>();
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<MemberInfo>(sqltxt).ToList<MemberInfo>();
            }
            return result;
        }

        #region For Web2
        /// <summary>
        /// 按照ID读取会员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public MemberInfo GetMemberInfoByID(int  mid)
        {
            MemberInfo info = new MemberInfo();
            string sqltxt = @"SELECT  MID ,
        Name ,
        HeadPic,
        Email ,
        Birthday
FROM    qds157425440_db.dbo.MemberInfo WITH(NOLOCK)
WHERE mid=@id";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                info = conn.Query<MemberInfo>(sqltxt, new { id=mid}).ToList<MemberInfo>().FirstOrDefault();
            }
            return info;
        }

        #endregion
    }
}
