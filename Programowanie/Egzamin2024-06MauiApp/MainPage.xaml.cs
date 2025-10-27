using System.Collections.ObjectModel;

namespace Egzamin2024_06MauiApp
{
    public partial class MainPage : ContentPage
    {
        private int resoultOfThisDraw;

        public int ResoultOfThisDraw
        {
            get { return resoultOfThisDraw; }
            set { resoultOfThisDraw = value; OnPropertyChanged(); }
        }

        private int totalPoints;

        public int TotalPoints
        {
            get { return totalPoints; }
            set { totalPoints = value; OnPropertyChanged(); }
        }

        public int AmmountOfCubes { get; set; } = 5;
        public ObservableCollection<int> Cubes { get; set; } = new ObservableCollection<int>();
        public MainPage()
        {
            for (int i = 0; i < AmmountOfCubes; i++)
            {
                Cubes.Add(0);
            }
          
            InitializeComponent();
        }

        private void Throw_Cubes(object sender, EventArgs e)
        {
            DrawCubesNumbers();
            ResoultOfThisDraw = CountPointsOfDrawCubes(Cubes);
            TotalPoints += ResoultOfThisDraw;  
        }

        private void Reset_Points(object sender, EventArgs e)
        {
            SetAllCubesToZero(Cubes);
            ResoultOfThisDraw = 0;
            TotalPoints = 0;
        }

        private void Set_NewCubesAmmount(object sender, EventArgs e)
        {
            FillInHowManyCubes(AmmountOfCubes);
        }

        private void FillInHowManyCubes(int ammountOfCubes)
        {
            Cubes.Clear();
            for (int i = 0; i < ammountOfCubes; i++)
            {
                Cubes.Add(0);
            }
        }
        private void DrawCubesNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < Cubes.Count; i++)
            {
                Cubes[i] = random.Next(1, 7);
            }
        }

        private void SetAllCubesToZero(ObservableCollection<int> cubes)
        {
            for (int i = 0; i < Cubes.Count; i++)
                Cubes[i] = 0;
        }

        private int CountPointsOfDrawCubes(ObservableCollection<int> cubes)
        {
            int points = 0;
            var groups = cubes.GroupBy(x => x);

            foreach (var group in groups)
            {
                if (group.Count() >= 2)
                {
                    points += group.Key * group.Count();
                }
            }
            return points;
        }
    }
}


