﻿using MAUI.Windowses;

namespace MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginWindow());
        }
    }
}
