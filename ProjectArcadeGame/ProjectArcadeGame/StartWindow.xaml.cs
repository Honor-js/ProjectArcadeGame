﻿using System;
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
using System.Windows.Shapes;

namespace ProjectArcadeGame
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public static string PlayerName1;
        public static string PlayerName2;
        public StartWindow()
        {
            
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            PlayerName1 = Name1.Text;
            PlayerName2 = Name2.Text;
            GameWindow gameWindow = new GameWindow();
            gameWindow.Visibility = Visibility.Visible;
            this.Close();
        }

    }
}
