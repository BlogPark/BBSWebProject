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
    /// 文章操作类
    /// </summary>
    public class ArticleOperation
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        #region For Web
        /// <summary>
        /// 查询前100文章列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<ArticleInfo> GetArticles()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                //                string sqltxt = @"SELECT  AID ,
                //        TitleName ,
                //        AuthorName ,
                //        PublishTime ,
                //        Astatus ,
                //        MainPicURL ,
                //        PicWidth ,
                //        PicHeight ,
                //        Tags ,
                //        DSummary
                //FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ID ASC ) AS rowid ,
                //                    AID ,
                //                    TitleName ,
                //                    AuthorName ,
                //                    PublishTime ,
                //                    Astatus ,
                //                    MainPicURL ,
                //                    PicWidth ,
                //                    PicHeight ,
                //                    Tags ,
                //                    DSummary
                //          FROM      qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
                //          WHERE     Astatus = 30
                //        ) AS A
                //WHERE   A.rowid > ( @pageindex - 1 ) * @pagesize
                //        AND A.rowid <= @pageindex * @pagesize";
                string sqltxt = @"SELECT TOP 100
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 得到首页置顶文章
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetRecommonArticle()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 5
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30
ORDER BY ClickCount DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 得到首页顶部显示的文章
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetShowTopArticle()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 7
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30 AND IsTop=1
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 根据ID查找文章
        /// </summary>
        /// <param name="artid"></param>
        /// <returns></returns>
        public ArticleInfo GetArticleinfoByID(int artid)
        {
            ArticleInfo model = new ArticleInfo();
            string sqltxt = @"SELECT  AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary ,
        ClickCount ,
        IsTop ,
        SourceUrl ,
        AFrom
FROM    qds157425440_db.dbo.ArticleInfo WITH(NOLOCK)
WHERE AID=@id AND Astatus=30";
            SqlParameter[] paramter = { new SqlParameter("@id", artid) };
            DataSet ds = helper.Query(sqltxt, paramter);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.AID = int.Parse(ds.Tables[0].Rows[0]["AID"].ToString());
                    model.TitleName = ds.Tables[0].Rows[0]["TitleName"].ToString();
                    model.ViceTitleName = ds.Tables[0].Rows[0]["ViceTitleName"].ToString();
                    model.AuthorID = int.Parse(ds.Tables[0].Rows[0]["AuthorID"].ToString());
                    model.AuthorName = ds.Tables[0].Rows[0]["AuthorName"].ToString();
                    model.PublishTime = DateTime.Parse(ds.Tables[0].Rows[0]["PublishTime"].ToString());
                    model.Astatus = int.Parse(ds.Tables[0].Rows[0]["Astatus"].ToString());
                    model.MainPicURL = ds.Tables[0].Rows[0]["MainPicURL"].ToString();
                    model.PicWidth = int.Parse(ds.Tables[0].Rows[0]["PicWidth"].ToString());
                    model.PicHeight = int.Parse(ds.Tables[0].Rows[0]["PicHeight"].ToString());
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                    model.Updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["Updatetime"].ToString());
                    model.CategoryID = int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                    model.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                    model.DSummary = ds.Tables[0].Rows[0]["DSummary"].ToString();
                    model.ClickCount = int.Parse(ds.Tables[0].Rows[0]["ClickCount"].ToString());
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                    model.SourceUrl = ds.Tables[0].Rows[0]["SourceUrl"].ToString();
                    model.AFrom = ds.Tables[0].Rows[0]["AFrom"].ToString();
                }
                else
                { return null; }
            }
            sqltxt = @"SELECT  AID ,
        CategoryID ,
        CategoryName ,
        AContent ,
        Summary ,
        Authorname ,
        ADetailtext
FROM    qds157425440_db.dbo.ArticleDetail WITH(NOLOCK)
WHERE AID=@id";
            ds = helper.Query(sqltxt, paramter);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArticleDetail details = new ArticleDetail();
                    details.AID = int.Parse(ds.Tables[0].Rows[0]["AID"].ToString());
                    details.AContent = ds.Tables[0].Rows[0]["AContent"].ToString();
                    details.Authorname = ds.Tables[0].Rows[0]["Authorname"].ToString();
                    details.CategoryID = int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                    details.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                    details.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                    details.ADetailtext = ds.Tables[0].Rows[0]["ADetailtext"].ToString();
                    model.Details = details;
                }
            }
            return model;
        }
        #endregion
        #region For Web2
        /// <summary>
        /// 得到互联网新闻
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetInternetNewsForIndex()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 8
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30 AND  CategoryID=1
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 得到开发新闻
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetDevelopNewsForIndex()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 8
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30 AND  CategoryID=2
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 得到国内新闻
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetDomesticNewsForIndex()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 8
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30 AND  CategoryID=3
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 得到国际新闻
        /// </summary>
        /// <returns></returns>
        public List<ArticleInfo> GetWorldNewsForIndex()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"SELECT TOP 8
        AID ,
        TitleName ,
        ViceTitleName ,
        AuthorID ,
        AuthorName ,
        PublishTime ,
        Astatus ,
        MainPicURL ,
        PicWidth ,
        PicHeight ,
        Addtime ,
        Updatetime ,
        CategoryID ,
        CategoryName ,
        Tags ,
        Summary ,
        DSummary,
        ClickCount
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   Astatus = 30 AND  CategoryID=4
ORDER BY PublishTime DESC";
                List<ArticleInfo> result = conn.Query<ArticleInfo>(sqltxt).ToList<ArticleInfo>();
                return result;
            }
        }
        /// <summary>
        /// 分页读取类别信息
        /// </summary>
        /// <param name="cateid"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<ArticleInfo> GetNewsbyCateforPage(int cateid, int pageindex)
        {
            string sqltxt = @"DECLARE @rowcount INT         
SELECT  IDENTITY( INT,1,1 ) AS id ,
        AID * 1 AS aid
INTO    #t
FROM    qds157425440_db.dbo.ArticleInfo WITH ( NOLOCK )
WHERE   CategoryID = @cateid
        AND Astatus = 30   ORDER BY PublishTime DESC
SET @rowcount = @@ROWCOUNT
SELECT  @rowcount AS totalc,
        B.AID ,
        B.TitleName ,
        B.ViceTitleName ,
        B.AuthorID ,
        B.AuthorName ,
        B.PublishTime ,
        B.Astatus ,
        B.MainPicURL ,
        B.PicWidth ,
        B.PicHeight ,
        B.Addtime ,
        B.Updatetime ,
        B.CategoryID ,
        B.CategoryName ,
        B.Tags ,
        B.Summary ,
        B.DSummary ,
        B.ClickCount ,
        B.IsTop ,
        B.SourceUrl ,
        B.AFrom
FROM    #t A
        INNER JOIN qds157425440_db.dbo.ArticleInfo B WITH ( NOLOCK ) ON B.AID = A.aid
                                                              AND A.id > ( @index
                                                              - 1 ) * 8
                                                              AND A.id <= @index
                                                              * 8 ";
            List<ArticleInfo> result = new List<ArticleInfo>();
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Query<ArticleInfo>(sqltxt, new { cateid = cateid, index = pageindex }).ToList<ArticleInfo>();

            }
            return result;
        }
        #endregion

        #region For Admin
        /// <summary>
        /// 插入文章信息
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public int InsertArticleInfo(ArticleInfo art)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO qds157425440_db.dbo.ArticleInfo
        ( TitleName ,
          ViceTitleName ,
          AuthorID ,
          AuthorName ,
          PublishTime ,
          Astatus ,
          MainPicURL ,
          PicWidth ,
          PicHeight ,
          Addtime ,
          Updatetime ,
          CategoryID ,
          CategoryName ,
          Tags ,
          Summary ,
          DSummary ,
          ClickCount ,
          IsTop ,
          SourceUrl ,
          AFrom ,
          CommentCount
        )
VALUES  ( @TitleName ,
          @ViceTitleName ,
          @AuthorID ,
          @AuthorName ,
          GETDATE() ,
          30 ,
          @MainPicURL ,
          @PicWidth ,
          @PicHeight ,
          GETDATE() ,
          GETDATE() ,
          @CategoryID ,
          @CategoryName ,
          @Tags ,
          @Summary ,
          @DSummary ,
          0 ,
          0 ,
          @SourceUrl ,
          @AFrom ,
          0
        );SELECT @@IDENTITY";
            SqlParameter[] paramter = { 
                                          new SqlParameter("@TitleName",art.TitleName),
                                          new SqlParameter("@ViceTitleName",art.ViceTitleName),
                                          new SqlParameter("@AuthorID",art.AuthorID),
                                          new SqlParameter("@AuthorName",art.AuthorName),
                                          new SqlParameter("@MainPicURL",art.MainPicURL),
                                          new SqlParameter("@PicWidth",art.PicWidth),
                                          new SqlParameter("@PicHeight",art.PicHeight),
                                          new SqlParameter("@CategoryID",art.CategoryID),
                                          new SqlParameter("@CategoryName",art.CategoryName),
                                          new SqlParameter("@Tags",art.Tags),
                                          new SqlParameter("@Summary",art.Summary),
                                          new SqlParameter("@DSummary",art.DSummary),
                                          new SqlParameter("@SourceUrl",art.SourceUrl),
                                          new SqlParameter("@AFrom",art.AFrom)
                                      };
            object k = helper.GetSingle(sqltxt, paramter);
            if (k!=null)
            {
                int aid = int.Parse(k.ToString());
                if (aid > 0)
                { 
                    art.Details.AID = aid;
                    rowcount = InsertArticleDetail(art.Details);
                }
            }
            return rowcount;
        }
        /// <summary>
        /// 插入文章明细
        /// </summary>
        /// <param name="artdetail"></param>
        /// <returns></returns>
        public int InsertArticleDetail(ArticleDetail artdetail)
        {
            int rowcount = 0;
            string sqltxt = @"INSERT  INTO qds157425440_db.dbo.ArticleDetail
        ( AID ,
          CategoryID ,
          CategoryName ,
          AContent ,
          Summary ,
          Authorname ,
          ADetailtext
        )
VALUES  ( @AID ,
          @CategoryID ,
          @CategoryName ,
          @AContent ,
          @Summary ,
          @Authorname ,
          @ADetailtext
        )";
            SqlParameter[] paramter = { 
                                      new SqlParameter("@AID",artdetail.AID),
                                      new SqlParameter("@CategoryID",artdetail.CategoryID),
                                      new SqlParameter("@CategoryName",artdetail.CategoryName),
                                      new SqlParameter("@AContent",artdetail.AContent),
                                      new SqlParameter("@Summary",artdetail.Summary),
                                      new SqlParameter("@Authorname",artdetail.Authorname),
                                      new SqlParameter("@ADetailtext",artdetail.ADetailtext)
                                      };
            rowcount = helper.ExecuteSql(sqltxt, paramter);
            return rowcount;
        }
        #endregion
    }
}
