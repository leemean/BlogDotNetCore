using BlogDotNetCore.Data.UnitOfWork;
using BlogDotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogDotNetCore.Data.Repository
{
    //仓储的泛型实现类
    //public abstract class EFCoreBaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    //{
    //    private IBaseDB _baseDB { get; set; }

    //    public EFCoreBaseRepository(IBaseDB baseDB)
    //    {
    //        _baseDB = baseDB;
    //    }

    //    public virtual IQueryable<TEntity> Entities
    //    {
    //        get { return _unitOfWork.context.Set<TEntity>(); }
    //    }

    //    public virtual int Insert(TEntity entity)
    //    {
    //        _unitOfWork.RegisterNew(entity);
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual int Insert(IEnumerable<TEntity> entities)
    //    {
    //        foreach (var obj in entities)
    //        {
    //            _unitOfWork.RegisterNew(obj);
    //        }
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual int Delete(object id)
    //    {
    //        var obj = _unitOfWork.context.Set<TEntity>().Find(id);
    //        if (obj == null)
    //        {
    //            return 0;
    //        }
    //        _unitOfWork.RegisterDeleted(obj);
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual int Delete(TEntity entity)
    //    {
    //        _unitOfWork.RegisterDeleted(entity);
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual int Delete(IEnumerable<TEntity> entities)
    //    {
    //        foreach (var entity in entities)
    //        {
    //            _unitOfWork.RegisterDeleted(entity);
    //        }
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual int Update(TEntity entity)
    //    {
    //        _unitOfWork.RegisterModified(entity);
    //        return _unitOfWork.Commit();
    //    }

    //    public virtual TEntity GetByKey(object key)
    //    {
    //        return _unitOfWork.context.Set<TEntity>().Find(key);
    //    }

    //    public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> express)
    //    {
    //        Func<TEntity, bool> lamada = express.Compile();
    //        return _unitOfWork.context.Set<TEntity>().Where(lamada).AsQueryable<TEntity>();
    //    }

    //    public virtual int Delete(Expression<Func<TEntity, bool>> express)
    //    {
    //        Func<TEntity, bool> lamada = express.Compile();
    //        var lstEntity = _unitOfWork.context.Set<TEntity>().Where(lamada);
    //        foreach (var entity in lstEntity)
    //        {
    //            _unitOfWork.RegisterDeleted(entity);
    //        }
    //        return _unitOfWork.Commit();
    //    }
    //}
}
