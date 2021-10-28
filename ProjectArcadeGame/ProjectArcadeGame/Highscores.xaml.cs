using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Window
    {
        public Highscores()
        {
            InitializeComponent();
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-BFOALAV\\SQLEXPRESS;Initial Catalog=GameDatabase;Integrated Security=True";
            string query = "SELECT TOP 10 [Highscore], [Player], [Win_Lose], [Date] FROM [Highscores] ORDER BY [Highscore] ASC";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            
            try
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Highscores");
                sda.Fill(dt);
                HighscoresTable.ItemsSource = dt.DefaultView;
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
             
        }

        private void HighscoreBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

    }
}
