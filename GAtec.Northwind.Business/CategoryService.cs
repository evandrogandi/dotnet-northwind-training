using System;
using System.Collections.Generic;
using GAtec.Northwind.Domain.Business;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;
using System.Linq;

namespace GAtec.Northwind.Business
{
    public class CategoryService : ICategoryService
    {

        public IDictionary<string, string> Validation { get; private set; }

        private ICategoryRepository CategoryRepository { get; set; }       

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
            this.Validation = new Dictionary<string, string>();
        }

        public void Add(Category category)
        {
            if (!IsValid(category))            
                return;            

            CategoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            if (!IsValid(category))
                return;

            CategoryRepository.Update(category);
        }

        public void Delete(int id)
        { 

            CategoryRepository.Delete(id);
        }

        public Category GetCategory(int id)
        {
            return CategoryRepository.Get(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return CategoryRepository.GetAll();
        }

        private bool IsValid(Category category)
        {
            
            if (string.IsNullOrEmpty(category.Name))
            {
                Validation.Add("Name", "The Name is required.");

            }
            else if (CategoryRepository.ExistsName(category.Name, category.Id))
            {

                Validation.Add("Name", "The Name already exists.");

            }

            return !Validation.Any();
        }

    }
}