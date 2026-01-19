namespace RescueSystem_BE.Dtos.Users
{
    public class UpdateUserDto
    {
        public string FullName { get; set; } = "";
        public string? Phone { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
