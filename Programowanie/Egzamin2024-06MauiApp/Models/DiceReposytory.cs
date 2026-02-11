using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin2024_06MauiApp.Models
{
    internal struct DiceReposytory
    {
        public int resoultOfThisDraw;
        public int totalPoints;
        public ObservableCollection<int> cubes;
        public Command throw_Cubes;
        public Command reset_Points;
        public Command set_NewCubesAmmoubnt;
    }
}
