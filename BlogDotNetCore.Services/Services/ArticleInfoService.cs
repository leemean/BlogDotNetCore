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

        public List<articleInfoDto> GetAllArticleInfos()
        {
            return _articleInfoRepository.Query(x => x.is_del == false);
        }

        public bool CreateArticleInfo(articleInfoDto articleInfoDto)
        {
            var id = Guid.NewGuid().ToString();
            articleInfoDto newArticle = new articleInfoDto
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
            articleContentDto articleContent = new articleContentDto { id = Guid.NewGuid().ToString(), article_info_id = id, content = "第一篇博客kjsflkjakfl" };
            List<articleCommentDto> articleCommentDto = new List<articleCommentDto>
            {
                new articleCommentDto{  id = Guid.NewGuid().ToString(), article_info_id = id, name = "张三", email = "zhangshan@qq.com", content = "文章不错呀！！！" }
            };
            newArticle.article_Content = articleContent;
            newArticle.article_Comments = articleCommentDto;
            //articleInfoDto.id = id;
            //if(articleInfoDto.article_Content != null)
            //    articleInfoDto.article_Content.article_info_id = id;
            //if(articleInfoDto.article_Comments != null)
            //{
            //    foreach(var item in articleInfoDto.article_Comments)
            //    {
            //        item.article_info_id = id;
            //    }
            //}
            return _articleInfoRepository.Create(newArticle);
        }

        public bool UpdateArticleInfo(articleInfoDto articleInfoDto)
        {
            return _articleInfoRepository.Update(articleInfoDto);
        }

        public bool DeleteArticleInfo(Guid id)
        {
            articleInfoDto del = _articleInfoRepository.GetById(id);
            del.is_del = true;
            if(del.article_Content != null)
            {
                del.article_Content.is_del = true;
            }
            if(del.article_Comments != null)
            {
                foreach(var item in del.article_Comments)
                {
                    item.is_del = true;
                }
            }
            return _articleInfoRepository.Update(del);
        }
    }
}
