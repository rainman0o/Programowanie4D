namespace EventVsBindingMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public string Message { get; set; }

        private string returnMessage;

        public string ReturnMessage
        {
            get { return returnMessage; }
            set { returnMessage = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            rotationLabel.Rotation = rotationSlider.Value;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ReturnMessage = "ilość to" + Message.Length;
        }
    }
}
