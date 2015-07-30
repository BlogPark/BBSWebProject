using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBS.Admin.Areas.Article.Models
{
    public class ArticleInfoModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage="标题必填")]
        [MaxLength(30,ErrorMessage="标题超长")]
        public string Title { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string ViceTitleName { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public int AuthorID { get; set; }
        /// <summary>
        /// 作者名字
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>        
        public string MainPicURL { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int PicWidth { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int PicHeight { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string DSummary { get; set; }
        /// <summary>
        /// 来源URL
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 来源名称
        /// </summary>
        public string AFrom { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
         [Required(ErrorMessage = "内容必填")]
        public string AContent { get; set; }
        /// <summary>
        /// 文章详情
        /// </summary>
        public string ADetailtext { get; set; }
    }
}