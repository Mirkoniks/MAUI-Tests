using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Welcome.Others;
using WelcomeExtended.Others;

namespace UI.ViewModel
{
    public class LoginViewModel
    {
        public UserRoleEnum Role { get; set; }

        public LoginViewModel()
        {
            
        }


        public bool LogUser(string username, string password) 
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.Where(u => u.Name == username).FirstOrDefault();


                if (user != null)
                {
                    Role = user.Role;
                    
                    if (user.Password == password)
                    {

                        return true;

                    }
                }
                return false;
            }
        }
    }
}
