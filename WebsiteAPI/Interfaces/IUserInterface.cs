using WebsiteAPI.models;

namespace WebsiteAPI.Interfaces
   
{
    public interface IUserInterface
    {
        Task<List<login>> GetAllUsersLogin(string Username, string Password);
        void AddUser(string Username, string Password);
    }
}
