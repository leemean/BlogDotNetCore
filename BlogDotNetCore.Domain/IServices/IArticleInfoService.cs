using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain.IService
{
    public interface IArticleInfoService
    {
        List<articleInfoDto> GetAllArticleInfos();

        articleInfoDto GetArticleInfoById(Guid id);

        bool CreateArticleInfo(articleInfoDto articleInfoDto);

        bool UpdateArticleInfo(articleInfoDto articleInfoDto);

        bool DeleteArticleInfo(Guid guid);
    }
}
