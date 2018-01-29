using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Northwind.Domain.Repository
{
    public interface IBaseRepository<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(object id);

        T Get(object id);

        IEnumerable<T> GetAll();
    }
}
