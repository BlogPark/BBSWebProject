using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BBS.Model
{
    [DataContract]
    public class DiscussInfo
    {
        /// <summary>
        /// 话题ID
        /// </summary>
          [DataMember]
        public int Did { get; set; }
        /// <summary>
        /// 话题标题
        /// </summary>
          [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 话题内容
        /// </summary>
          [DataMember]
        public string Dcontent { get; set; }
        /// <summary>
        /// 查看数量
        /// </summary>
          [DataMember]
        public int ClickCount { get; set; }
        /// <summary>
        /// 话题状态（10 发表 20 停用）
        /// </summary>
          [DataMember]
        public int Dstatus { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
          [DataMember]
        public int CommentCount { get; set; }
        /// <summary>
        /// 是否置顶(1 是 0 否)
        /// </summary>
          [DataMember]
        public int IsTop { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
          public DateTime AddTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }
       /// <summary>
       /// 发布者ID
       /// </summary>
        [DataMember]
        public int PUserID { get; set; }
        /// <summary>
        /// 发布者名称
        /// </summary>
        [DataMember]
        public string PUserName { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        [DataMember]
        public int rowco { get; set; }
        /// <summary>
        /// 索引顺序
        /// </summary>
        [DataMember]
        public int rowid { get; set; }
    }
}
