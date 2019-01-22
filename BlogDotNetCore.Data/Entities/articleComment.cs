using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDotNetCore.Data
{
    public class articleComment
    {
        [Key]
        public Guid id { get; set; }

        public Guid article_info_id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string content { get; set; }
    }
}
