using AutoMapper;
using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Data.Domain
{
    /// <summary>
    /// AutoMapper 映射
    /// </summary>
    public class DomainAutoMapperProfile : Profile
    {
        public DomainAutoMapperProfile()
        {
            CreateMap<articleInfoDto,articleInfo>();
            CreateMap<articleInfo, articleInfoDto>().ConstructUsing(x => new articleInfoDto());

            CreateMap<articleContentDto, articleContent>();
            CreateMap<articleContent, articleContentDto>().ConstructUsing(x => new articleContentDto());

            CreateMap<articleCommentDto, articleComment>();
            CreateMap<articleComment, articleCommentDto>().ConstructUsing(x => new articleCommentDto());
        }
    }
}
