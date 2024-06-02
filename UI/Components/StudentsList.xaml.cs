using DataLayer.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using UI.ViewModel;
using Welcome.Others;

namespace UI.Components
{
    public partial class StudentsList : Window
    {
        public UserRoleEnum Role { get; set; }
        public string Name { get; set; }

        public StudentsList(UserRoleEnum role, string name)
        {
            InitializeComponent();

            Name = name;
            Role = role;


            roleComboBox.Items.Add("Admin");
            roleComboBox.Items.Add("Student");
            roleComboBox.Items.Add("Teacher");
            roleComboBox.Items.Add("Inspector");

            roleComboBox.SelectionChanged += RoleComboBox_SelectionChanged;

            if (role == UserRoleEnum.ADMIN)
            {
                AdminViewModel model = new AdminViewModel(this);
                students.ItemsSource = model.GetAllUsers();

            }
            else if (role == UserRoleEnum.STUDENT)
            {
                StudentViewModel model = new StudentViewModel(this);
                List<StudentViewModel> student = new List<StudentViewModel>();
                student.Add(model.GetUserInfo(name));
                students.ItemsSource = student;

                if (nameTextBox != null && nameTextBox.Parent is Grid)
                    ((Grid)nameTextBox.Parent).Children.Remove(nameTextBox);

                if (roleComboBox != null && roleComboBox.Parent is Grid)
                    ((Grid)roleComboBox.Parent).Children.Remove(roleComboBox);

                if (allUsersButton != null && allUsersButton.Parent is Grid)
                    ((Grid)allUsersButton.Parent).Children.Remove(allUsersButton);

                if (dockPanel.Parent is Grid)
                {
                    ((Grid)dockPanel.Parent).Children.Remove(dockPanel);
                }
            }
        }

        public StudentsList()
        {
            InitializeComponent();
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRole = roleComboBox.SelectedItem.ToString();
            students.ItemsSource = null;

            AdminViewModel model = new AdminViewModel(this);
            students.ItemsSource = model.GetByRole(selectedRole);
        }

        private void AllUsersButton_Click(object sender, RoutedEventArgs e)
        {
            students.ItemsSource = null;
            AdminViewModel model = new AdminViewModel(this);
            students.ItemsSource = model.GetAllUsers();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            SystemLogin studentsList = new SystemLogin();

            Window parentWindow = this;

            if (parentWindow != null)
            {
                ContentControl contentControl = parentWindow.FindName("MainContent") as ContentControl;

                if (contentControl != null)
                {
                    contentControl.Content = studentsList;
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
    }
}
