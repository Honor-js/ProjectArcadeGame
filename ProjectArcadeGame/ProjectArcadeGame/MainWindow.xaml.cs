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

namespace ProjectArcadeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void How_Click(object sender, RoutedEventArgs e)
        {
            HowToPlay howToPlay = new HowToPlay();
            howToPlay.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {
            Highscores highscores = new Highscores();
            highscores.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
