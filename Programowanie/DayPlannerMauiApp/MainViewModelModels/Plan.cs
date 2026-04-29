using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerMauiApp.MainViewModelModels
{
    public class Plan : BindableObject
    {
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; OnPropertyChanged(); }
		}

		private string text;
		public string Text
		{
			get { return text; }
			set { text = value; OnPropertyChanged(); }
		}

		private int plannerdayId;

		public int PlannerdayId
		{
			get { return plannerdayId; }
			set { plannerdayId = value; OnPropertyChanged(); }
		}

        public Command DeleteCommand { get; set; }

    }
}
