using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace BBS.DAL
{
    public class BlogContentDal
    {
        private readonly string sqlconnectstr = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        DbHelperSQL helper = new DbHelperSQL();
        /// <summary>
        /// 读取博客列表
        /// </summary>
        /// <returns></returns>
        public List<MemberInfo> GetBlogMembers()
        {
            List<MemberInfo> result = new List<MemberInfo>();
            string sqltxt = @"SELECT TOP 12
        MID ,
        IsBlogUser ,
        BlogUserName ,
        BlogDecription ,
        BlogCount
FROM    qds157425440_db.dbo.MemberInfo WITH(nolock)
WHERE IsBlogUser=1 AND [Status]=20
ORDER BY blogcount DESC";
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                result = conn.Query<MemberInfo>(sqltxt).ToList<MemberInfo>();
            }
            return result;

        }
    }
}
