using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogDotNetCore.Data
{
    [Table("articlePicture")]
    public class articlePicture
    {
        [Key]
        public Guid id { get; set; }

        public Guid article_info_id { get; set; }

        public byte[] picture { get; set; }

        public string picture_url { get; set; }

        public bool is_del { get; set; }
    }
}
