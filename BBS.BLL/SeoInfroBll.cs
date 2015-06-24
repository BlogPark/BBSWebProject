using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.DAL;
using BBS.Model;

namespace BBS.BLL
{
   public   class SeoInfroBll
    {
       private SeoInfoTable dal = new SeoInfoTable();
       /// <summary>
       /// 根据页面名称查找SEO信息
       /// </summary>
       /// <param name="pagename"></param>
       /// <returns></returns>
       public SeoInfoModel Getseoinfo(string pagename)
       {
           return dal.GetPageSEOMsg(pagename);
       }
    }
}
