namespace TaskTrackingSystem.BLL.DTOs
{
    /// <summary>
    /// Register data transfer object
    /// </summary>
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}