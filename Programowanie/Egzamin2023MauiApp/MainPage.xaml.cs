using System.Globalization;

namespace Egzamin2023MauiApp
{
    public partial class MainPage : ContentPage
    {
        public List<string> ListOfProffesions { get; set; } = new List<string>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SelectedProffesion { get; set; }

        private int howManycharcters = 0;
        public int HowManyCharacters
        {
            get { return howManycharcters; }
            set { howManycharcters = value; OnPropertyChanged(); }
        }

        public bool IsCheckSmallLargeLetters { get; set; } = true;
        public bool IsCheckNumbers { get; set; }
        public bool IsCheckSpecialSigns { get; set; }
        private string passwordResult;

        public MainPage()
        {
            ListOfProffesions.Add("Kierownik");
            ListOfProffesions.Add("Starszy Pogramista");
            ListOfProffesions.Add("Młodszy Pogramista");
            ListOfProffesions.Add("Tester");
            InitializeComponent();
        }

        private void Confirm(object sender, EventArgs e)
        {  
           DisplayAlert("",$"Dane pracownika: {Name} {Surname} {SelectedProffesion} {passwordResult}","OK");
        }

        private void GeneratePassword(object sender, EventArgs e)
        {
            List<string> passwordGenerate = new List<string>();
            Random random = new Random();

            if(!IsCheckNumbers && !IsCheckSmallLargeLetters && !IsCheckSpecialSigns)
            {
                for (int i = 0; i < HowManyCharacters; i++)
                {
                    char randomChar = (char)random.Next('a', 'z' + 1);
                    passwordGenerate.Add(randomChar.ToString());
                }
            }

            else
            {
                if(IsCheckSmallLargeLetters)
                {
                    char randomChar = (char)random.Next('A', 'Z' + 1);
                    passwordGenerate.Add(randomChar.ToString());
                }
                if(IsCheckNumbers)
                {
                    char randomChar = (char)random.Next('0', '9' + 1);
                    passwordGenerate.Add(randomChar.ToString());
                }
                if (IsCheckSpecialSigns)
                {
                    string specialSigns = "!@#$%^&*()_+-=";
                    char randomChar = specialSigns[random.Next(specialSigns.Length)];
                    passwordGenerate.Add(randomChar.ToString());;
                }

                int remainingCharacters = HowManyCharacters - passwordGenerate.Count();
                for (int i = 0; i < remainingCharacters; i++)
                {
                    char randomChar = (char)random.Next('a', 'z' + 1);
                    passwordGenerate.Add(randomChar.ToString());
                }
            }
            
            passwordResult = string.Join("", passwordGenerate);
            DisplayAlert("", passwordResult, "OK");
        }
    }
}
