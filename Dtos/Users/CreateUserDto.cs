namespace RescueSystem_BE.Dtos.Users
{
    public class CreateUserDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FullName { get; set; } = "";
        public string? Phone { get; set; }
        public int RoleID { get; set; }
    }
}
