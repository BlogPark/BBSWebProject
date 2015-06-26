using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;
using System.Runtime;
using System.Runtime.Serialization;

namespace BBS.Web2.Models
{
    [Serializable]
    [DataContract]
    public class LoginViewModel
    {
        /// <summary>
        /// 会员信息
        /// </summary>
        [DataMember]
        public MemberInfo Member { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
          [DataMember]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
         [DataMember]
        public string email { get; set; }
       /// <summary>
       /// 来源URL
       /// </summary>
         [DataMember]
         public string resutnurl { get; set; }
    }
}