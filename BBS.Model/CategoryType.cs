using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //分类信息表

    public class CategoryType
    {
        /// <summary>
        /// 分类ID
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>

        public string CategoryName { get; set; }
        /// <summary>
        /// 状态（10 启用  20 禁用）
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 分类文章
        /// </summary>
        public List<ArticleInfo> Articles { get; set; }
        /// <summary>
        /// 图标名称
        /// </summary>
        public string Iconname { get; set; }
    }
}
