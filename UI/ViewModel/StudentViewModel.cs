using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Components;
using Welcome.Others;

namespace UI.ViewModel
{
    public class StudentViewModel
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

        public StudentViewModel(StudentsList studentsList)
        {
            StudentList = studentsList;
        }

        public StudentViewModel()
        {

        }

        public StudentViewModel GetUserInfo(string name)
        {
            using (var context = new DatabaseContext())
            {
                var record = context.Users.Where(u => u.Name == name).FirstOrDefault();

                StudentViewModel vm = new StudentViewModel();

                if (record == null) 
                {
                    return vm;
                }

                vm.Password = record.Encrypt(record.Password);
                vm.Name = record.Name;
                vm.Expires = record.Expires;
                vm.Role = record.Role;
                vm.StudentNumber = record.StudentNumber;
                vm.Email = record.Email;
                vm.BirthDay = record.BirthDay;


                return vm;
            }
        }
    }
}
