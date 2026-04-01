using DayPlannerReposytoryClassLibrary.DTO;
using DayPlannerReposytoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerReposytoryClassLibrary
{
    public class DayPlannerRepoytory
    {
        DayPlannerDBContext context;

        public DayPlannerRepoytory()
        {
            context = new DayPlannerDBContext();
        }

        public List<PlannerdayDTO> GetPlannerDay()
        {
            return context.Plannerdays.Select(p => new PlannerdayDTO() { Id = p.Id, Day = p.Day, Month = p.Month, Year = p.Year }).ToList();
        }

        public List<int> GetPlannedYers()
        {
            return context.Plannerdays.Select(p => p.Year).ToList();
        }

        public List<int> GetPlannedMonths()
        {
            return context.Plannerdays.Select(p => p.Month).ToList();
        }

        public List<int> GetPlannedDays()
        {
            return context.Plannerdays.Select(p => p.Day).ToList();
        }

    }
}
