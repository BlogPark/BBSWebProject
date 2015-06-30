using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace BBS.DAL
{
    public class BlogContentDal
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 读取博客列表
        /// </summary>
        /// <returns></returns>
        public List<MemberInfo> GetBlogMembers()
        {
            List<MemberInfo> result = new List<MemberInfo>();
            string sqltxt = @"SELECT TOP 12
        MID ,
        IsBlogUser ,
        BlogUserName ,
        BlogDecription ,
        BlogCount
FROM    qds157425440_db.dbo.MemberInfo WITH(nolock)
WHERE IsBlogUser=1 AND [Status]=20
ORDER BY blogcount DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<MemberInfo>(sqltxt).ToList<MemberInfo>();
            }
            return result;

        }

        #region For Web2
        /// <summary>
        /// 得到某个会员的所有文章列表
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<BlogContentModel> GetBlogsByMemberid(int memberid)
        {
            List<BlogContentModel> result = new List<BlogContentModel>();
            string sqltxt = @"SELECT  BID ,
        BTitleName ,
        BPublishTime ,
        BTags ,
        BMemberID ,
        BMemberName ,
        BMainPicURL ,
        BCommendCount ,
        BClickCount ,
        BDsummary ,
        BSummary ,
        BStatus ,
        BFrom ,
        BFromURL ,
        BContent ,
        BDetailText
FROM    qds157425440_db.dbo.BlogContent WITH ( NOLOCK )
WHERE   BMemberID = @id
        AND BStatus = 20";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<BlogContentModel>(sqltxt, new { id = memberid }).ToList<BlogContentModel>();
            }
            return result;
        }

        #endregion
    }
}
