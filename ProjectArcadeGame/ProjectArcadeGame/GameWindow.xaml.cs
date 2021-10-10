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
        private ImageBrush GroundSkin = new ImageBrush();
        private ImageBrush PlayerSkinLeft = new ImageBrush();
        private bool MoveLeft = false, MoveRight = false, MoveUp = false, MoveDown = false;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        int gravity = 20;
        int force;
        const int speed = 8;
       
        


        private void KeyPress(object sender, KeyEventArgs press)
        {
            if (press.Key == Key.Left)
                MoveLeft = true;
            if (press.Key == Key.Right)
                MoveRight = true;
            if (press.Key == Key.Up)
                MoveUp = true;
            if (press.Key == Key.Down)
                MoveDown = true;
        }

        private void KeyRelease(object sender, KeyEventArgs press)
        {
            if (press.Key == Key.Left)
                MoveLeft = false;
            if (press.Key == Key.Right)
                MoveRight = false;
            if (press.Key == Key.Up)
                MoveUp = false;
            if (press.Key == Key.Down)
                MoveDown = false;
        }

        public GameWindow()
        {
            InitializeComponent();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16.6);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();

            GameCanvas.Focus();

            PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
            Player.Fill = PlayerSkin;
            GroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario_ground1.png"));
            Ground.Fill = GroundSkin;
           
        }

        private void GameEngine(object sender, EventArgs press)
        {
            double TopPos = Canvas.GetTop(Player);
            double LeftPos = Canvas.GetLeft(Player);
            //todo left en right images maken en testen
            if (MoveLeft && LeftPos > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/Mario_left.png"));
                Player.Fill = PlayerSkin;
            }

            if (MoveRight)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
                Player.Fill = PlayerSkin;

            }

            //todo jump fixen want werkt niet goed
            if (MoveUp && gravity > 0 && TopPos > 10)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - speed);
                MoveUp = true;
            }
            else
            {
                MoveUp = false;
                gravity = 20;
            }

            if (MoveUp == false && TopPos < 296)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + speed);
            }

        }
    }
}
