using BlogDotNetCore.Domain;
using BlogDotNetCore.Domain.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Services
{
    public class ArticleInfoService : IArticleInfoService
    {
        private IArticleInfoRepository _articleInfoRepository;

        public ArticleInfoService(IArticleInfoRepository articleInfoRepository)
        {
            _articleInfoRepository = articleInfoRepository;
        }



        public articleInfoDto GetArticleInfoById(Guid id)
        {
            return _articleInfoRepository.GetById(id);
        }

        public bool CreateArticleInfo()
        {
            var id = Guid.NewGuid();
            articleInfoDto articleInfoDto = new articleInfoDto
            {
                id = id,
                create_by = "liming",
                create_date = DateTime.Now,
                update_by = "liming",
                update_date = null,
                is_del = false,
                title = "title1",
                type = "编程技术",
                is_top = false,
                author = "liming",
                is_original = true,
                is_private = false
            };
            articleContentDto articleContent = new articleContentDto { id = Guid.NewGuid(), article_info_id = id, content = "第一篇博客kjsflkjakfl" };
            List<articleCommentDto> articleCommentDto = new List<articleCommentDto>
            {
                new articleCommentDto{  id = Guid.NewGuid(), article_info_id = id, name = "张三", email = "zhangshan@qq.com", content = "文章不错呀！！！" }
            };
            articleInfoDto.article_Content = articleContent;
            articleInfoDto.article_Comments = articleCommentDto;
            return _articleInfoRepository.Create(articleInfoDto);
        }
    }
}
