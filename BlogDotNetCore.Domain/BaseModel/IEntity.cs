using System;

namespace BlogDotNetCore.Domain
{
    /// <summary>
    /// 实体顶层定义，用作泛型约束，表示继承自该接口的为领域实体
    /// Id是一个未来存储到数据库表中的技术主键
    /// Code是领域对象的唯一业务标识符。你也可以扩展这个接口，定义两个实体比较接口(未来实现就是比较两个实体如果Code一致，则代表两个实体相等)。
    /// </summary>
    public interface IEntity
    {
        //string code { get; set; }

        //Guid Id { get; set; }
    }
}
