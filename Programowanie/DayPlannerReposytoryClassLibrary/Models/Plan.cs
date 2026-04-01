using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerReposytoryClassLibrary.Models
{
    public partial class Plan
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; } = null!;

        public int PlannerdayId { get; set; }

        public virtual Plannerday Plannerday { get; set; } = null!;
    }

}
