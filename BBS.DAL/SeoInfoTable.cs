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
    public  class SeoInfoTable
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();

        public SeoInfoModel GetPageSEOMsg(string pagename)
        {
            SeoInfoModel result = null;
            string sqltxt = @"SELECT  ID ,
        PName ,
        KeyWord ,
        PDescription ,
        PStatus ,
        PTitle
FROM    qds157425440_db.dbo.SEOInfo WITH ( NOLOCK )
WHERE   pname = @name AND PStatus=1";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<SeoInfoModel>(sqltxt, new { name = pagename }).ToList<SeoInfoModel>().FirstOrDefault();
            }
            return result;
        }
    }
}
