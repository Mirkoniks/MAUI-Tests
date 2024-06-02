using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Welcome.Others;
using DataLayer.DataBase;

namespace MAUI.ViewModels
{
    public class AdminViewModel : ObservableObject
    {
        //[Browsable(false)]
        //private StudentsList StudentList { get; set; }

        //public AdminViewModel(StudentsList studentsList)
        //{
        //    StudentList = studentsList;
        //}

        private DatabaseUser _user;

        public string Name
        {
            get => _user.Name;
            set
            {
                if (_user.Name != value)
                {
                    _user.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _user.Password;
            set
            {
                if (_user.Password != value)
                {
                    _user.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public UserRoleEnum Role
        {
            get => _user.Role;
            set
            {
                if (_user.Role != value)
                {
                    _user.Role = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StudentNumber
        {
            get => _user.StudentNumber;
            set
            {
                if (_user.StudentNumber != value)
                {
                    _user.StudentNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _user.Email;
            set
            {
                if (_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime BirthDay
        {
            get => _user.BirthDay;
            set
            {
                if (_user.BirthDay != value)
                {
                    _user.BirthDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Expires
        {
            get => _user.Expires;
            set
            {
                if (_user.Expires != value)
                {
                    _user.Expires = value;
                    OnPropertyChanged();
                }
            }
        }

        public AdminViewModel()
        {
            _user = new DatabaseUser();

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
