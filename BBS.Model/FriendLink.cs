using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.Model
{
    /// <summary>
    /// 友情链接表
    /// </summary>
    public class FriendLink
    {
        public int ID { get; set; }
        public string LinkName { get; set; }

        public string LinkUrl { get; set; }

        public int LStatus { get; set; }
        public int Clickcount { get; set; }
    }
}
