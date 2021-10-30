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
   
        private void Window_Loaded(object sender, RoutedEventArgs e) //When window loads carrry out method
        {
            string connectionString = "Data Source=DESKTOP-BFOALAV\\SQLEXPRESS;Initial Catalog=GameDatabase;Integrated Security=True";
            string query = "SELECT TOP 10 [Highscore], [Player], [Win_Lose], [Date] FROM [Highscores] ORDER BY [Highscore] ASC"; //Select records to fill Datagrid
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
                HighscoresTable.ItemsSource = dt.DefaultView; //View of SQL Table Highscores
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //Shows error message 

            }
             
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) //Format date to dd-MM-yyyy
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }
        private void HighscoreBack_Click(object sender, RoutedEventArgs e) //Return to Main Window
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

    }
}
