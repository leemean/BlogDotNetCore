using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain
{
    public class articleInfoDto : AggregateRoot 
    {
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

        public List<articleCommentDto> article_Comments { get; set; }

        public articleContentDto article_Content { get; set; }

        public articleInfoDto()
        {

        }

        public static articleInfoDto createNew()
        {
            return new articleInfoDto
            {

            };
        }
    }
}
