using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAVELPAL.Enums;
using TRAVELPAL.Interface;

namespace TRAVELPAL.Managers
{
    public class UserManager
    {
        public List<IUser> Users { get; set; } = new();
    }
}