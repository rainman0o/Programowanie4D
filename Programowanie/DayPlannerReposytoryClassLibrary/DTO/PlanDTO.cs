using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerReposytoryClassLibrary.DTO
{
    public class PlanDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PlannerdayId { get; set; }
    }
}
