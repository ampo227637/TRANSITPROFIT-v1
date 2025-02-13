namespace TRANSITPROFIT_v1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        public static void NavigateToShell()
        {
            Current.MainPage = new AppShell(); // Switch to Shell after login
        }
    }
}
