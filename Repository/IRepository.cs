using System.Collections.Generic;
using System.Linq;

namespace bikes_project.Data
{
    public partial interface IRepository<T>
    {
        T GetById(int id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Table { get; }
    }
}
