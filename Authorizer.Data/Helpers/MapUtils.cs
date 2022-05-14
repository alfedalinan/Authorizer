using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizer.Data.Helpers
{
    public class MapUtils
    {
        public static TDestination Initialize<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());

            var mapper = new Mapper(config);

            var mappedObject = mapper.Map<TSource, TDestination>(source);

            return mappedObject;
        }
    }
}
