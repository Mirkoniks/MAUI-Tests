using DataLayer.DataBase;
using System.Windows;
using System.Windows.Controls;
using UI.ViewModel;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Others;

namespace UI.Components
{
    public partial class SystemLogin : UserControl
    {
        public SystemLogin() 
        { 
           InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            LoginViewModel vm = new LoginViewModel();

            var result = vm.LogUser(username.Text, password.Password);

            if (!result) 
            {

                MessageBox.Show("Wrong password or username", "Authentication error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                Delegates.LogLoginError(username.Name);
                return;
            }

            OpenStudentsList(vm.Role, username.Text);
            Delegates.LogLoginSuccess(username.Text);

        }

        private void OpenStudentsList(UserRoleEnum role, string name)
        {
            StudentsList studentsList = new StudentsList(role, name);

            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                ContentControl contentControl = parentWindow.FindName("MainContent") as ContentControl;

                if (contentControl != null)
                {
                    contentControl.Content = studentsList;
                }
            }
        }
    }
 }
