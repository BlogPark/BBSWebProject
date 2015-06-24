using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //评论表

    public class CommentInfo
    {
        /// <summary>
        /// 评论ID
        /// </summary>

        public int CID { get; set; }
        /// <summary>
        /// 文章ID
        /// </summary>

        public int AID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>

        public int MID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>

        public string CoContent { get; set; }
        /// <summary>
        /// 状态（10 未审核  20 已审核 30 删除）
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string TitleName { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime Addtime { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int Counts { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberUserName { get; set; }

    }
}
