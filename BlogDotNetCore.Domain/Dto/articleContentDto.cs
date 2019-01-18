using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain
{
    public class articleContentDto : IEntity
    {
        public int id { get; set; }

        public int article_info_id { get; set; }

        public string content { get; set; }
    }
}
