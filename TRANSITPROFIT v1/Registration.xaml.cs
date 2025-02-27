namespace TRANSITPROFIT_v1;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();

        ShowPasswordCheckBox.CheckedChanged += (sender, e) =>
        {
            regis_confirmPass.IsPassword = !e.Value;
        };
    }
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string name = regis_name.Text;
        string email = regis_email.Text;
        string password = regis_pass.Text;
        string confirmPassword = regis_confirmPass.Text;

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            ShowMessage("All fields are required!", true);
            return;
        }

        if (password != confirmPassword)
        {
            ShowMessage("Passwords do not match!", true);
            return;
        }

        if (!email.Contains("@"))
        {
            ShowMessage("Invalid email format!", true);
            return;
        }

        ShowMessage("Registration Successful!", false);

        await Navigation.PushAsync(new MainPage());
    }

    private void ShowMessage(string message, bool isError)
    {
        MessageLabel.Text = message;
        MessageLabel.TextColor = isError ? Colors.Red : Colors.Green;
        MessageLabel.IsVisible = true;
    }

    private async void OnLoginAccButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}
