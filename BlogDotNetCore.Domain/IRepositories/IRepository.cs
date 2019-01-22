using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogDotNetCore.Domain
{
    /// <summary>
    /// 仓储接口，定义公共的泛型GRUD
    /// </summary>
    /// <typeparam name="TEntity">泛型聚合根，因为在DDD里面仓储只能对聚合根做操作</typeparam>
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        TEntity GetById(Guid id);
        TEntity GetByName(string name);
        List<TEntity> Query(Expression<Func<TEntity, bool>> whereExpression);
        bool Create(TEntity entity);
        bool Update(TEntity entity);
    }
}
