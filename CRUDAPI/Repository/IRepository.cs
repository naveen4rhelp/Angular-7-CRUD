using System.Collections.Generic;

namespace CRUDAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(string path);

        void Add(T model);

        void Update(T model);

        T Find(int id);

        void Delete(T model);

        void Delete(int id);

        void SaveChanges();

    }
}
