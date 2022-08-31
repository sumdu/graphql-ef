using FinTracker.Models;
using FinTracker.Service.ViewModels.Category;

namespace FinTracker.Service
{
    public class CategoryService: AbstractService
    {
        public CategoryService(string connectionString, MapperService mapperService) 
            : base(connectionString, mapperService) { }

        public int Create(CreateCategoryViewModel categoryViewModel)
        {
            using var db = CreateDbContext();
            var category = _mapperService.Map<CreateCategoryViewModel, Category>(categoryViewModel);
            db.Categories.Add(category);
            db.SaveChanges();

            return category.Id;
        }

        public GetCategoryViewModel Get(int id)
        {
            using var db = CreateDbContext();
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            var categoryModel = _mapperService.Map<Category, GetCategoryViewModel>(category);

            return categoryModel;
        }

        public GetCategoriesViewModel GetAll()
        {
            using var db = CreateDbContext();
            var categories = db.Categories.ToList();
            var allCategoriesModel = _mapperService.Map<List<Category>, GetCategoriesViewModel>(categories);

            return allCategoriesModel;
        }
    }
}
