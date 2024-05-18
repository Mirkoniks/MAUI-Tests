using DataLayer.DataBase;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Welcome.Others;

namespace UI.Components
{
    public partial class LogMessages : UserControl
    {
        public ObservableCollection<string> LogDates { get; } 
        public ObservableCollection<string> LogMessagesCollection { get; }

        public UserRoleEnum Role { get; set; }
        public string Name { get; set; }


        public LogMessages(UserRoleEnum role, string name)
        {
            InitializeComponent();

            LogDates = new ObservableCollection<string>();
            LogMessagesCollection = new ObservableCollection<string>();

            UpdateLogMessages();

            logListBox.ItemsSource = LogDates;

            logListBox.MouseDoubleClick += LogListBox_MouseDoubleClick;

            Name = name;
            Role = role;
        }

        private void UpdateLogMessages()
        {
            using (var context = new DatabaseContext())
            {
                var logEvents = context.LogMessages.ToList();

                logEvents.Reverse();

                foreach (var logEvent in logEvents)
                {
                    LogDates.Add(logEvent.CreatedOn.ToString("dd-MM-yyyy")); 
                    LogMessagesCollection.Add(logEvent.Message);
                }
            }
        }

        private void LogListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = logListBox.SelectedIndex;

            if (index >= 0 && index < LogMessagesCollection.Count)
            {
                MessageBox.Show(LogMessagesCollection[index], "Log Message", MessageBoxButton.OK, MessageBoxImage.Information);
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
