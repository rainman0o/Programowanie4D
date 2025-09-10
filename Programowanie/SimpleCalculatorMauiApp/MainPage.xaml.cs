namespace SimpleCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(firstNumberEntry.Text, out int firstNumber)
                 || !int.TryParse(firstNumberEntry.Text, out int secondNumber))
                 return;
            int resoult = firstNumber + secondNumber;

            resoultLabel.Text = $"Wynik to {resoult}";
        }
    }
}
