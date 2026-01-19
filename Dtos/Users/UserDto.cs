namespace RescueSystem_BE.Dtos.Users
{
    public class UserDto
    {
        public Guid UserID { get; set; }
        public string Username { get; set; } = "";
        public string FullName { get; set; } = "";
        public string? Phone { get; set; }
        public string RoleName { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
