using DataLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Welcome.Others;

namespace UI.Components
{
    public partial class RemoveUser : UserControl
    {
        public UserRoleEnum Role { get; set; }
        public string Name { get; set; }

        public RemoveUser(UserRoleEnum role, string name)
        {
            InitializeComponent();

            Name = name;
            Role = role;
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = userNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter the user name to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var context = new DatabaseContext())
            {
                var userToRemove = context.Users.FirstOrDefault(u => u.Name == userName);

                if (userToRemove == null)
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                context.Users.Remove(userToRemove);
                var result = context.SaveChanges() > 0;

                if (result)
                {
                    MessageBox.Show("User removed successfully!");
                    userNameTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to remove user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemoveUserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RemoveUser studentsList = new RemoveUser(Role, Name);

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
        private void AddUserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddUser studentsList = new AddUser(Role, Name);

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

        private void HomeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StudentsList studentsList = new StudentsList(Role, Name);

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
        private void LogsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LogMessages studentsList = new LogMessages(Role, Name);

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
