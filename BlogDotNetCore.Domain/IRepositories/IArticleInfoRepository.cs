using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain
{
    /// <summary>
    /// 文章聚合根的仓储接口
    /// </summary>
    public interface IArticleInfoRepository : IRepository<articleInfoDto>
    {

    }
}
