using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.DAL;
using BBS.Model;

namespace BBS.BLL
{
   public  class ArticleOperationBll
    {
       private ArticleOperation adal = new ArticleOperation();

       /// <summary>
       /// 首页展示的文章列表
       /// </summary>
       /// <returns></returns>
       public List<ArticleInfo> GetFristPageArticles()
       {
           return adal.GetArticles();
       }
       /// <summary>
       /// 得到首页置顶的文章
       /// </summary>
       /// <returns></returns>
       public List<ArticleInfo> GetRecommonArticles()
       {
           return adal.GetRecommonArticle();
       }
       /// <summary>
       /// 得到首页顶部显示的文章
       /// </summary>
       /// <returns></returns>
       public List<ArticleInfo> GetShowTopArticles()
       {
           return adal.GetShowTopArticle();
       }
       /// <summary>
       /// 根据新闻ID查找内容
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public ArticleInfo GetArticleinfoByID(int id)
       {
           return adal.GetArticleinfoByID(id);
       }

        #region For Web2
       /// <summary>
       /// 得到互联网新闻
       /// </summary>
       /// <returns></returns>
       public List<ArticleInfo> GetInternetNewsForIndex()
       {
           return adal.GetInternetNewsForIndex();
       }
       /// <summary>
        /// 得到开发新闻
        /// </summary>
        /// <returns></returns>
       public List<ArticleInfo> GetDevelopNewsForIndex()
       {
           return adal.GetDevelopNewsForIndex();
       }
       /// <summary>
        /// 得到国内新闻
        /// </summary>
        /// <returns></returns>
       public List<ArticleInfo> GetDomesticNewsForIndex()
       {
           return adal.GetDomesticNewsForIndex();
       }
       /// <summary>
        /// 得到国际新闻
        /// </summary>
        /// <returns></returns>
       public List<ArticleInfo> GetWorldNewsForIndex()
       {
           return adal.GetWorldNewsForIndex();
       }
         /// <summary>
        /// 分页读取类别信息
        /// </summary>
        /// <param name="cateid"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
       public List<ArticleInfo> GetNewsbyCateforPage(int cateid, int pageindex)
       {
           return adal.GetNewsbyCateforPage(cateid,pageindex);
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
           return adal.InsertArticleInfo(art);
       }
        #endregion
    }
}
