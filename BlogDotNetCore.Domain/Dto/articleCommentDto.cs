using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain
{
    public class articleCommentDto : IEntity
    {
        public string id { get; set; }

        public string article_info_id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string content { get; set; }
        
        public bool is_del { get; set; }
    }
}
