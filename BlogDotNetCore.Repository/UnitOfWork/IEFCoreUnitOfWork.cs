using BlogDotNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Repository
{

    //表示EF的工作单元接口，因为DbContext是EF的对象
    public interface IEFCoreUnitOfWork : IUnitOfWorkRepositoryContext
    {
        DbContext context { get; }
    }
}
