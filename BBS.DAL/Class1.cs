using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BBSProject.DataModel.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BBS.DAL
{
    /// <summary>
    /// Dapper 示例类
    /// </summary>
    public class Class1
    {

        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";

        //public  SqlConnection GetOpenConnection(bool mars = false)
        //{
        //    var cs = sqlconnectstr;
        //    if (mars)
        //    {
        //        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(cs);
        //        scsb.MultipleActiveResultSets = true;
        //        cs = scsb.ConnectionString;
        //    }
        //    var connection = new SqlConnection(cs);
        //    connection.Open();
        //    return connection;
        //}
        /// <summary>
        /// 查询单表数据时
        /// </summary>
        /// <returns></returns>
//        public IEnumerable<AdvertInfo> GetAllAvertInfo()
//        {
//            using (IDbConnection conn = new SqlConnection(sqlconnectstr))
//            {
//                conn.Open();

//                string sqltxt = @"SELECT  ID ,
//        AdvertPositionID ,
//        AdvertTip ,
//        AdvertFileName ,
//        AdvertFilePath ,
//        AdvertClickCount
//FROM    BBSProData.dbo.bbs_AdvertInfo";
//                var co = conn.QueryAsync<AdvertInfo>(sqltxt).Result.ToList<AdvertInfo>();
//                return co;
//            }
//        }
//        /// <summary>
//        /// 带参数的写法
//        /// </summary>
//        public void GetdataWIthParamter()
//        {
//            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
//            {
//                conn.Open();
//                string sqltxt = @"select * from  BBSProData.dbo.bbs_AdvertInfo where ID=@id";
//                var result = conn.QueryAsync<AdvertInfo>(sqltxt, new { id = 1 });
//            }
//        }
//        /// <summary>
//        /// 填充复杂实体
//        /// </summary>
//        public void GetOneMoreData()
//        {
//            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
//            {
//                conn.Open();
//                string sqltxt = @"SELECT  A.NewsID ,
//        NewsTitle ,
//        NewsPublisher ,
//        NewsReceiver ,
//        NewsReaded ,
//        NewsStatus ,
//        NewsPublishTime ,
//        NewsReadedTime ,
//        B.NewsContent
//FROM    BBSProData.dbo.bbs_MemberNews AS A
//        INNER JOIN BBSProData.dbo.bbs_MemberNewsDetail B WITH ( NOLOCK ) ON A.NewsID = B.NewsID
//                                                              AND A.NewsID = @id";
//                // conn.Query<Column, ColumnCat, Column>(query

//                //, (column, columncat) => { column.ColumnCat = columncat; return column; }

//                //, null, null, false, "Id", null, null).ToList<Column>();
//                var result = conn.QueryAsync<MemberNewsVO, MemberNewsDetail, MemberNewsVO>(sqltxt, (membernewsvo, membernewsdetail) => { membernewsvo.details = membernewsdetail; return membernewsvo; }, new { id = 1 }, null, false, "NewsContent", null, null).Result.ToList<MemberNewsVO>();
//            }
//        }
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        public void GetRowcount()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                string sqltxt = @"Update BBSProData.dbo.bbs_AdvertInfo set AdvertTip=@adverttip where ID=@id";
                int result = conn.Execute(sqltxt, new { adverttip = "ssss", id = 1 });
            }
        }
        /// <summary>
        /// 使用事务处理
        /// </summary>
        public void UseTranscation()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                const string deleteColumn = "delete from [Column] where ColumnCatid=@catid";

                const string deleteColumnCat = "delete from ColumnCat where id=@Id";
                IDbTransaction transaction = conn.BeginTransaction();

                int row = conn.Execute(deleteColumn, new { catid = 1 }, transaction, null, null);

                row += conn.Execute(deleteColumnCat, new { id = 1 }, transaction, null, null);

                transaction.Commit();
            }
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetIdentity<T>()
        {
            using (SqlConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();
                dynamic identity = conn.Query("SELECT @@IDENTITY AS Id").Single();

                T newId = (T)identity.Id;
            }

        }
    }
}
