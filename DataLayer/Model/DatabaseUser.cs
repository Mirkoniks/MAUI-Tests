using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace DataLayer.Model
{
    public class DatabaseUser : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Login(string name, string password)
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.Where(u => u.Name == name).FirstOrDefault();


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
