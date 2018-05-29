using System.Collections.Generic;

namespace Forecaster.Interfaces
{
    public interface IDataContext<T> where T : class
    {
       IEnumerable<T> Records();
    }
}
