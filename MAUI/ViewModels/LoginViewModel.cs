using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLayer.DataBase;
using DataLayer.Model;
using Microsoft.Maui.Controls;
//using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.Others;
using WelcomeExtended.Others;

namespace MAUI.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private DatabaseUser _user;
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            _user = new DatabaseUser();
            //LoginCommand = new AsyncRelayCommand(Login);
        }

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

        //public async Task<bool> Login() 
        //{

        //    var result = _user.Login(Name, Password);

        //    if (!result)
        //    {

        //        MessageBox.Show("Wrong password or username", "Authentication error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        //        Delegates.LogLoginError(username.Name);
        //        return;
        //    }

        //    OpenStudentsList(vm.Role, username.Text);
        //    Delegates.LogLoginSuccess(username.Text);
        //}

        //private void OpenStudentsList(UserRoleEnum role, string name)
        //{
        //    StudentsList studentsList = new StudentsList(role, name);

        //    Window parentWindow = Window.GetWindow(this);

        //    if (parentWindow != null)
        //    {
        //        ContentControl contentControl = parentWindow.FindByName("MainContent") as ContentControl;

        //        if (contentControl != null)
        //        {
        //            contentControl.Content = studentsList;
        //        }
        //    }
        //}
    }
}
