using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MYAcademy_AirBnB.Dtos.CategoryDtos;
using MYAcademy_AirBnB.Dtos.HouseDtos;
using MYAcademy_AirBnB.Entities;
using MYAcademy_AirBnB.Services.Abstract;
using MYAcademy_AirBnB.Settings;

namespace MYAcademy_AirBnB.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IOptions<MongoDBSettings> mongoDbSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var MongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _categoryCollection = MongoDatabase.GetCollection<Category>(mongoDbSettings.Value.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.ReplaceOneAsync(x => x.CategoryId == updateCategoryDto.CategoryId, value);
        }
    }
}
