using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.Model;

namespace BBS.Web2.Models
{
    public class AboutPageViewModel
    {
        /// <summary>
        /// 意见
        /// </summary>
        public SuggestionInfo Suggestion { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否提交成功
        /// </summary>
        public bool Success { get; set; }
    }
}