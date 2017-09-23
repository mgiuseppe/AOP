using System.Collections.Generic;

namespace LoggingService
{
    public interface IService
    {
        IEnumerable<int> GetAll();

        int GetById(int id);

        void Update(int id);
    }
}