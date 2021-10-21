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
        /*Player1*/
        private bool MoveLeft = false, MoveRight = false, MoveUp = false, Jumping = false;      
        int Force = 10;
        int Speed = 8;
        int JumpSpeed = 10;
        /*Player2*/
        private bool MoveLeft2 = false, MoveRight2 = false, MoveUp2 = false, Jumping2 = false;
        int Force2 = 10;
        int JumpSpeed2 = 10;
        private DispatcherTimer GameTimer = new DispatcherTimer();

        #region KeyEvents
        private void KeyPress(object sender, KeyEventArgs press)
        {
            //Player1
            if (press.Key == Key.Left)
                MoveLeft = true;
            if (press.Key == Key.Right)
                MoveRight = true;
            if (press.Key == Key.Up)
                MoveUp = true;
            //Player2
            if (press.Key == Key.A)
                MoveLeft2 = true;
            if (press.Key == Key.D)
                MoveRight2 = true;
            if (press.Key == Key.W)
                MoveUp2 = true;
        }

        private void KeyRelease(object sender, KeyEventArgs press)
        {
            //Player1
            if (press.Key == Key.Left)
                MoveLeft = false;
            if (press.Key == Key.Right)
                MoveRight = false;
            if (press.Key == Key.Up)
                MoveUp = false;
            //Player2
            if (press.Key == Key.A)
                MoveLeft2 = false;
            if (press.Key == Key.D)
                MoveRight2 = false;
            if (press.Key == Key.W)
                MoveUp2 = false;
        }
        #endregion


        public GameWindow()
        {
            InitializeComponent();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16.6);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();

            GameCanvas.Focus();


            //Player1
            PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
            Player.Fill = PlayerSkin;
            GroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario_ground1.png"));
            Ground.Fill = GroundSkin;

            //Player2
            //PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
            //Player2.Fill = PlayerSkin;
            GroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario_ground1.png"));
            //Ground2.Fill = GroundSkin;

        }

        private void GameEngine(object sender, EventArgs press)
        {
            //Player1
            double TopPos = Canvas.GetTop(Player);
            double LeftPos = Canvas.GetLeft(Player);
            double GroundTop = Canvas.GetTop(Ground);
            //Player2
            double LeftPos2 = Canvas.GetLeft(Player2);

            Rect PlayerHitBox ;
            Rect PlatformHitBox ;
            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                if (x.Tag != null)
                {
                    var Tag = (string)x.Tag;
                    if (Tag == "Platform")
                    {
                        Rect PlayerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                        Rect PlatformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        
                        if (PlayerHitBox.IntersectsWith(PlatformHitBox))
                        {
                            Force = 10;
                            JumpSpeed = 10;
                            Jumping = false;
                        }
                    }
                }
            }

            //Player1 MoveLeft
            if (MoveLeft && LeftPos > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - Speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/Mario_left.png"));
                Player.Fill = PlayerSkin;
            }
            //Player2 MoveLeft
            if (MoveLeft2 && LeftPos2 > 5)
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - Speed);
                //PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/Mario_left.png"));
                //Player.Fill = PlayerSkin;
            }

            //Player1 MoveRight
            if (MoveRight)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + Speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
                Player.Fill = PlayerSkin;
            }
            //Player2 MoveRight
            if (MoveRight2)
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) + Speed);
                //PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
                //Player.Fill = PlayerSkin;
            }

            //Player1
            if (MoveUp && Jumping == false && Force > 0)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - JumpSpeed);
                JumpSpeed -= 1;
                Force -= 1;
            }

            //Player1
            if (Force < 1)
            {
                Jumping = true;
                Canvas.SetTop(Player, Canvas.GetTop(Player) + JumpSpeed);
                JumpSpeed += 1;
                Force += 1;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
