using System;
using System.Collections.Generic;

namespace Forecaster.Interfaces
{
    internal interface IContractRepository<T> where T : class
    {
        IEnumerable<T> Contracts(Func<T, bool> predicate = null);
        T Contract(Func<T, bool> predicate);
    }
}
