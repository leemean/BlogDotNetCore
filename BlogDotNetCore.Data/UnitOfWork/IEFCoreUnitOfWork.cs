using BlogDotNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Data.UnitOfWork
{

    //表示EF的工作单元接口，因为DbContext是EF的对象
    public interface IEFCoreUnitOfWork : IUnitOfWork, IDisposable
    {
        IBaseDB context { get; }
    }
}
