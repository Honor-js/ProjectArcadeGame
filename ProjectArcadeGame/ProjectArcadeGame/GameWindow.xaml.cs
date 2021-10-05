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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjectArcadeGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private ImageBrush PlayerSkin = new ImageBrush();
        private bool MoveLeft, MoveRight, MoveUp, MoveDown;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        public GameWindow()
        {
            InitializeComponent();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16.6);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();

            PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
            Player.Fill = PlayerSkin;
        }

        private void GameEngine(object sender, EventArgs press)
        {
            if (MoveLeft)
                Canvas.SetRight(Player, Canvas.GetRight(Player) + 10);
            if (MoveRight)
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 10);
        }

        private void KeyPress(object sender, KeyEventArgs press)
        {
            if (press.Key == Key.Left)
                MoveLeft = true;
            if (press.Key == Key.Right)
                MoveRight = true;
        }

        private void KeyRelease(object sender, KeyEventArgs press)
        {
            if (press.Key == Key.Left)
                MoveLeft = false;
            if (press.Key == Key.Right)
                MoveRight = false;
        }
    }
}
