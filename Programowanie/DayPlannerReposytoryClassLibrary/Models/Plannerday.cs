using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerReposytoryClassLibrary.Models
{
    public partial class Plannerday
    {
        [Key]
        public int Id { get; set; }
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();
    }
}
