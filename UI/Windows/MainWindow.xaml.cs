﻿using DataLayer.DataBase;
using System.Windows;
using UI.Components;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContent.Content = new SystemLogin();

        }
    }
}
