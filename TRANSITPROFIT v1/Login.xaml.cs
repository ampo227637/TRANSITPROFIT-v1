using System;
using MySql.Data.MySqlClient;
using Microsoft.Maui.Controls;

namespace TRANSITPROFIT_v1
{
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
            rolePicker.SelectedIndexChanged += RolePicker_SelectedIndexChanged;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text?.Trim();
            string password = userpassword.Text?.Trim();
            string selectedRole = rolePicker.SelectedItem?.ToString();

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(selectedRole))
            {
                await DisplayAlert("Error", "Please fill in all fields and select a role.", "OK");
                return;
            }

            if (AuthenticateUser(username, password, selectedRole))
            {
                await DisplayAlert("Success", "Login successful!", "OK");

                // Navigate to AppShell and remove Login Page from stack
                App.NavigateToShell();
            }
            else
            {
                await DisplayAlert("Error", "Invalid username, password, or role.", "OK");
            }
        }


        private bool AuthenticateUser(string username, string password, string role)
        {
            return (username == "admin" && password == "admin" && role == "Admin") ||
                   (username == "employee" && password == "employee" && role == "Employee");
        }

        private void RolePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rolePicker.SelectedIndex != -1)
            {
                position.Text = rolePicker.SelectedItem.ToString(); // Fixed reference
            }
        }
    }
}
