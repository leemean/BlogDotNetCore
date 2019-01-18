using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Services.Services
{
    public class ArticleInfoService
    {
        private IArticleInfoRepository _articleInfoRepository;

        public ArticleInfoService(IArticleInfoRepository articleInfoRepository)
        {
            _articleInfoRepository = articleInfoRepository;
        }


        public bool Insert(string content, List<string> comments)
        {
            articleInfoDto articleInfo = articleInfoDto.createNew();
            articleContentDto articleContent = new articleContentDto();
            articleCommentDto articleComment = new articleCommentDto();
            _articleInfoRepository.Insert();
        }
    }
}
