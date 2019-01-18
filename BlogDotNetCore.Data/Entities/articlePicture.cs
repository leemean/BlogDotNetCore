using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogDotNetCore.Data
{
    public class articlePicture
    {
        [Key]
        public int id { get; set; }

        public int article_info_id { get; set; }

        public byte[] picture { get; set; }

        public string picture_url { get; set; }
    }
}
