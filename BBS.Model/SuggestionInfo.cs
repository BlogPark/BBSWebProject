using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    public class SuggestionInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int SID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int SUserID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string SUserName { get; set; }
        /// <summary>
        /// 留言标题
        /// </summary>
        public string STitle { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string SContent { get; set; }
        /// <summary>
        /// 留言状态
        /// </summary>
        public int SStatus { get; set; }
        /// <summary>
        /// 是否回复
        /// </summary>
        public int SIsanwser { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string SAnwserContent { get; set; }
    }
}
