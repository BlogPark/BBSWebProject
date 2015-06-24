using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    //关键词表

    public class TagInfo
    {
        /// <summary>
        /// id
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// Tag名称
        /// </summary>

        public string TagName { get; set; }
        /// <summary>
        /// 词频
        /// </summary>

        public int WordFrequency { get; set; }
        /// <summary>
        /// Tag代码
        /// </summary>

        public string Code { get; set; }

    }
}
