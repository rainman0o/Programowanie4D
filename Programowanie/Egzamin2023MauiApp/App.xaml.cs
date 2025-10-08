namespace Egzamin2023MauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new MainPage());
            window.Title = "Dodaj pracownika 01234567890";
            return window;
        }
    }
}