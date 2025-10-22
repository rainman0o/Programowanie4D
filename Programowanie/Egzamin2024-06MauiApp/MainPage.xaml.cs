using System.Collections.ObjectModel;

namespace Egzamin2024_06MauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<int> Cubes { get; set; } = new ObservableCollection<int>();
        //public ObservableCollection<int> CurrentCubes { get; set; } = new ObservableCollection<int>();
        public MainPage()
        {
            Cubes.Add(0);
            Cubes.Add(0);
            Cubes.Add(0);
            Cubes.Add(0);
            Cubes.Add(0);
            InitializeComponent();
        }  
    }
}
