using FinTracker.Service;
using FinTracker.Service.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinTracker.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var categoryService = new CategoryService(ConfigurationBuilderSingleton.ConfigurationRoot.GetConnectionString("FinTracker"), new MapperService());
            var createdId = categoryService.Create(new CreateCategoryViewModel { Name = "Lol" });
            var category = categoryService.Get(createdId);
            var allCategories = categoryService.GetAll();
        }
    }
}