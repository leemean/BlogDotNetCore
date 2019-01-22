using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDotNetCore.Data
{
    public class articleType
    {
        [Key]
        public Guid id { get; set; }

        public Guid article_info_id { get; set; }

        public string code { get; set; }

        public string value { get; set; }

        public string name { get; set; }

        public string remark { get; set; }
    }
}
