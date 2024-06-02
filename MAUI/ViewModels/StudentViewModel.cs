using CommunityToolkit.Mvvm.ComponentModel;
using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using DataLayer.Model;
using System.Xml.Linq;

namespace MAUI.ViewModels
{
    public class StudentViewModel : ObservableObject
    {
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


        //[Browsable(false)]
        //private StudentsList StudentList { get; set; }

        //public StudentViewModel(StudentsList studentsList)
        //{
        //    StudentList = studentsList;
        //}

        public StudentViewModel()
        {
            _user = new DatabaseUser();
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
