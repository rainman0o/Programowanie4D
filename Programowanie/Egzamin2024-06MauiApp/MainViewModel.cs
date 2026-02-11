using Egzamin2024_06MauiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin2024_06MauiApp
{
    internal class MainViewModel : BindableObject
    {
        public int ResoultOfThisDraw
        {
            get { return diceReposytory.resoultOfThisDraw; }
            set { diceReposytory.resoultOfThisDraw = value; OnPropertyChanged(); }
        }

        public int TotalPoints
        {
            get { return diceReposytory.totalPoints; }
            set { diceReposytory.totalPoints = value; OnPropertyChanged(); }
        }

        public int AmmountOfCubes { get; set; } = 5;

        public ObservableCollection<int> Cubes
        {
            get { return diceReposytory.cubes; }
            set { diceReposytory.cubes = value; OnPropertyChanged(); }
        }

        //public ObservableCollection<int> Cubes { get; set; } = new ObservableCollection<int>();

        public Command Throw_Cubes
        {
            get
            {

                if (diceReposytory.throw_Cubes == null)
                    diceReposytory.throw_Cubes = new Command(
                        () =>
                        {
                            diceService.DrawCubesNumbers(Cubes);
                            ResoultOfThisDraw = diceService.CountPointsOfDrawCubes(Cubes);
                            TotalPoints += ResoultOfThisDraw;
                        }
                        );
                return diceReposytory.throw_Cubes;
            }
        }

        public Command Reset_Points
        {
            get
            {
                if (diceReposytory.reset_Points == null)
                    diceReposytory.reset_Points = new Command(
                        () =>
                        {
                            diceService.SetAllCubesToZero(Cubes);
                            ResoultOfThisDraw = 0;
                            TotalPoints = 0;
                        }
                        );
                return diceReposytory.reset_Points;
            }
        }


        public Command Set_NewCubesAmmount
        {
            get
            {
                if (diceReposytory.set_NewCubesAmmoubnt == null)
                    diceReposytory.set_NewCubesAmmoubnt = new Command(
                        () =>
                        {
                            diceService.FillInHowManyCubes(AmmountOfCubes, Cubes);
                        }
                        );

                return diceReposytory.set_NewCubesAmmoubnt;
            }
        }

        private DiceService diceService = new DiceService();
        private DiceReposytory diceReposytory = new DiceReposytory();
        public MainViewModel()
        {
            Cubes = diceService.GetNewZerosCollection(AmmountOfCubes);
        }
    }
}
