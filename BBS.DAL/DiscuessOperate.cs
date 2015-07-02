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
                string sqltxt = @"SELECT  IDENTITY( INT,1,1 ) AS rowid ,
        Did * 1 AS Did
INTO    #t
FROM    qds157425440_db.dbo.DiscussInfo WITH ( NOLOCK )
WHERE   Dstatus = 10
        AND ISNULL(IsTop, 0) = 0
ORDER BY UpdateTime DESC
DECLARE @rowcount INT
SET @rowcount = @@ROWCOUNT
SELECT  @rowcount AS rowco ,
        C.rowid ,
        A.Did ,
        Title ,
        Dcontent ,
        ClickCount ,
        Dstatus ,
        CommentCount ,
        IsTop ,
        AddTime ,
        UpdateTime
FROM    #t C
        INNER JOIN qds157425440_db.dbo.DiscussInfo A WITH ( NOLOCK ) ON A.Did = C.Did
                                                              AND C.rowid > ( @index
                                                              - 1 )
                                                              * @pagesize
                                                              AND C.rowid <= @index
                                                              * @pagesize";
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
                info = conn.Query<DiscussInfo>(sqltxt, new { id = ID }).ToList<DiscussInfo>().FirstOrDefault();
            }
            return info;
        }
        /// <summary>
        /// 根据ID查找用户评论
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<DiscussComment> GetDiscussCommentByID(int did, int pageindex, int pagesize)
        {
            List<DiscussComment> list = new List<DiscussComment>();
            string sqltxt = @"SELECT  IDENTITY( INT,1,1 ) AS rowid ,
        Cid * 1 AS Cid
INTO    #t
FROM    qds157425440_db.dbo.DiscussComment WITH ( NOLOCK )
WHERE   Did = @id
        AND Cstatus = 1 ORDER BY Cid asc
DECLARE @rowcount INT
SET @rowcount = @@ROWCOUNT
SELECT  @rowcount AS rowco ,
        C.rowid,
        A.Cid ,
        A.UserName ,
        A.CContent ,
        A.SupportCount ,
        A.AgainstCount ,
        A.Cstatus ,
        A.UserID ,
        A.Did ,
        b.HeadPic ,
        A.AddTime
FROM    #t C
        INNER JOIN qds157425440_db.dbo.DiscussComment A WITH ( NOLOCK ) ON A.Cid = C.Cid
                                                              AND C.rowid > ( @index
                                                              - 1 )
                                                              * @pagesize
                                                              AND C.rowid <= @index
                                                              * @pagesize
        LEFT JOIN qds157425440_db.dbo.MemberInfo B WITH ( NOLOCK ) ON A.UserID = B.mid
  ";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                list = conn.Query<DiscussComment>(sqltxt, new { id = did, index = pageindex, pagesize = pagesize }).ToList<DiscussComment>();
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
        /// <summary>
        /// 根据会员ID查找会员的话题
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public List<DiscussInfo> GetDiscussByMemberid(int memberid)
        {
            List<DiscussInfo> result = new List<DiscussInfo>();
            string sqltxt = @"SELECT  Did ,
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
WHERE   PUserID = @id
        AND Dstatus = 10";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<DiscussInfo>(sqltxt, new { id = memberid }).ToList<DiscussInfo>();
            }
            return result;
        }
        /// <summary>
        /// 发表讨论话题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDiscuss(DiscussInfo model)
        {
            string sqltxt = @"INSERT  INTO qds157425440_db.dbo.DiscussInfo
        ( Title ,
          Dcontent ,
          ClickCount ,
          Dstatus ,
          CommentCount ,
          IsTop ,
          AddTime ,
          UpdateTime ,
          PUserID ,
          PuserName
        )
VALUES  ( @Title ,
          @Dcontent ,
          0 ,
          10 ,
          0 ,
          0 ,
          GETDATE() ,
          GETDATE() ,
          @PUserID ,
          @PuserName 
        )";
            SqlParameter[] paramter = { 
                                          new SqlParameter("@Title",model.Title),
                                          new SqlParameter("@Dcontent",model.Dcontent),
                                          new SqlParameter("@PUserID",model.PUserID),
                                          new SqlParameter("@PuserName",model.PUserName)
                                      };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 添加用户评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDiscussComment(DiscussComment model)
        {
            string sqltxt = @"INSERT  INTO qds157425440_db.dbo.DiscussComment
        ( UserName ,
          CContent ,
          SupportCount ,
          AgainstCount ,
          Cstatus ,
          UserID ,
          Did ,
          AddTime
        )
VALUES  ( @UserName ,
          @CContent ,
          0 ,
          0 ,
          1 ,
          @UserID ,
          @Did ,
          GETDATE()
        )";
            SqlParameter[] paramter = { 
                                          new SqlParameter("@UserName",model.UserName),
                                          new SqlParameter("@CContent",model.CContent),
                                          new SqlParameter("@UserID",model.UserID),
                                          new SqlParameter("@Did ",model.Did)
                                      };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            if (rowcount > 0)
            {
                UpdateDiscussCommentCount(model.Did);//增加评论数
            }
            return rowcount;
        }
        /// <summary>
        /// 增加话题评论的支持数
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public int UpdateCommentSupput(int commentid)
        {
            string sqltxt = @"UPDATE  qds157425440_db.dbo.DiscussComment
SET     SupportCount = SupportCount + 1
WHERE   Cid = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", commentid) };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 增加话题评论的反对数
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public int UpdateCommentAgainstCount(int commentid)
        {
            string sqltxt = @"UPDATE  qds157425440_db.dbo.DiscussComment
SET     AgainstCount = AgainstCount + 1
WHERE   Cid = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", commentid) };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 增加话题的点击数量
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public int UpdateDiscussClickCount(int did)
        {
            string sqltxt = @"UPDATE  qds157425440_db.dbo.DiscussInfo
SET     ClickCount = ClickCount + 1
WHERE   Did = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", did) };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        /// <summary>
        /// 增加话题的评论数量
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public int UpdateDiscussCommentCount(int did)
        {
            string sqltxt = @"UPDATE  qds157425440_db.dbo.DiscussInfo
SET     CommentCount = CommentCount + 1
WHERE   Did = @id";
            SqlParameter[] paramter = { new SqlParameter("@id", did) };
            int rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion
    }
}
