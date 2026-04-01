using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayPlannerReposytoryClassLibrary;
using DayPlannerReposytoryClassLibrary.DTO;
using DayPlannerMauiApp.MainViewModelModels;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace DayPlannerMauiApp
{
    public class MainViewModel : BindableObject
    {
        DayPlannerRepoytory dayPlannerRepoytory = new DayPlannerRepoytory();

        private ObservableCollection<Plannerday> allPlannerdays;

        private List<int> plannedYears;
        public List<int> PlannedYears
        {
            get { return plannedYears; }
            set { plannedYears = value; OnPropertyChanged(); }
        }

        private List<int> plannedMonths;
        public List<int> PlannedMonths
        {
            get { return plannedMonths; }
            set { plannedMonths = value; OnPropertyChanged(); }
        }
        private List<int> plannedDays;
        public List<int> PlannedDays
        {
            get { return plannedDays; }
            set { plannedDays = value; OnPropertyChanged(); }
        }

        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set { selectedYear = value; OnPropertyChanged(); }
        }

        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set { selectedMonth = value; OnPropertyChanged(); }
        }

        private int selectedDay;

        public int SelectedDay
        {
            get { return selectedDay; }
            set { selectedDay = value; OnPropertyChanged(); }
        }


        public MainViewModel()
        {
            PlannedYears = dayPlannerRepoytory.GetPlannedYers();
            SelectedYear = PlannedYears.First();
            PlannedMonths = dayPlannerRepoytory.GetPlannedMonths(SelectedYear);
            SelectedMonth = PlannedMonths.First();
            PlannedDays = dayPlannerRepoytory.GetPlannedDays(SelectedYear, SelectedMonth);
            SelectedDay = PlannedDays.First();  
        }
    }
}
