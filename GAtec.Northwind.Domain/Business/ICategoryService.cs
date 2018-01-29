using System.Collections.Generic;
using GAtec.Northwind.Domain.Model;

namespace GAtec.Northwind.Domain.Business
{
    public interface ICategoryService : IService
    {
        void Add(Category category);

        void Update(Category category);

        void Delete(int id);

        Category GetCategory(int id);

        IEnumerable<Category> GetCategories();
    }
}