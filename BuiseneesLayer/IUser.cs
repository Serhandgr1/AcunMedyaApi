using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiseneesLayer
{
    public interface IUser
    {
        string Name(int Id);
        UserModel User(int Id);
        void PostUser(UserModel userModel);
        void UserDelete(int Id);
        UserModel UpdateUser(UserModel userModel);
    }
}
