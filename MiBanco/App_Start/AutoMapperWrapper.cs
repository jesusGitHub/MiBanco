using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiBanco.App_Start
{
    public class AutoMapperWrapper : IMapperWrapper
    {
        private readonly IMapper _mapper;

        public AutoMapperWrapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}