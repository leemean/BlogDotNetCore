using AutoMapper;
using BlogDotNetCore.Data.UnitOfWork;
using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogDotNetCore.Data.Repository
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

        public articleInfoDto GetById(int id)
        {
            var dbEntity = _baseDB.Set<articleInfo>()
                .FirstOrDefault(x => x.id == id && x.is_del == false);

            LoadDetails(_baseDB, dbEntity);

            return dbEntity != null ? _mapper.Map<articleInfoDto>(dbEntity) : null;
        }

        public articleInfoDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Create(articleInfoDto entity)
        {
            var dbEntity = _mapper.Map<articleInfo>(entity);
            _baseDB.Set<articleInfo>().Add(dbEntity);
            _baseDB.SaveChanges();
        }

        public void Update(articleInfoDto entity)
        {
            var dbEntity = _mapper.Map<articleInfo>(entity);
            _baseDB.Entry<articleInfo>(dbEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            UpdateDetails();
            _baseDB.SaveChanges();
        }

        public void LoadDetails(IBaseDB baseDB, articleInfo articleinfo)
        {
            articleinfo.article_conetnt = baseDB.Set<articleConetnt>().FirstOrDefault(x => x.article_info_id == articleinfo.id);
        }

        public void UpdateDetails(IBaseDB baseDB, articleInfo articleinfo)
        {
            articleinfo.article_conetnt = baseDB.Set<articleInfo>().FirstOrDefault()
        }
    }
}
