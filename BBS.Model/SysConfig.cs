using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //系统配置表

    public class SysConfig
    {
        /// <summary>
        /// ID
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 存储值
        /// </summary>

        public string SysValue { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>

        public int FatherID { get; set; }
        /// <summary>
        /// 状态（0 禁用 1启用）
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>

        public DateTime Addtime { get; set; }

    }
}
