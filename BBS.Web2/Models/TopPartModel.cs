using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS.Web2.Models
{
    public class TopPartModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string expenstr { get; set; }
        /// <summary>
        /// 是否已经登录
        /// </summary>
        public bool IsHaveUser { get; set; }
    }
}