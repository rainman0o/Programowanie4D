namespace Egzamin2021_06MauiApp
{
    public partial class MainPage : ContentPage
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string PasswordRepeat { get; set; } = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private string resoult = "";
        public string Resoult 
        {
            get { return resoult; }
            set { resoult = value; OnPropertyChanged(); }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckEmail(Email) && CheckPassoword(Password, PasswordRepeat))
                Resoult = $"Witaj {Email}";

            else if (!CheckEmail(Email))
                Resoult = "Niepoprawny Email";

            else if (!CheckPassoword(Password, PasswordRepeat))
                Resoult = "Hasła się różnią";
        }

        bool CheckEmail(string email)
        {
            foreach (var sign in email)
            {
                if (sign == '@')
                {
                    return true;
                }
            }
            return false;
        }

        bool CheckPassoword(string passoword, string passwordRepeat)
        {
            if (passoword == passwordRepeat)
                return true;
            else
                return false;
        }
    }
}


