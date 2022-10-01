using System;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public interface ICategoryService
    {
        void Sync();
        List<ServiceDto> GetServices();
        List<CategoryDto> GetCategories(int id);
        int GetCategoryId(string name);
    }
}

