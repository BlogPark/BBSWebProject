using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //会员主表

    public class MemberInfo
    {
        /// <summary>
        /// 会员ID
        /// </summary>

        public int MID { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>

        public string HeadPic { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>

        public string Email { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>

        public string Birthday { get; set; }
        /// <summary>
        /// 密码
        /// </summary>

        public string Password { get; set; }
        /// <summary>
        /// 状态（10 未审核  20  正常）
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>

        public DateTime Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>

        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 用户链接
        /// </summary>

        public string mURL { get; set; }
        /// <summary>
        /// 会员描述
        /// </summary>

        public string Description { get; set; }
        /// <summary>
        /// 性别
        /// </summary>

        public int Sex { get; set; }
        /// <summary>
        /// 会员标签
        /// </summary>

        public string Tags { get; set; }
        /// <summary>
        /// 喜好
        /// </summary>

        public string Likes { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>

        public int IsRecommend { get; set; }
        /// <summary>
        /// 是否博客用户
        /// </summary>

        public int IsBlogUser { get; set; }
        /// <summary>
        /// 博客名称
        /// </summary>

        public string BlogUserName { get; set; }
        /// <summary>
        /// 博客描述
        /// </summary>

        public string BlogDecription { get; set; }
        /// <summary>
        /// 博客文章数量
        /// </summary>

        public int BlogCount { get; set; }

    }
}
