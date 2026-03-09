using People4DReposytoryClassLibrary;
using People4DReposytoryClassLibrary.Models;
using System;

PeopleReposytory peopleReposytory = new PeopleReposytory();

List <Person> people = peopleReposytory.GetAllPeople();

Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
foreach(Person person in people)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

//peopleReposytory.AddNewPerson("Marek", "Kowalski", 98);
//people = peopleReposytory.GetAllPeople();
//Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
//foreach (Person person in people)
//{
//    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
//}

List<Person> peopleOlderThan30 = peopleReposytory.GetPersonOlderThan30();
Console.WriteLine("\n Starsze niz 30lat");
foreach(Person person in peopleOlderThan30)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

List<Person> peopleSurnameStartWithK = peopleReposytory.GetSurnamesThatStartsWithK();
Console.WriteLine("\n nazwiska na k");
foreach (Person person in peopleSurnameStartWithK)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

Person youngestPerson = peopleReposytory.GetYoungestPerson();
Console.WriteLine("\n najmłodsza osoba");
Console.WriteLine($"{youngestPerson.Name} {youngestPerson.Name}  {youngestPerson.Surname} lat {youngestPerson.Age}");

Console.WriteLine("\nile osób w tabeli");
int howManyPeopleInTab = peopleReposytory.howManyPeopleInTab();
Console.WriteLine(howManyPeopleInTab);

Console.WriteLine("\nunikalne imiona");
List<Person> uniqueNames = peopleReposytory.AllUniqueNames();
foreach (Person person in uniqueNames)
{
    Console.WriteLine($"{person.Name}");
}

Console.WriteLine("\n zmiana wszystkich Kowalskich na Kowal");
peopleReposytory.UpdateSurname();
List<Person> peopleNew = peopleReposytory.GetAllPeople();
Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
foreach (Person person in peopleNew)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

Console.WriteLine("\nDodanie kazdemu 1 roku");
peopleReposytory.AddAllPeopleOneYear();
List<Person> peopleWithYearMore = peopleReposytory.GetAllPeople();
Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
foreach (Person person in peopleWithYearMore)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

Console.WriteLine("\nUsuwanie osób starszych niż 80lat");
peopleReposytory.DeletePersonsOlderThan80();
List<Person> peopleWithout80OrOlder = peopleReposytory.GetAllPeople();
foreach (Person person in peopleWithout80OrOlder)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}

Console.WriteLine("\n Najstarsza osoba ze zmienionym nazwiskiem na \"Najstarszy\"");
Person oldestPerson = peopleReposytory.GetOldestPersonAndChangeSurname();
Console.WriteLine($"{oldestPerson.Id} {oldestPerson.Name}  {oldestPerson.Surname} lat {oldestPerson.Age}");

//Console.WriteLine("\nosób młodszych niż średni wiek");
//peopleReposytory.DeletePeopleYoungerThanAvgAge();
//List<Person> peopleWithoutYoungerThanAvg = peopleReposytory.GetAllPeople();
//foreach (Person person in peopleWithoutYoungerThanAvg)
//{
//    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
//}

Console.WriteLine("\nImiona z dużej litery");
peopleReposytory.AllNamesToUpperCase();
List<Person> peopleWithToUpperCaseNames = peopleReposytory.GetAllPeople();
foreach (Person person in peopleWithToUpperCaseNames)
{
    Console.WriteLine($"{person.Id} {person.Name}  {person.Surname} lat {person.Age}");
}
