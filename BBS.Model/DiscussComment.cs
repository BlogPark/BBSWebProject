using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BBS.Model
{
    [Serializable]
    [DataContract]
    public class DiscussComment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        [DataMember]
        public int Cid { get; set; }
        /// <summary>
        /// 评论用户
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [DataMember]
        public string CContent { get; set; }
        /// <summary>
        /// 支持数
        /// </summary>
        [DataMember]
        public int SupportCount { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        [DataMember]
        public int AgainstCount { get; set; }
        /// <summary>
        /// 状态（0 禁用 1 启用）
        /// </summary>
        [DataMember]
        public int Cstatus { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 讨论组ID
        /// </summary>
        [DataMember]
        public int Did { get; set; }
        /// <summary>
        /// 会员头像
        /// </summary>
        [DataMember]
        public string MemberPic { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime AddTime { get; set; }

    }
}
