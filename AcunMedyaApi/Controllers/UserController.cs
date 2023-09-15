using BuiseneesLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace AcunMedyaApi.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController()
        {
            _user = new BuiseneesCodes();
        }
        [HttpGet("user-name")]
        public async Task<string> GetUserByName(int Id)
        {
            return await _user.UserName(Id);
        }
        [HttpGet("User")]
        public async Task<UserModel> GetUser(int Id)
        {
            return await _user.User(Id);
        }
        [HttpPost("user-post")]
        public async Task<string> UserPost(UserModel userModel)
        {
            await _user.PostUser(userModel);
            return "USER KAYIT BAŞARILI";
        }
        [HttpPost("login-user")]
        public async Task<int> LoginUser(string userName, string password)
        {
            return await _user.LoginUser(userName, password);
        }
        [HttpPut("user-update")]
        public async Task<UserModel> UpdateUser(UserModel userModel)
        {
            return await _user.UpdateUser(userModel);
        }

        [HttpDelete("user-delete")]
        public async Task<string> UserDelete(int Id)
        {
            await _user.UserDelete(Id);
            return "USER silindi";
        }
    }
}
