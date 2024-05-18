using System.Windows;
using System.Windows.Controls;
using UI.ViewModel;
using Welcome.Others;

namespace UI.Components
{
    public partial class AddUser : UserControl
    {
        public UserRoleEnum Role { get; set; }
        public string Name { get; set; }

        public AddUser(UserRoleEnum role, string name)
        {
            InitializeComponent();
            Name = name;
            Role = role;
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string pass = passwordTextBox.Text;
            string role = (string)((ComboBoxItem)roleComboBox.SelectedItem).Content;
            string studentNumber = studentNumberTextBox.Text;
            string email = emailTextBox.Text;
            DateTime birthDay = birthDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime expires = expiresDatePicker.SelectedDate ?? DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Password cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Role cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(studentNumber))
            {
                MessageBox.Show("Studnet number cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (birthDay == null)
            {
                MessageBox.Show("BirthDay cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (birthDay > DateTime.UtcNow)
            {
                MessageBox.Show("BirthDay cannot be in the future!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (expires == null)
            {
                MessageBox.Show("Expires cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (expires < DateTime.UtcNow)
            {
                MessageBox.Show("Expires cannot be in the past!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AdminViewModel vm = new AdminViewModel();

            vm.Email = email;
            vm.Expires = expires;
            vm.Role = GetUserRoleFromString(role);
            vm.BirthDay = birthDay;
            vm.Name = name;
            vm.Password = pass;
            vm.StudentNumber = studentNumber;

            bool result = vm.CreateUser();

            if (result)
            {
                nameTextBox.Text = "";
                passwordTextBox.Text = "";
                studentNumberTextBox.Text = "";
                emailTextBox.Text = "";

                birthDatePicker.SelectedDate = null;
                expiresDatePicker.SelectedDate = null;
                MessageBox.Show("User created succsessfully!");
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

        private UserRoleEnum GetUserRoleFromString(string roleString)
        {
            switch (roleString.ToLower())
            {
                case "Admin":
                    return UserRoleEnum.ADMIN;
                case "Inspector":
                    return UserRoleEnum.INSPECTOR;
                case "Professor":
                    return UserRoleEnum.PROFESSOR;
                case "Student":
                    return UserRoleEnum.STUDENT;
            }

            return UserRoleEnum.STUDENT;
        }
    }
}
