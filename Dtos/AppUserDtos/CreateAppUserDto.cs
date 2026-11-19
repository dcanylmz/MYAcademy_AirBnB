namespace MYAcademy_AirBnB.Dtos.AppUserDtos
{
    public class CreateAppUserDto
    {
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
    }
}
