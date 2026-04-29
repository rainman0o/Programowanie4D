using DayPlannerMauiApp.MainViewModelModels;
using DayPlannerReposytoryClassLibrary;
using DayPlannerReposytoryClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            set
            {
                selectedYear = value;
                PlannedMonths = dayPlannerRepoytory.GetPlannedMonths(SelectedYear);
                SelectedMonth = PlannedMonths.FirstOrDefault();
                OnPropertyChanged();
            }
        }

        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set {
                selectedMonth = value;
                PlannedDays = dayPlannerRepoytory.GetPlannedDays(SelectedYear, SelectedMonth);
                SelectedDay = PlannedDays.FirstOrDefault();
                OnPropertyChanged(); 
            }
        }

        private int selectedDay;

        public int SelectedDay
        {
            get { return selectedDay; }
            set { selectedDay = value; OnPropertyChanged(); }
        }

        private List<int> newPlanYear;

        public List<int> NewPlanYear
        {
            get { return newPlanYear; }
            set { newPlanYear = value; OnPropertyChanged(); }
        }

        private int selectedNewPlanYear;

        public int SelectedNewPlanYear
        {
            get { return selectedNewPlanYear; }
            set {
                selectedNewPlanYear = value;
                NewPlanMonth = GetMonthsForSelectedYear(selectedNewPlanYear);
                SelectedNewPlanMonth = NewPlanMonth.FirstOrDefault();
                OnPropertyChanged();
                }
        }

        private ObservableCollection<int> newPlanMonth;

        public ObservableCollection<int> NewPlanMonth
        {
            get { return newPlanMonth; }
            set { newPlanMonth = value; OnPropertyChanged(); }
        }

        private int selectedNewPlanMonth;

        public int SelectedNewPlanMonth
        {
            get { return selectedNewPlanMonth; }
            set {
                selectedNewPlanMonth = value;
                NewPlanDay= GetDaysForSelectedMonths(selectedNewPlanYear, selectedNewPlanMonth);
                SelectedNewPlanDay = NewPlanDay.FirstOrDefault();
                OnPropertyChanged(); 
            }
        }

        private ObservableCollection<int> newPlanDay;

        public ObservableCollection<int> NewPlanDay
        {
            get { return newPlanDay; }
            set { newPlanDay = value; OnPropertyChanged(); }
        }

        private int selectedNewPlanDay;

        public int SelectedNewPlanDay
        {
            get { return selectedNewPlanDay; }
            set { selectedNewPlanDay = value;OnPropertyChanged(); }
        }

        private string taskContent;

        public string TaskContent
        {
            get { return taskContent; }
            set { taskContent = value; OnPropertyChanged(); }
        }

        public int SetMinMonthForSelectedYear(int year)
        {
            if (year == DateTime.Now.Year)
                return DateTime.Now.Month;
            else return 1;
        }

        public ObservableCollection<int> GetMonthsForSelectedYear(int year)
        {
            ObservableCollection<int> months = new ObservableCollection<int>();
            for (int i = SetMinMonthForSelectedYear(year); i <= 12; i++)
            {
                months.Add(i);
            }
            return months;
        }

        public ObservableCollection<int> GetDaysForSelectedMonths(int year, int month)
        {
            ObservableCollection<int> days = new ObservableCollection<int>();
            var now  = DateTime.Now;

            int minDay;
            int maxDay;

            if (year == now.Year && month == now.Month)
            {
                minDay = now.Day;
            }
            else
                minDay = 1;

            maxDay = DateTime.DaysInMonth(year, month);

            for(int i = minDay; i <= maxDay; i++)
            {
                days.Add(i); 
            }
            return days;
        }

        public List<int> MakeYearsForPlans()
        {
            List<int> years = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                years.Add(DateTime.Now.Year + i);
            }
            return years;
        }

        private Command addNewTask;
        public Command AddNewTask
        {
            get {
                if (addNewTask == null)
                {
                    addNewTask = addNewTask = new Command(
                    () =>
                    {
                        if (TaskContent != null)
                            dayPlannerRepoytory.AddNewTaskToDb(SelectedNewPlanYear, selectedNewPlanMonth, selectedNewPlanDay, TaskContent);
                        else TaskContent = "podaj tresc";
                    });
                }
                return addNewTask; }
            set { addNewTask = value;}
        }

        
        private Command refreshList;
        public Command RefreshList
        {
            get {
                if (refreshList == null)
                {
                    refreshList = refreshList = new Command(
                    () =>
                    {
                        List<PlanDTO> taskToDo = dayPlannerRepoytory.GetPlansForSelectedId(SelectedYear, SelectedMonth, SelectedDay);
                        Tasks = new();
                        foreach (PlanDTO task in taskToDo)
                        {
                            Tasks.Add(new Plan { Id = task.Id, PlannerdayId = task.PlannerdayId, Text = task.Text, DeleteCommand = DeleteTask });
                        }
                    });
                }
                return  refreshList; }
            set {  refreshList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Plan> tasks;

        public ObservableCollection<Plan> Tasks
        {
            get { return tasks; }
            set { tasks = value; OnPropertyChanged(); }
        }

        private Command deleteTask;
        public Command DeleteTask
        {
            get {
                if (deleteTask == null)
                {
                    deleteTask = deleteTask = new Command<Plan>(
                    (p) =>
                    {
                        dayPlannerRepoytory.DeleteTask(p.Id);
                        Tasks.Remove(p);
                    });
                }
                return deleteTask; }
            set { deleteTask = value; }
        }

        public MainViewModel()
        {
            PlannedYears = dayPlannerRepoytory.GetPlannedYers();
            SelectedYear = PlannedYears.FirstOrDefault();
            NewPlanYear =  MakeYearsForPlans();
            SelectedNewPlanYear = newPlanYear.First();
        }
    }
}
