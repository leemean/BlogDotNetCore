using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDotNetCore.Data
{
    /// <summary>
    /// 文章信息
    /// </summary>
    public class articleInfo
    {
        [Key]
        public int id { get; set; }

        public string create_by { get; set; }

        public DateTime create_date { get; set; }

        public string update_by { get; set; }

        public DateTime update_date { get; set; }

        public string version { get; set; }

        public bool is_del { get; set; }

        public string title { get; set; }

        public string type { get; set; }

        public string is_top { get; set; }

        public string author { get; set; }

        public string original_link { get; set; }

        public bool is_original { get; set; }

        public bool is_private { get; set; }

        public List<articleComment> article_comments { get; set; }

        public articleConetnt article_conetnt { get; set; }

    }
}
