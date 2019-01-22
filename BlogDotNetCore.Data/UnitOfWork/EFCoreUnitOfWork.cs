﻿using BlogDotNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Data.UnitOfWork
{
    /// <summary>
    /// 工作单实现类
    /// </summary>
    public class EFCoreUnitOfWork : IEFCoreUnitOfWork
    {
        #region 属性
        //通过工作单元向外暴露的EF上下文对象 
        public IBaseDB context { get; set; }
        #endregion

        #region 构造函数
        public EFCoreUnitOfWork(IBaseDB context)
        {
            this.context = context;
        }
        #endregion

        #region IUnitOfWorkRepositoryContext接口
        public void RegisterNew<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            var state = context.Entry(obj).State;
            if (state == EntityState.Detached)
            {
                context.Entry(obj).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        public void RegisterModified<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (context.Entry(obj).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(obj);
            }
            context.Entry(obj).State = EntityState.Modified;
            IsCommitted = false;
        }

        public void RegisterDeleted<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            context.Entry(obj).State = EntityState.Deleted;
            IsCommitted = false;
        }
        #endregion

        #region IUnitOfWork接口

        public bool IsCommitted { get; set; }

        public bool Commit()
        {
            if (IsCommitted)
            {
                return false;
            }
            try
            {
                bool result = context.Commit();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {

                throw e;
            }
        }

        public void Rollback()
        {
            IsCommitted = false;
        }
        #endregion

        #region IDisposable接口
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            context.Dispose();
        }
        #endregion
    }
}
