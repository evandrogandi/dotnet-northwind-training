using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Northwind.Domain.Model;

namespace GAtec.Northwind.Domain.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        bool ExistsName(string name, int id = 0);
    }
}
