using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogDotNetCore.Domain
{
    /// <summary>
    /// 仓储接口，定义公共的泛型GRUD
    /// </summary>
    /// <typeparam name="TEntity">泛型聚合根，因为在DDD里面仓储只能对聚合根做操作</typeparam>
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        TEntity GetById(int id);
        TEntity GetByName(string name);
        void Create(TEntity entity);
        void Update(TEntity entity);
    }
}
