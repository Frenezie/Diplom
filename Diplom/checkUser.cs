using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class checkUser
    {
        public string Login_User { get; set; }
        public bool Is_Admin {get;}
        public string Status => Is_Admin ? "Админ" : "Пользователь";
        
        public checkUser(string login, bool IsAdmin) 
        {
            Login_User = login.Trim();
            Is_Admin = IsAdmin;
        }

    }
}
