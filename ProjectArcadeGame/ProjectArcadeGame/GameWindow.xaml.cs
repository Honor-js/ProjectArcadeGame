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
        private bool MoveLeft = false, MoveRight = false, MoveUp = false, MoveDown = false, Jumping = false;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        int Force = 10;
        int Speed = 8;
        int JumpSpeed = 10;

        #region KeyEvents
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
        #endregion

        

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
            double GroundTop = Canvas.GetTop(Ground);

            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                if (x.Tag != null)
                {
                    var Tag = (string)x.Tag;
                    if (Tag == "Platform")
                    {
                        Rect PlayerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                        Rect PlatformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    }
                }
            }

            if (MoveLeft && LeftPos > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - Speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/Mario_left.png"));
                Player.Fill = PlayerSkin;
            }

            if (MoveRight)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + Speed);
                PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
                Player.Fill = PlayerSkin;

            }
            
            if (MoveUp && Jumping == false && Force > 0)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - JumpSpeed);
                JumpSpeed -= 1;
                Force -= 1;
            }

            if (Force < 1)
            {
                Jumping = true;
                Canvas.SetTop(Player, Canvas.GetTop(Player) + JumpSpeed);
                JumpSpeed += 1;
            }
        }
    }
}
