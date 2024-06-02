using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Components;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Others;

namespace UI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private User user;

        private PasswordBox password;
        private string username;

        public UserRoleEnum Role { get; set; }

        public string Username
        {
            get => username;

            set
            {
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public PasswordBox Password
        {
            get => password  ;

            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<PasswordBox>(s => Login(s.Password.ToString()));
            user = new User();
            password = new PasswordBox();
            username = string.Empty;
        }



        public bool LogUser(string password) 
        {
            using (var db = new DatabaseContext())
            {
                var user = db.Users.Where(u => u.Name == Username).FirstOrDefault();


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


        private void Login(string password)
        {

            LoginViewModel vm = new LoginViewModel();

            var result = vm.LogUser(password);

            if (!result)
            {

                MessageBox.Show("Wrong password or username", "Authentication error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                Delegates.LogLoginError(Username);
                return;
            }

            OpenStudentsList(vm.Role, Username);
            Delegates.LogLoginSuccess(Username);

        }

        private void OpenStudentsList(UserRoleEnum role, string name)
        {
            StudentsList studentsList = new StudentsList(role, name);

            studentsList.Show();

            //Window parentWindow = Window.GetWindow(this);

            //if (parentWindow != null)
            //{
            //    ContentControl contentControl = parentWindow.FindName("MainContent") as ContentControl;

            //    if (contentControl != null)
            //    {
            //        contentControl.Content = studentsList;
            //    }
            //}
        }
    }
}
