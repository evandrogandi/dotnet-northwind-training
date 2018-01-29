using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Northwind.Business;
using GAtec.Northwind.Data;
using GAtec.Northwind.Domain.Model;
using Gatec.Northwind.Util;

namespace GAtec.Northwind.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {


            // Console.WriteLine(NorthwiectionString)

            // Define a instance of ICategoryRepository
            var categoryRepository = new CategoryRepository();

            // Define a service and inject (manually) the dependency from ICategoryRepository
            var categoryService = new CategoryService(categoryRepository);

            var categories = categoryService.GetCategories();

            foreach(var c in categories)
            {

                Console.WriteLine($"{c.Id} - {c.Name} - {c.Description}");
            }

            // create a new category
            var category = new Category
            {
                Name = "Instruments",
                Description = "Musical instruments"
            };

            // call the Add method from category service
            categoryService.Add(category);

            if (categoryService.Validation.Any())
            {
                foreach (var item in categoryService.Validation)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }

            }

            Console.ReadKey();

        }
    }
}
