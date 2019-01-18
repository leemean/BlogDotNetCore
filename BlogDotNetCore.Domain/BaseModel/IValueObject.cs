using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Domain
{
    /// <summary>
    /// 值对象接口，值对象接口只需要保留一个技术主键即可，它没有业务标识符。在数据库中，值对象可能作为单独表存储，也可以作为实体的一部分存储。你也可以扩展这个接口，定义两个值对象比较接口（未来实现
    /// </summary>
    public interface IValueObject
    {
        Guid Id { get; set; }
    }
}
