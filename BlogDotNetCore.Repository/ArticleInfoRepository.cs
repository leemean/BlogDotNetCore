using AutoMapper;
using BlogDotNetCore.Data;
using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var dbEntity = _baseDB.Table<articleInfo>()
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
            return _baseDB.Commit();
        }

        public bool Update(articleInfoDto entity)
        {
            var dbEntity = _mapper.Map<articleInfo>(entity);
            _baseDB.Entry<articleInfo>(dbEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            UpdateDetails(_baseDB, dbEntity.article_content, dbEntity.article_comments);
            return _baseDB.Commit();
        }

        public void LoadDetails(IBaseDB baseDB, articleInfo articleinfo)
        {
            articleinfo.article_content = baseDB.Table<articleContent>().FirstOrDefault(x => x.article_info_id == articleinfo.id);
            articleinfo.article_comments = baseDB.Table<articleComment>().Where(x => x.article_info_id == articleinfo.id).ToList();
        }

        public void UpdateDetails(IBaseDB baseDB, articleContent content, ICollection<articleComment> comments)
        {
            var articleContent = baseDB.Table<articleContent>().FirstOrDefault(x => x.id == content.id);
            if(articleContent == null)
            {
                baseDB.Set<articleContent>().Add(content);
            }
            else
            {
                baseDB.Entry<articleContent>(content).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            foreach(var item in comments)
            {
                var articleComment = baseDB.Table<articleComment>().FirstOrDefault(x => x.id == item.id);
                if(articleComment == null)
                {
                    baseDB.Set<articleComment>().Add(articleComment);
                }
                else
                {
                    baseDB.Entry<articleComment>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
        }

        public List<articleInfoDto> Query(Expression<Func<articleInfoDto, bool>> whereExpression)
        {
            var expression = _mapper.Map<Expression<Func<articleInfo, bool>>>(whereExpression);

            var dbEntity = _baseDB.Table<articleInfo>()
                .Where(expression); //TODO expression

            List<articleInfoDto> result = new List<articleInfoDto>();
            if (dbEntity != null)
            {
                foreach (var item in dbEntity)
                {
                    LoadDetails(_baseDB, item);
                    result.Add(_mapper.Map<articleInfoDto>(item));
                }
            }
            //TODO map list 明细没值
            // _mapper.Map<List<articleInfoDto>>(dbEntity) 
            return dbEntity != null ? result : null;
        }
    }
}
