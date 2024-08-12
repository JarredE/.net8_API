using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WebsiteAPI.Entities;
using WebsiteAPI.Interfaces;
using WebsiteAPI.models;

namespace WebsiteAPI.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly WebsiteDbContext _DBContext;
        public UserRepository(WebsiteDbContext dbcontext)
        {
            _DBContext = dbcontext;
        }

        public void AddUser(string Username, string Password)
        {
            var usernameParam = new MySqlParameter("username", Username.ToLower());
            var passwordParam = new MySqlParameter("password", Password.ToLower());

            var command = "INSERT INTO logintable(username, password) VALUES(@username, @password)";

            _DBContext.Login.FromSqlRaw(command, usernameParam, passwordParam).ToList();

        }

        //Variables

        public Task<List<login>> GetAllUsersLogin(string Username, string Password)
        { 
            return _DBContext.Login.ToListAsync();
        }

    }
}
