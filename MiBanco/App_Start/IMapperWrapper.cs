using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBanco.App_Start
{
   public interface IMapperWrapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
