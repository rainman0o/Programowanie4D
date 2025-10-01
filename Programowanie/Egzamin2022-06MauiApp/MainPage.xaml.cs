namespace Egzamin2022_06MauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private int like = 0;

        public int Like
        {
            get { return like; }
            set { like = value; OnPropertyChanged(); }
        }

        private void Button_Like(object sender, EventArgs e)
        {
            Like++;
        }
        private void Button_Dislike(object sender, EventArgs e)
        {
            if (Like != 0)
                Like--;
        }
    }
}
