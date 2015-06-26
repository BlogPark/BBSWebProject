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
    /// 首页数据操作类
    /// </summary>
    public class HomeDataOperater
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 得到分类以及文章
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public CategoryType GetCategoryData(int cateid)
        {
            CategoryType model = new CategoryType();
            string sqltxt = @"SELECT  id ,
        CategoryName ,
        Status,iconname
FROM    qds157425440_db.dbo.CategoryType WITH(NOLOCK) WHERE ID=@id";
            SqlParameter[] paramter = { new SqlParameter("@id", cateid) };
            DataSet ds = helper.Query(sqltxt, paramter);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                    model.Iconname = ds.Tables[0].Rows[0]["iconname"].ToString();
                }
                else
                {
                    return null;
                }
            }
            sqltxt = @"SELECT  AID ,
        TitleName ,      
        DSummary,AuthorName,PublishTime,MainPicURL
FROM    qds157425440_db.dbo.ArticleInfo WITH(NOLOCK)
WHERE CategoryID=@cateid AND Astatus=30";
            List<ArticleInfo> result = null;
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Query<ArticleInfo>(sqltxt, new { cateid = cateid }).ToList<ArticleInfo>();
            }
            model.Articles = result;
            return model;
        }

        #region for web2
        /// <summary>
        /// 提价留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSuggest(SuggestionInfo model)
        {
            string sqltxt = @"INSERT  INTO qds157425440_db.dbo.SuggestionInfo
        ( SUserID ,
          SUserName ,
          STitle ,
          SContent ,
          SStatus 
        )
VALUES  ( @SUserID ,
          @SUserName ,
          @STitle ,
          @SContent ,
          10
        )";
            int result = 0;
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                result = conn.Execute(sqltxt, new { SUserID = model.SUserID, SUserName = model.SUserName, STitle = model.STitle, SContent = model.SContent });
            }
            return result;
        }
        #endregion
    }
}
