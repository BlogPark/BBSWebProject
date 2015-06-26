using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using BBS.DAL;

namespace BBS.BLL
{
  public   class HomeOperateBll
    {
      private HomeDataOperater hdal = new HomeDataOperater();
      public CategoryType GetCategoryData(int cateid)
      {
          return hdal.GetCategoryData(cateid);
      }
        #region for web2
      /// <summary>
        /// 提价留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
      public int InsertSuggest(SuggestionInfo model)
      {
          return hdal.InsertSuggest(model);
      }
        #endregion
    }
}
