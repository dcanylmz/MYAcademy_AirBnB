namespace MYAcademy_AirBnB.Dtos.CityDtos
{
    public class UpdateCityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
