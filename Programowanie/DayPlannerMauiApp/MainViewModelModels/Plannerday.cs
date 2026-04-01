using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerMauiApp.MainViewModelModels
{
    public class Plannerday : BindableObject
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; OnPropertyChanged(); }
		}

		private int day;
		public int Day
		{
			get { return day; }
			set { day = value; OnPropertyChanged(); }
		}

		private int month;
		public int Month
        {
			get { return month; }
			set { month = value; OnPropertyChanged(); }
		}

		private int year;
		public int Year
        {
			get { return year; }
			set { year = value; OnPropertyChanged(); }
		}

	}
}
