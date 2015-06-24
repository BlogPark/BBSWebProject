using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 会员信息
        /// </summary>
        public MemberInfo Member { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
    }
}