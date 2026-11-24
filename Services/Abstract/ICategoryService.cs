using MYAcademy_AirBnB.Dtos.CategoryDtos;

namespace MYAcademy_AirBnB.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}
