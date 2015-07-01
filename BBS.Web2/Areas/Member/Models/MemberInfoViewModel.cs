using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS.Web2.Areas.Member.Models
{
    [Serializable]
    public class MemberInfoViewModel
    {
        public string Name { get; set; }

        public int Sex { get; set; }

        public string BirthDay { get; set; }

        public string Tag { get; set; }

        public string Discription { get; set; }

        public string Likes { get; set; }

        public string HeadPic { get; set; }

    }
}