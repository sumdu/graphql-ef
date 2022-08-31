using AutoMapper;
using FinTracker.Models;
using FinTracker.Service.ViewModels.Category;

namespace FinTracker.Service
{
    public class MapperService
    {
        private IMapper _mapper;

        public MapperService()
        {
            var _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateCategoryViewModel, Category>();
                cfg.CreateMap<Category, GetCategoryViewModel>();
                cfg.CreateMap<Category, GetCategoriesItem>();
            });
            _mapper = _config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource souceObject)
        {
            return _mapper.Map<TDestination>(souceObject);
        }
    }
}
