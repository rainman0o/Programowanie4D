namespace SimpleCalculatorBindingMauiApp
{
    public partial class MainPage : ContentPage
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }

        private string resoult;

        public string Resoult
        {
            get { return resoult; }
            set { resoult = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(FirstNumber, out int firstNumber)
               || !int.TryParse(SecondNumber, out int secondNumber))
                return;
            int resoult = firstNumber + secondNumber;

            Resoult = $"Wynik to {resoult}";
        }
    }
}