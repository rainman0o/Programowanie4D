using Microsoft.EntityFrameworkCore;
using People4DReposytoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People4DReposytoryClassLibrary
{
    public class PeopleReposytory
    {
        private PeopleDBContext context;

        public PeopleReposytory()
        {
            context = new PeopleDBContext();
        }

        //C - create
        public void AddNewPerson(string name, string surname, int age)
        {
            Person newPerson = new Person() { Name = name, Surname = surname, Age = age };

            context.Add(newPerson);

            context.SaveChanges();
        }
        //R - read
        public List<Person> GetAllPeople()
        {
            return context.People.AsNoTracking().OrderBy(p => p.Name).ThenBy(p => p.Surname).ToList();
        }
        //U - update
        public void UpdateName(int id, string newName)
        {
            Person? person = context.People.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                person.Name = newName;

                context.SaveChanges();
            }
        }

        //D - delete
        public void DeletePerson(int id)
        {
            Person? person = context.People.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                context.People.Remove(person);
                context.SaveChanges();
            }
        }
        //zadania

        /*
        * Pobierz osoby o wieku wiêkszym ni¿ 30 lat.
        * Pobierz osoby, których nazwisko zaczyna siê na „K”.
        * ZnajdŸ osoby z najmniejszym wiekiem.
        * Policz, ile osób jest w tabeli.
        * Zwróæ wszystkie unikalne imiona.
        * Zmieñ nazwisko wszystkich osób o nazwisku „Kowalski” na „Kowal”.
        * Dodaj wszystkim osobom 1 rok (symulacja urodzin).
        * Usuñ wszystkich, którzy maj¹ wiêcej ni¿ 80 lat.
        *  ZnajdŸ najstarsz¹ osobê i zmieñ jej nazwisko na „Najstarszy”.
        * Usuñ osoby m³odsze ni¿ œrednia wieku.
        * Zmieñ imiona na wersjê „WIELKIMI LITERAMI”.*/
        public List<Person> GetPersonOlderThan30()
        {
            return context.People.AsNoTracking().OrderBy(p => p.Name).
                ThenBy(p => p.Surname).
                Where(p => p.Age > 30).
                ToList();
        }

        public List<Person> GetSurnamesThatStartsWithK()
        {
            return context.People.AsNoTracking().Where(p => p.Surname.StartsWith("K")).ToList();
        }
        
        public Person GetYoungestPerson()
        {
            return context.People.AsNoTracking().OrderBy(p => p.Age).FirstOrDefault();
        }

        public int howManyPeopleInTab()
        {
            return context.People.Count();
        }

        public List<Person> AllUniqueNames()
        {
            return context.People.GroupBy(p => p.Name).Select(n => n.First()).ToList();
        }

        public void UpdateSurname()
        {
            List<Person> people = context.People.Where(p => p.Surname == "Kowalski").ToList();

            if (people != null)
            {
                foreach( Person person in people)
                {
                    person.Surname = "Kowal";
                }

                context.SaveChanges();
            }
        }

        public void AddAllPeopleOneYear()
        {
            List<Person> people = context.People.Select(p => p).ToList();
            foreach(Person person in people)
            {
                person.Age = person.Age + 1;
            }
            context.SaveChanges();
        }

        public void DeletePersonsOlderThan80()
        {
            List<Person> people = context.People.Where(p => p.Age > 80).ToList();

            if (people != null)
            {
                foreach (Person person in people)
                {
                    context.People.Remove(person);
                }

                context.SaveChanges();
            }
        }

         //ZnajdŸ najstarsz¹ osobê i zmieñ jej nazwisko na „Najstarszy”.

        public Person GetOldestPersonAndChangeSurname()
        {
            Person oldestPerson =  context.People.OrderByDescending(p => p.Age).FirstOrDefault();
            oldestPerson.Surname = "Najstarszy";
            context.SaveChanges();
            return oldestPerson;
        }

        public void DeletePeopleYoungerThanAvgAge()
        {
            var averageAge = context.People.Average(p => p.Age);
            List<Person> people = context.People.Where(p => p.Age < averageAge).ToList();

            if (people != null)
            {
                context.People.RemoveRange(people);
                context.SaveChanges();
            }
        }

        public void AllNamesToUpperCase()
        {
            foreach (Person person in context.People)
            {
                person.Name = person.Name.ToUpper();
            }
            context.SaveChanges();
        }
    }
}
