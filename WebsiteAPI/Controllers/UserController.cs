using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using Org.BouncyCastle.Security;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using WebsiteAPI.Entities;
using WebsiteAPI.Interfaces;
using WebsiteAPI.models;
using WebsiteAPI.Repository;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    //Imports for the Interfaces
    private readonly IUserInterface _UserRepository;

    //variables
    public bool IsEmployee;

    public UserController(WebsiteDbContext dbcontext, IUserInterface userRepository)
    {
        _UserRepository = userRepository;
       
    }
    //Gets and checks the users login
    [HttpPost("GetLogin")]
    public async Task<dynamic> CheckLogin(string Username, string Password) {

        var dater = await _UserRepository.GetAllUsersLogin(Username.ToLower(), Password.ToLower());

        for (int i = 0; i < dater.Count; i++) {
            if (dater[i].username == Username && dater[i].password == Password) { 
               IsEmployee = true;
            }
        }

        return IsEmployee;
    }

    [HttpPost("AddUser")]
    public async Task<dynamic> AdduserToTable(string Username, string Password) {

            _UserRepository.AddUser(Username.ToLower(), Password.ToLower());
  
        return StatusCode(200);
    }
}
