using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MYAcademy_AirBnB.Dtos.CategoryDtos;
using MYAcademy_AirBnB.Dtos.HouseDtos;
using MYAcademy_AirBnB.Entities;
using MYAcademy_AirBnB.Services.Abstract;
using MYAcademy_AirBnB.Settings;
using SharpCompress.Compressors.ZStandard.Unsafe;

namespace MYAcademy_AirBnB.Services.Concrete
{
    public class HouseService : IHouseService
    {
        private readonly IMongoCollection<House> _houseCollection;
        private readonly IMapper _mapper;

        public HouseService(IOptions<MongoDBSettings> mongoDbSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _houseCollection = mongoDatabase.GetCollection<House>(mongoDbSettings.Value.HouseCollectionName);
            _mapper = mapper;
        }
        public async Task CreateHouseAsync(CreateHouseDto createHouseDto)
        {
            var houses = _mapper.Map<House>(createHouseDto);
            await _houseCollection.InsertOneAsync(houses);
        }

        public async Task DeleteHouseAsync(string id)
        {
            await _houseCollection.DeleteOneAsync(x => x.HouseId == id);
        }

        public async Task<List<ResultHouseDto>> GetAllHousesAsync()
        {
            var values = await _houseCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultHouseDto>>(values);
        }

        public async Task<GetByIdHouseDto> GetByIdHouseAsync(string id)
        {
            var value = await _houseCollection.Find(x => x.HouseId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdHouseDto>(value);

        }

        public async Task UpdateHouseAsync(UpdateHouseDto updateHouseDto)
        {
            var value = _mapper.Map<House>(updateHouseDto);
            await _houseCollection.ReplaceOneAsync(x => x.HouseId == updateHouseDto.HouseId, value);
        }
    }
}
