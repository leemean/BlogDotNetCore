using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain.IService
{
    public interface IArticleInfoService
    {

        articleInfoDto GetArticleInfoById(Guid id);

        bool CreateArticleInfo();
    }
}
