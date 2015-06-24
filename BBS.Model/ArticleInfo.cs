using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //文章主表

    public class ArticleInfo
    {
        /// <summary>
        /// 查询结果总条数
        /// </summary>
        public int Totalc { get; set; }
        /// <summary>
        /// 主键自增
        /// </summary>

        public int AID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>

        public string TitleName { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>

        public string ViceTitleName { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>

        public int AuthorID { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>

        public string AuthorName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>

        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 文章状态（10 未审核  20 待审核  30 已审核）
        /// </summary>

        public int Astatus { get; set; }
        /// <summary>
        /// 主图地址
        /// </summary>

        public string MainPicURL { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>

        public int PicWidth { get; set; }
        /// <summary>
        /// 主图高
        /// </summary>

        public int PicHeight { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>

        public DateTime Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>

        public DateTime Updatetime { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 关键词组
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 文章简要内容（文章前三百字）
        /// </summary>
        public string DSummary { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>
        public int ClickCount { get; set; }
        /// <summary>
        /// 文章明细
        /// </summary>
        public ArticleDetail Details { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; }
        /// <summary>
        /// 来源URL
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        ///文章来源
        /// </summary>
        public string AFrom { get; set; }

    }
}
