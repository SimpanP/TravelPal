using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAVELPAL.Classes;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Managers
{
    public class UserManager
    {
        public List<IUser> Users { get; set; } = new();
        public IUser signedInUser { get; set; }


        public bool AddUser(string username, string password, Countries countries)
        {
            if (ValidateUsername(username))
            {
                User user = new(username, password, countries);
            }
        }


        private bool ValidateUsername(string username)
        {
            foreach (IUser user in Users)
            {
                if (user.UserName == username)
                {
                    return false;
                }
            }

            return true;
        }
    }
}