// See https://aka.ms/new-console-template for more information
using Kosc;
Console.WriteLine("Podaj numer kosci");
int dice2ThrowNumber = int.Parse(Console.ReadLine());

Kostka dice1 = new Kostka();
Console.WriteLine("Wynik automatyczny " + dice1.throwResult + " Słownie " + dice1.getDiceNumberToText() + " liczbaInstancji " + Kostka.diceInstances +
    " nazwa pliku " + Kostka.diceImageFileNames[dice1.imgId] );

Kostka dice2 = new Kostka(dice2ThrowNumber);
Console.WriteLine("Wynik z wypisania " + dice2.throwResult + " Słownie " + dice2.getDiceNumberToText() + " liczbaInstancji " + Kostka.diceInstances +
    " nazwa pliku " + Kostka.diceImageFileNames[dice2.imgId]);
