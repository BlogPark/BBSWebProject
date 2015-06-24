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
    }
}
