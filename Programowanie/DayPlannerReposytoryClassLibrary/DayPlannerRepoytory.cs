using DayPlannerReposytoryClassLibrary.DTO;
using DayPlannerReposytoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public List<int> GetPlannedMonths(int selectedYear)
        {
            return context.Plannerdays.Where(p => p.Year == selectedYear).Select(p => p.Month).ToList();
        }

        public List<int> GetPlannedDays(int selectedYear, int selectedMonth)
        {
            return context.Plannerdays.Where(p => p.Year == selectedYear && p.Month == selectedMonth).Select(p => p.Day).ToList();
        }

        public void AddNewTaskToDb(int year, int month, int day, string taskText)
        {
            Plannerday? plannerday = context.Plannerdays.FirstOrDefault(d => d.Year == year && d.Month == month && d.Day == day );

            if (plannerday == null)
            {
                plannerday = new Plannerday()
                {
                    Year = year,
                    Month = month,
                    Day = day
                };

                context.Add(plannerday);
                context.SaveChanges();
            }

            Plan newTaskText = new Plan()
            {
                Text = taskText,
                PlannerdayId = plannerday.Id
            };

            context.Plans.Add(newTaskText);
            context.SaveChanges();
        }

        public List<PlanDTO> GetPlansForSelectedId(int year, int month, int day)
        {
            int? id = context.Plannerdays.Where(d => d.Year == year && d.Month == month && d.Day == day).Select(d => d.Id).FirstOrDefault();
            return context.Plans.Where(p => p.PlannerdayId == id).Select(d=> new PlanDTO { Id = d.Id, Text = d.Text }).ToList();
        }

        public int GetTaskId(string taskText)
        {
            return context.Plans.Where(t => t.Text == taskText).Select(t => t.Id).FirstOrDefault();
        }

        public void DeleteTask(int id)
        {
            Plan? plan = context.Plans.FirstOrDefault(p => p.Id == id);

            if (plan != null)
            {
                context.Plans.Remove(plan);
                context.SaveChanges();
            }
        }
    }
}
