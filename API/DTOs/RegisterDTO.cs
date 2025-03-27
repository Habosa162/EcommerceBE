namespace ECommerce.API.DTOs
{
    public class RegisterDTO
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string? ProfileIamge { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; } = false;


    }
}
