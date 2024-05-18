using DataLayer.DataBase;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using UI.Components;
using Welcome.Others;

namespace UI.ViewModel
{
    public class AdminViewModel 
    {
        [Browsable(false)]
        private StudentsList StudentList { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime Expires { get; set; }

        public AdminViewModel(StudentsList studentsList)
        {
            StudentList = studentsList;
        }

        public AdminViewModel()
        {

        }

        public List<AdminViewModel> GetAllUsers() 
        {
            using (var context = new DatabaseContext())
            {
                var records = context.Users.ToList();

                List<AdminViewModel> vms = new List<AdminViewModel>();

                foreach (var record in records) 
                {
                    AdminViewModel vm = new AdminViewModel();

                    vm.Password = record.Encrypt(record.Password);
                    vm.Name = record.Name;
                    vm.Expires = record.Expires;
                    vm.Role = record.Role;
                    vm.StudentNumber = record.StudentNumber;
                    vm.Email = record.Email;
                    vm.BirthDay = record.BirthDay;

                    vms.Add(vm);
                }

                return vms;
            }
        }

        public List<AdminViewModel> GetByRole(string role)
        {
            using (var context = new DatabaseContext())
            {
                List<DatabaseUser> records = new List<DatabaseUser>();

                switch (role) 
                {
                    case "Admin":
                        records = context.Users.Where(u => u.Role == UserRoleEnum.ADMIN).ToList();
                        break;
                    case "Student":
                        records = context.Users.Where(u => u.Role == UserRoleEnum.STUDENT).ToList();
                        break;
                    case "Inspector":
                        records = context.Users.Where(u => u.Role == UserRoleEnum.INSPECTOR).ToList();
                        break;
                    case "Professor":
                        records = context.Users.Where(u => u.Role == UserRoleEnum.PROFESSOR).ToList();
                        break;
                }

                List<AdminViewModel> vms = new List<AdminViewModel>();

                foreach (var record in records)
                {
                    AdminViewModel vm = new AdminViewModel();

                    vm.Password = record.Encrypt(record.Password);
                    vm.Name = record.Name;
                    vm.Expires = record.Expires;
                    vm.Role = record.Role;
                    vm.StudentNumber = record.StudentNumber;
                    vm.Email = record.Email;
                    vm.BirthDay = record.BirthDay;

                    vms.Add(vm);
                }

                return vms;
            }
        }

        public bool CreateUser() 
        {

            using (var context = new DatabaseContext())
            {

                var user = new DatabaseUser()
                {
                    Name = Name,
                    Password = Password,
                    Role = Role,
                    Expires = Expires,
                    BirthDay = BirthDay,
                    Email = Email,
                    StudentNumber = StudentNumber
                };

                context.Add<DatabaseUser>(user);
                var result = context.SaveChanges() > 0;

                return result;
            }
        }
    }
}
