using People4DReposytoryClassLibrary;
using People4DReposytoryClassLibrary.DTOs;
using PeopleDatabaseMauiApp.ViewModelModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PeopleDatabaseMauiApp

{
	internal class MainViewModel : BindableObject
	{
		PeopleReposytory peopleReposytory = new PeopleReposytory();
 

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person> ();


        private Command? refreshPeopleCommand = null;
        public Command RefreshPeopleCommand
        {
            get
            {
                if (refreshPeopleCommand == null)
                    refreshPeopleCommand = new Command(
                        () =>
                        {
                            People.Clear();
                            foreach (PersonDTO person in peopleReposytory.GetAllPeopleDTO())
                            {
                                People.Add(new Person() { Id = person.Id, Name = person.Name, Surname = person.Surname, Age = person.Age, City = person.City });
                            }
                        }
                        );
                return refreshPeopleCommand;
            }
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
                    Age = selectedPerson.Age
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

						selectedPerson.Id = selectedPersonCopy.Id;
                        SelectedPerson.Name = SelectedPersonCopy.Name;
                        SelectedPerson.Surname = SelectedPersonCopy.Surname;
						selectedPerson.Age = SelectedPersonCopy.Age;	
                    });
                }
                return updatePerson;
			}
		}
	} 
}
