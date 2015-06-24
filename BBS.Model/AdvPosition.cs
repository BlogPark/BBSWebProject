using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //广告位置表

    public class AdvPosition
    {
        /// <summary>
        /// 广告位置ID
        /// </summary>

        public int AID { get; set; }
        /// <summary>
        /// 广告位置名称
        /// </summary>

        public string AdvPositionName { get; set; }
        /// <summary>
        /// 广告位置宽
        /// </summary>

        public int AdvPWith { get; set; }
        /// <summary>
        /// 广告位置高
        /// </summary>

        public int AdvPHeight { get; set; }
        /// <summary>
        /// 状态（10 禁用 20 启用）
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 广告代码
        /// </summary>

        public string AdvCode { get; set; }
        /// <summary>
        /// 广告位置类型（10 图  20  文字  30 图文 40 列表）
        /// </summary>

        public int AdvType { get; set; }

    }
}
