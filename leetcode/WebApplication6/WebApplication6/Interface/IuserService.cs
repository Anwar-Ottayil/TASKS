namespace WebApplication6.Interface
{
    public interface IuserService
    {
        Task<string> Login(string email, string password);
    }
}
