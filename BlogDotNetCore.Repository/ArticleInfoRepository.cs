using AutoMapper;
using BlogDotNetCore.Data;
using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogDotNetCore.Repository
{
    public class ArticleInfoRepository : IArticleInfoRepository
    {
        private IBaseDB _baseDB;

        private IMapper _mapper;
        public ArticleInfoRepository(IBaseDB baseDB, IMapper mapper)
        {
            _baseDB = baseDB;
            _mapper = mapper;
        }

        public articleInfoDto GetById(Guid id)
        {
            var dbEntity = _baseDB.Set<articleInfo>()
                .FirstOrDefault(x => x.id == id && x.is_del == false);

            if (dbEntity != null)
            {
                LoadDetails(_baseDB, dbEntity);
            }

            return dbEntity != null ? _mapper.Map<articleInfoDto>(dbEntity) : null;
        }

        public articleInfoDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(articleInfoDto entity)
        {
            var dbEntity = _mapper.Map<articleInfo>(entity);
            _baseDB.Set<articleInfo>().Add(dbEntity);
            var effectiveCount = _baseDB.SaveChanges();
            if (effectiveCount > 0)
                return true;
            else
                return false;
        }

        public bool Update(articleInfoDto entity)
        {
            var dbEntity = _mapper.Map<articleInfo>(entity);
            _baseDB.Entry<articleInfo>(dbEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            UpdateDetails(_baseDB, dbEntity.article_content);
            var effectiveCount = _baseDB.SaveChanges();
            if (effectiveCount > 0)
                return true;
            else
                return false;
        }

        public void LoadDetails(IBaseDB baseDB, articleInfo articleinfo)
        {
            articleinfo.article_content = baseDB.Set<articleContent>().FirstOrDefault(x => x.article_info_id == articleinfo.id);
        }

        public void UpdateDetails(IBaseDB baseDB, articleContent content)
        {
            var articleContent = baseDB.Set<articleContent>().FirstOrDefault(x => x.id == content.article_info_id);
            if(articleContent == null)
            {
                baseDB.Set<articleContent>().Add(articleContent);
            }
            else
            {
                baseDB.Entry<articleContent>(articleContent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
