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
    public class ReightSideData
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到最新的5条评论文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetNewComment()
        {
            List<CommentInfo> result = null;
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                string sqltxt = @"    SELECT TOP 5
        B.AID ,
        A.MID ,
        b.TitleName
FROM    qds157425440_db.dbo.CommentInfo A WITH ( NOLOCK )
        INNER JOIN qds157425440_db.dbo.ArticleInfo B WITH ( NOLOCK ) ON a.AID = B.AID
                                                              AND a.[Status] = 20
ORDER BY A.Addtime DESC";
                result = conn.Query<CommentInfo>(sqltxt).ToList<CommentInfo>();
            }
            return result;
        }
        /// <summary>
        /// 得到大家都在说的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetTopComment()
        {
            List<CommentInfo> result = null;
            string sqltxt = @"SELECT TOP 5
        A.AID ,
        b.TitleName,
        A.con AS Counts
FROM    ( SELECT    AID ,
                    COUNT(0) AS con
          FROM      qds157425440_db.dbo.CommentInfo WITH ( NOLOCK )
          GROUP BY  AID
        ) A
        INNER JOIN qds157425440_db.dbo.ArticleInfo B WITH ( NOLOCK ) ON a.AID = B.AID
ORDER BY A.con DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Query<CommentInfo>(sqltxt).ToList<CommentInfo>();
            }
            return result;
        }
        /// <summary>
        /// 得到猜你喜欢的文章
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetUserLikeComment()
        {
            List<CommentInfo> result = null;
            string sqltxt = @"SELECT TOP 5
        AID ,
        TitleName
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30
ORDER BY PublishTime DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Query<CommentInfo>(sqltxt).ToList<CommentInfo>();
            }
            return result;
        }
        /// <summary>
        /// 查找首页的右侧广告列表
        /// </summary>
        /// <returns></returns>
        public List<AdvContent> GetPageindexAdv()
        {
            string sqltxt = @"SELECT  A.AdvPID,A.AdvPicUrl,A.LinkToUrl,A.PicAlt,A.PicSummary,A.ContentCode,b.AdvType,b.AdvCode
FROM    qds157425440_db.dbo.AdvContent A WITH ( NOLOCK )
        INNER JOIN qds157425440_db.dbo.AdvPosition B WITH ( NOLOCK ) ON a.AdvPID = B.AID
WHERE   A.Starttime < GETDATE()
        AND GETDATE() < A.Endtime";
            List<AdvContent> result = new List<AdvContent>();
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<AdvContent>(sqltxt).ToList<AdvContent>();
            }
            return result;
        }
        /// <summary>
        /// 得到友情链接
        /// </summary>
        /// <returns></returns>
        public List<FriendLink> GetFriendLink()
        {
            List<FriendLink> result = null;
            string sqltxt = @"SELECT  ID ,
        LinkName ,
        LinkUrl ,
        LStatus ,
        ClickCount
FROM    qds157425440_db.dbo.FriendLink WITH(NOLOCK)
WHERE   LStatus = 1";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Query<FriendLink>(sqltxt).ToList<FriendLink>();
            }
            return result;
        }

        #region for web2
        /// <summary>
        /// 得到具体新闻的评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommentInfo> GetNewsCommentByNewsid(int id)
        {
            string sqltxt = @"SELECT  *
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY A.Addtime ) AS ID ,
                    A.CID ,
                    A.AID ,
                    A.MID ,
                    A.CoContent ,
                    A.Addtime ,
                    b.Name AS MemberUserName
          FROM      qds157425440_db.dbo.CommentInfo A WITH ( NOLOCK )
                    INNER JOIN qds157425440_db.dbo.MemberInfo B WITH ( NOLOCK ) ON A.MID = B.MID
          WHERE     A.[Status] = 20
                    AND A.AID = @id
        ) AS AA
ORDER BY AA.ID DESC";
            List<CommentInfo> result = new List<CommentInfo>();
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<CommentInfo>(sqltxt, new { id = id }).ToList<CommentInfo>();
            }
            return result;
        }
        /// <summary>
        /// 查询页面的阅读排行数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<ArticleInfo>> GetRankingData()
        {
            string threeday = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            string sevenday = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string thirtyday = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            Dictionary<int, List<ArticleInfo>> result = new Dictionary<int, List<ArticleInfo>>();
            List<ArticleInfo> threedaydata=new List<ArticleInfo>();
            string sqltxt = @"SELECT TOP 10
        AID ,
        TitleName 
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   PublishTime > @PublishTime
        AND Astatus = 30
ORDER BY ClickCount DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                threedaydata = conn.Query<ArticleInfo>(sqltxt, new { PublishTime = threeday }).ToList<ArticleInfo>();
            }
            result.Add(3, threedaydata);
            string ids = "";
            foreach (var item in threedaydata)
            {
                ids += item.AID + ",";
            }
            List<ArticleInfo> weekdaydata = new List<ArticleInfo>();
            sqltxt = @"SELECT TOP 10
        AID ,
        TitleName 
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   PublishTime > @PublishTime
        AND Astatus = 30
        AND AID NOT IN ("+ids.TrimEnd(',')+@")
ORDER BY ClickCount DESC ";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                weekdaydata = conn.Query<ArticleInfo>(sqltxt, new { PublishTime = sevenday }).ToList<ArticleInfo>();
            }
            result.Add(7,weekdaydata);
            foreach (var item in weekdaydata)
            {
                ids += item.AID + ",";
            }
            List<ArticleInfo> monthdata = new List<ArticleInfo>();
            sqltxt = @"SELECT TOP 10
        AID ,
        TitleName 
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   PublishTime > @PublishTime
        AND Astatus = 30
        AND AID NOT IN (" + ids.TrimEnd(',') + @")
ORDER BY ClickCount DESC ";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                monthdata = conn.Query<ArticleInfo>(sqltxt, new { PublishTime = thirtyday }).ToList<ArticleInfo>();
            }
            result.Add(30, monthdata);
            return result;
        }
        /// <summary>
        /// 得到右侧最新评论的文章信息
        /// </summary>
        /// <returns></returns>
        public List<CommentInfo> GetNewCommentforright()
        {
            List<CommentInfo> result = new List<CommentInfo>();
            string sqltxt = @"SELECT TOP 5
        A.AID ,
        CoContent ,
        B.TitleName
FROM    qds157425440_db.dbo.CommentInfo A WITH ( NOLOCK )
        INNER JOIN qds157425440_db.dbo.ArticleInfo B WITH ( NOLOCK ) ON B.AID = A.AID
                                                              AND A.Status = 20
ORDER BY A.Addtime DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<CommentInfo>(sqltxt).ToList<CommentInfo>();
            }
            return result;
        }
        /// <summary>
        /// 得到最新发表的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetLastPublish()
        {
            List<ArticleInfo> result = new List<ArticleInfo>();
            string sqltxt = @"SELECT TOP 5
        A.AID ,
        A.MainPicURL ,
        A.TitleName,A.PublishTime
FROM     qds157425440_db.dbo.ArticleInfo A WITH ( NOLOCK ) 
WHERE A.Astatus = 30
ORDER BY A.PublishTime DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
            }
            return result;
        }
        #endregion
    }
}
