namespace TaskTrackingSystem.BLL.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string id);
    }
}