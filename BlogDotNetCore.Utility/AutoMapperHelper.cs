using AutoMapper;
using System;
using System.Collections.Generic;

namespace BlogDotNetCore.Utility
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  单个对象映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this object obj)
        {
            if (obj == null) return default(TDestination);
            //Mapper.Initialize(cfg => cfg.CreateMap<,T>());
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());
            return Mapper.Map<TDestination>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource,TDestination>());
            return Mapper.Map<List<TDestination>>(source);
        }
    }
}
