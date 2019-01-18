using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDotNetCore.Data
{
    /// <summary>
    /// 文章内容
    /// </summary>
    public class articleConetnt
    {
        [Key]
        public int id { get; set; }

        public int article_info_id { get; set; }

        public string content { get; set; }

    }
}
