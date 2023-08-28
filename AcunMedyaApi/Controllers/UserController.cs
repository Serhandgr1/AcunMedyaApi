using BuiseneesLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("user-name")]
        public string GetUserByName(int Id)
        {
            IUser user = new BuiseneesCodes();
            return user.Name(Id);
        }
        [HttpGet("User")]
        public UserModel GetUser(int Id)
        {
            IUser user = new BuiseneesCodes();
            return user.User(Id);
        }
        [HttpPost("user-post")]
        public string UserPost(UserModel userModel)
        {
            IUser user = new BuiseneesCodes();
            user.PostUser(userModel);
            return "USER KAYIT BAŞARILI";
        }
        [HttpPut("user-update")]
        public UserModel UpdateUser(UserModel userModel)
        {
            IUser user = new BuiseneesCodes();
            return user.UpdateUser(userModel);
        }

        [HttpDelete("user-delete")]
        public string UserDelete(int Id)
        {
            IUser user = new BuiseneesCodes();
            user.UserDelete(Id);
            return "USER silindi";
        }
    }
}
