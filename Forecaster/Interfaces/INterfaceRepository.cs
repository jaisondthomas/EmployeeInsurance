using System;
using System.Collections.Generic;

namespace Forecaster.Interfaces
{
    internal interface INterfaceRepository<T> where T : class
    {
        IEnumerable<T> Records(Func<T, bool> predicate = null);
      
    }
}
