using System.Collections.Generic;

namespace Forecaster.Interfaces
{
    public interface IFile<out T> where T : class
    {
        bool IsFileExist();
        IEnumerable<T> Read();
    }
}