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
    /// <summary>
    /// 讨论话题操作类
    /// </summary>
    public class DiscuessOperate
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        #region For Web2
        /// <summary>
        /// 得到最新修改的话题
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetInternetNewsForIndex(int pageindex, int pagesize)
        {
            List<DiscussInfo> result = null;
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT  *
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY UpdateTime DESC ) AS rowid ,
                    Did ,
                    Title ,
                    Dcontent ,
                    ClickCount ,
                    Dstatus ,
                    CommentCount ,
                    IsTop ,
                    AddTime ,
                    UpdateTime
          FROM      qds157425440_db.dbo.DiscussInfo WITH ( NOLOCK )
          WHERE     Dstatus = 10 AND ISNULL(IsTop,0)=0
        ) AS A
WHERE   rowid > ( @index - 1 ) * @pagesize
        AND rowid <= @index * @pagesize";
                result = conn.Query<DiscussInfo>(sqltxt, new { index = pageindex, pagesize = pagesize }).ToList<DiscussInfo>();
            }
            return result;
        }
        /// <summary>
        /// 得到最新的置顶的话题
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetTopDiscuess()
        {
            List<DiscussInfo> result = null;
            string sqltxt = @"SELECT     top 5
                    Did ,
                    Title ,
                    Dcontent ,
                    ClickCount ,
                    Dstatus ,
                    CommentCount ,
                    IsTop ,
                    AddTime ,
                    UpdateTime
          FROM      qds157425440_db.dbo.DiscussInfo WITH ( NOLOCK )
          WHERE     Dstatus = 10 AND istop=1
          ORDER BY UpdateTime DESC ";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<DiscussInfo>(sqltxt).ToList<DiscussInfo>();
            }
            return result;
        }
        /// <summary>
        /// 得到独立的讨论信息
        /// </summary>
        /// <returns></returns>
        public DiscussInfo GetDiscuessByID(int ID)
        {
            DiscussInfo info = new DiscussInfo();
            string sqltxt = @"SELECT  Did ,
        Title ,
        Dcontent ,
        ClickCount ,
        Dstatus ,
        CommentCount ,
        IsTop ,
        AddTime ,
        UpdateTime,PUserID,PuserName
FROM    qds157425440_db.dbo.DiscussInfo WITH ( NOLOCK )
WHERE   did = @id
        AND Dstatus = 10";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                info = conn.Query<DiscussInfo>(sqltxt, new { id=ID}).ToList<DiscussInfo>().FirstOrDefault();
            }
            return info;
        }
        /// <summary>
        /// 根据ID查找用户评论
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<DiscussComment> GetDiscussCommentByID(int did)
        {
            List<DiscussComment> list = new List<DiscussComment>();
            string sqltxt = @"SELECT  A.Cid ,
        A.UserName ,
        A.CContent ,
        A.SupportCount ,
        A.AgainstCount ,
        A.Cstatus ,
        A.UserID ,
        A.Did,
        b.HeadPic,
        A.AddTime
FROM    qds157425440_db.dbo.DiscussComment A WITH ( NOLOCK )
        LEFT JOIN qds157425440_db.dbo.MemberInfo B WITH ( NOLOCK ) ON A.UserID = B.mid
WHERE   Did = @id
        AND Cstatus = 1";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                list = conn.Query<DiscussComment>(sqltxt, new { id = did }).ToList<DiscussComment>();
            }
            return list;
        }
        /// <summary>
        /// 查询点击率较高的15条记录
        /// </summary>
        /// <returns></returns>
        public List<DiscussInfo> GetTopDiscuss()
        {
            List<DiscussInfo> result = new List<DiscussInfo>();
            string sqltxt = @"SELECT TOP 15
        Did ,
        Title ,
        Dcontent ,
        ClickCount ,
        Dstatus ,
        CommentCount ,
        IsTop ,
        AddTime ,
        UpdateTime ,
        PUserID ,
        PuserName
FROM    qds157425440_db.dbo.DiscussInfo WITH ( NOLOCK )
WHERE   Dstatus = 10
ORDER BY ClickCount DESC ";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<DiscussInfo>(sqltxt).ToList<DiscussInfo>();
            }
            return result;
        }
        #endregion
    }
}
