using System;
using PAymentForServices.Common.ModelsDto;
using System.Text.Json;
using PAymentForServices.BusinessLogic.Services;

namespace PAymentForServices.Service.Services
{
    public class CategoryJsonService:ICategoryJsonService
    {
        private readonly ICategoryService _categoryService;

        public CategoryJsonService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public string GetServices()
        {
            var services = _categoryService.GetServices();

            var response = JsonSerializer.Serialize<List<ServiceDto>>(services);

            return response;
        }

        public string Get(string json)
        {
            var id = JsonSerializer.Deserialize<int>(json);

            var services = _categoryService.GetCategories(id);

            var response = JsonSerializer.Serialize<List<CategoryDto>>(services);

            return response;
        }

        public string GetId(string json)
        {
            var name = JsonSerializer.Deserialize<string>(json);

            var id = _categoryService.GetCategoryId(name);

            var response = JsonSerializer.Serialize<int>(id);

            return response;
        }
    }
}

