using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosc
{
    public class Kostka
    {
        public static int diceInstances = 0;
        public static string[] diceImageFileNames = ["kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png", "kosc4.png", "kosc5.png", "kosc6.png"];
        public  int throwResult;
        public int imgId;
        public bool isDiceAvalible;

        public Kostka(int diceNumber)
        {
            if(diceNumber <= 0 || diceNumber >6)
                diceNumber = 0;
            
            this.imgId = diceNumber;
            isDiceAvalible = true;
            diceInstances++;
            throwResult = diceNumber;
        }

        public Kostka()
        {
          int randomDrawDiceNumber;
          Random random = new Random();
          randomDrawDiceNumber = random.Next(1, 7);
          this.imgId = randomDrawDiceNumber;
          this.throwResult = randomDrawDiceNumber;
          this.isDiceAvalible = true;
          diceInstances++;
        }

       public void ThrowDice()
        {
            if (!this.isDiceAvalible)
                return;

            Random random = new Random();
            int diceNumber = random.Next(1, 7);

            this.imgId = diceNumber;
            this.throwResult = diceNumber;
        }

        public void blockDice()
        {
            this.isDiceAvalible = false;
        }

        public string getDiceNumberToText()
        {
            switch(this.throwResult) 
            {
                case (0):
                    return "zero";
                case (1):
                    return "jeden";
                case (2):
                    return "dwa";
                case (3):
                    return "trzy";
                case (4):
                    return "cztery";
                case (5):
                    return "piec";
                case (6):
                    return "szesc";
                default:
                    return "zero";
            }
        }
    }
}
