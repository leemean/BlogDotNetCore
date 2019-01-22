using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDotNetCore.Data
{
    [Table("articleContent")]
    /// <summary>
    /// 文章内容
    /// </summary>
    public class articleContent
    {
        [Key]
        public Guid id { get; set; }

        public Guid article_info_id { get; set; }

        public string content { get; set; }

        public bool is_del { get; set; }

    }
}
