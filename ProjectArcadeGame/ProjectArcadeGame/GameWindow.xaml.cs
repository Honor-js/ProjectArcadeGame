using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
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
        private ImageBrush PlayerSkin = new ImageBrush(); //Mario 
        private ImageBrush Player2Skin = new ImageBrush(); //Luigi
        private ImageBrush GroundSkin = new ImageBrush(); //Ground
        private ImageBrush ObstacleSkin = new ImageBrush(); //Coin
        private ImageBrush PipeSkin = new ImageBrush(); //Pipe
        private ImageBrush GoombaSkin = new ImageBrush(); // Goomba, 1st obstacle
        private ImageBrush FinishSkin = new ImageBrush(); //Peach
        //private ImageBrush PlayerSkinLeft = new ImageBrush();

        int Speed = 8;
        /*Player1*/
        private bool MoveLeft = false, MoveRight = false, MoveUp = false, P1Finish = false;      
        int Force = 10;
        int JumpSpeed = 10;
        int BaseTop = 296;
        private int time;
        string Name1 = StartWindow.PlayerName1;
        string WL1;
        
        /*Player2*/
        private bool MoveLeft2 = false, MoveRight2 = false, MoveUp2 = false, P2Finish = false;
        int Force2 = 10;
        int JumpSpeed2 = 10;
        int BaseTop2 = 296;
        string Name2 = StartWindow.PlayerName2;
        string WL2;

        //Timers
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private DispatcherTimer TimerPlayer1 = new DispatcherTimer();
        private DispatcherTimer TimerPlayer2 = new DispatcherTimer();
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
            //if (press.Key == Key.Up)
                //MoveUp = false;
            //Player2
            if (press.Key == Key.A)
                MoveLeft2 = false;
            if (press.Key == Key.D)
                MoveRight2 = false;
            //if (press.Key == Key.W)
                //MoveUp2 = false;
        }
        #endregion


        public GameWindow()
        {
            InitializeComponent();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16.6);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();

            GameCanvas.Focus();

            TimerPlayer1.Interval = TimeSpan.FromSeconds(1);
            TimerPlayer1.Tick += Timer1;
            TimerPlayer2.Interval = TimeSpan.FromSeconds(1);
            TimerPlayer2.Tick += Timer2;
            TimerPlayer1.Start();
            TimerPlayer2.Start();

            //Player1
            PlayerSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario.png"));
            Player.Fill = PlayerSkin;
            GroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario_ground1.png"));
            Ground.Fill = GroundSkin;

            //Player2
            Player2Skin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/luigi.png"));
            Player2.Fill = Player2Skin;
            GroundSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/mario_ground1.png"));
            Ground2.Fill = GroundSkin;

            //Coin
            ObstacleSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/coin.png"));
            Coin1.Fill = ObstacleSkin;
            Coin2.Fill = ObstacleSkin;

            //Peach Checkpoint
            FinishSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/peach.png"));
            Peach1.Fill = FinishSkin;
            Peach2.Fill = FinishSkin;

            //Pipe
            PipeSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/pipe.png"));
            PipeM1.Fill = PipeSkin;
            PipeL1.Fill = PipeSkin;
            
            //Goomba 
            GoombaSkin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/goomba.png"));
            GoombaM1.Fill = GoombaSkin;
            GoombaL1.Fill = GoombaSkin;
        }
        
        private void GameEngine(object sender, EventArgs press)
        {
            #region Game Logic
            //Player1
            double CurrentTop = Canvas.GetTop(Player);
            double LeftPos = Canvas.GetLeft(Player);
            double GoombaM_1 = Canvas.GetLeft(GoombaM1);
            double Peach_1 = Canvas.GetLeft(Peach1);
            double PipeM_1 = Canvas.GetLeft(PipeM1);

            //Player2
            double CurrentTop2 = Canvas.GetTop(Player2);
            double LeftPos2 = Canvas.GetLeft(Player2);
            double GoombaL_1 = Canvas.GetLeft(GoombaL1);
            double Peach_2 = Canvas.GetLeft(Peach2);
            double PipeL_1 = Canvas.GetLeft(PipeL1);

            //Player1
            if (P1Finish == false) // Player 1 not reached Peach
            {
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

            //Jump
            if (MoveUp == true && JumpSpeed > 0/* && Force == 10*/)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - JumpSpeed);
                JumpSpeed -= 1;
                Force -= 1;
            }

            if (MoveUp == true && JumpSpeed == 0 && Force <= 10)
            {
                //Jumping = true;
                Canvas.SetTop(Player, Canvas.GetTop(Player) + Force);
                //JumpSpeed += 1;
                Force += 1;
                if (Force > 10 || CurrentTop >= BaseTop)
                {
                    JumpSpeed = 10;
                    Force = 10;
                    MoveUp = false;
                }
            }
            }
            if (LeftPos >= Peach_1)
            {
                P1Finish = true;
                TimerPlayer1.Stop();

            }

            //Player2
            if (P2Finish == false) // Player 2 not reached Peach
            {
                if (MoveLeft2 && LeftPos2 > 5)
                {
                    Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - Speed);
                    Player2Skin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/luigi_left.png"));
                    Player2.Fill = Player2Skin;
                }

                if (MoveRight2)
                {
                    Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) + Speed);
                    Player2Skin.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Characters/luigi.png"));
                    Player2.Fill = Player2Skin;

                }

                //Jump
                if (MoveUp2 == true && JumpSpeed2 > 0/* && Force == 10*/)
                {
                    Canvas.SetTop(Player2, Canvas.GetTop(Player2) - JumpSpeed2);
                    JumpSpeed2 -= 1;
                    Force2 -= 1;
                }

                if (MoveUp2 == true && JumpSpeed2 == 0 && Force2 <= 10)
                {
                    //Jumping = true;
                    Canvas.SetTop(Player2, Canvas.GetTop(Player2) + Force2);
                    //JumpSpeed += 1;
                    Force2 += 1;
                    if (Force2 > 10 || CurrentTop2 >= BaseTop2)
                    {
                        JumpSpeed2 = 10;
                        Force2 = 10;
                        MoveUp2 = false;
                    }
                }
            }
            if (LeftPos2 >= Peach_2)
            {
                P2Finish = true;
                TimerPlayer2.Stop();
               
            }
            #region Victory Conditions
            if (P1Finish == true && P2Finish == true) // Calculates the quickest time
            {
                if (count1 < count2)
                {
                    WL1 = "Win";
                    WL2 = "Lose";
                    AddHighscoreToDatabase(count1, Name1,WL1);
                    AddHighscoreToDatabase(count2, Name2,WL2);
                    MessageBox.Show("Player 1 wins!");
                    Close();
                }
                else
                {
                    WL1 = "Lose";
                    WL2 = "Win";
                    AddHighscoreToDatabase(count1, Name1,WL1);
                    AddHighscoreToDatabase(count2, Name2,WL2);
                    MessageBox.Show("Player 2 wins!");
                    Close();
                }
                #endregion
            }
            #endregion


            #region Obstacle Logic
            //Player1
            if ((LeftPos >= GoombaM_1 - 75 && LeftPos <= GoombaM_1 + 50 && MoveUp == false) //Goomba 1
                )
            {
                Canvas.SetLeft(Player, 10);
                Canvas.SetTop(Player, 296);
                JumpSpeed = 10;
                Force = 10;
                MoveUp = false;
            }
            if (LeftPos >= PipeM_1 - 75 && LeftPos <= PipeM_1 + 50 /*Pipe 1*/)
            {
                BaseTop = 221;
            }
            else if (MoveUp == false)
            {
                BaseTop = 296;
                Canvas.SetTop(Player, 296);
            }

            //Player2
            if ((LeftPos2 >= GoombaL_1 - 75 && LeftPos2 <= GoombaL_1 + 50 && MoveUp2 == false) //Goomba 1
                )
            {
                Canvas.SetLeft(Player2, 10);
                Canvas.SetTop(Player2, 296);
                JumpSpeed2 = 10;
                Force2 = 10;
                MoveUp2 = false;
            }
            if (LeftPos2 >= PipeL_1 - 75 && LeftPos2 <= PipeL_1 + 50 /*Pipe 1*/)
            {
                BaseTop2 = 221;
            }
            else if (MoveUp2 == false)
            {
                BaseTop2 = 296;
                Canvas.SetTop(Player2, 296);
            }
            #endregion
        }

        #region timers
        int count1 = 0;
        int count2 = 0;
        private void Timer1 (object sender, EventArgs e)
        {
            count1++;
            Time1.Content = string.Format("{0}:{1}", count1 / 60, count1 % 60);
        }
        private void Timer2(object sender, EventArgs e)
        {
            count2++;
            Time2.Content = string.Format("{0}:{1}", count2 / 60, count2 % 60);
        }
        #endregion timers

        #region Button Logic
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //Player1
            Canvas.SetLeft(Player, 10);
            Canvas.SetTop(Player, 296);
            JumpSpeed = 10;
            Force = 0;
            MoveUp = false;
            //todo Reset timer Player1
            //Player2
            Canvas.SetLeft(Player2, 10);
            Canvas.SetTop(Player2, 296);
            JumpSpeed2 = 10;
            Force2 = 10;
            MoveUp2 = false;
            //todo Reset timer Player2
        }
        #endregion

        #region Database
        private void AddHighscoreToDatabase(int highscore, string name, string WL) //Database = Microsoft SQL Express
        
            {
                string connectionString = "Data Source=DESKTOP-BFOALAV\\SQLEXPRESS;Initial Catalog=GameDatabase;Integrated Security=True";
                string query = "INSERT INTO [Highscores] ([Highscore],[Player],[Win/Lose], [Date]) VALUES ('" +
                highscore + "','"+ name + "','"+WL+"','" + DateTime.Today.ToString("yyyy-MM-dd") + "')";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                
                }
            }
        
        #endregion
        
    }
}