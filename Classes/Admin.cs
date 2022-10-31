﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Classes
{
    public class Admin : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public Admin(string userName, string password, Countries location)
        {
            UserName = userName;
            Password = password;
            Location = location;
        }
    }
}