using System.Globalization;

namespace Egzamin2023MauiApp
{
    public partial class MainPage : ContentPage
    {
        public List<string> ListOfProffesions { get; set; } = new List<string>();

        public string Name { get; set; }

        public string Surname { get; set; }

        public string SelectedProffesion { get; set; }

        public int HowMuchCharacters { get; set; }
        public bool IsCheckSmallLargeLetters { get; set; } = true;
        public bool IsCheckNumbers { get; set; }
        public bool IsCheckSpecialSigns { get; set; }

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
           DisplayAlert("",$"Dane pracownika: {Name} {Surname} {SelectedProffesion}","OK");
        }

        private void GeneratePassword(object sender, EventArgs e)
        {
            
        }
    }
}
