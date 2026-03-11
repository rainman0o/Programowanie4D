using People4DReposytoryClassLibrary;
using People4DReposytoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PeopleDatabaseMauiApp

{
	internal class MainViewModel : BindableObject
	{
		PeopleReposytory peopleReposytory = new PeopleReposytory();

		private Command getAllPeopleCommand;
		public Command GetAllPeopleCommand
		{
			get
			{
				if (getAllPeopleCommand == null)
				{
					getAllPeopleCommand = new Command(
						() =>
						{
							List<Person> people = peopleReposytory.GetAllPeople();
							AllPeopleList = people;
						}
						);
				}
				return getAllPeopleCommand;
			}
			set { getAllPeopleCommand = value; }
		}

		private List<Person> allPeopleList;
		public List<Person> AllPeopleList
		{
			get { return allPeopleList; }
			set { allPeopleList = value; OnPropertyChanged(); }
		}

		private Person selectedPerson;
		public Person SelectedPerson
		{
			get { return selectedPerson; }
			set { selectedPerson = value; OnPropertyChanged();
                SelectedPersonCopy = new Person
                {
                    Id = selectedPerson.Id,
                    Name = selectedPerson.Name,
                    Surname = selectedPerson.Surname,
                    Address = selectedPerson.Address,
                    Age = selectedPerson.Age,
                    AddressId = selectedPerson.AddressId
                };
                OnPropertyChanged();
			}
		}

		private Person selectedPersonCopy;

		public Person SelectedPersonCopy
		{
			get { return selectedPersonCopy; }
			set { selectedPersonCopy = value;OnPropertyChanged(); }
		}


		private Command updatePerson;
		public Command UpdatePerson
		{
			get 
			{
                if (updatePerson == null)
				{
					updatePerson = updatePerson = new Command(
					() =>
					{
						peopleReposytory.UpdatePerson(SelectedPersonCopy.Id,
                        SelectedPersonCopy.Name,
                        SelectedPersonCopy.Surname,
                        SelectedPersonCopy.Age);
					});
                }
                return updatePerson;
			}
		}
	} 
}
