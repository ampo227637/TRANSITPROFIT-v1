using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Maui.Controls;

namespace TRANSITPROFIT_v1
{
    public partial class Login : ContentPage
    {
        private readonly Connector dbConnector = new Connector();

        public Login()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text?.Trim();
            string password = userpassword.Text?.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            // Authenticate user
            bool isAuthenticated = await AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Navigation.PushAsync(new MainPage()); // Navigate to MainPage
                App.Current.MainPage = new AppShell();


            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            using (MySqlConnection conn = dbConnector.GetConnection())
            {
                if (conn == null)
                {
                    await DisplayAlert("Error", "Database connection failed.", "OK");
                    return false;
                }

                try
                {
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Authentication failed: " + ex.Message, "OK");
                    return false;
                }
            }
        }

    }
}
