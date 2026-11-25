using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoscEgzaminMauiApp
{
    public class Kosc:BindableObject
    {
        public static int diceInstances = 0;
        public static string[] diceImageFileNames = ["kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png", "kosc4.png", "kosc5.png", "kosc6.png"];
        public int throwResult;
        private int imgId;

        public int ImgId
        {
            get { return imgId; }
            set { imgId = value; OnPropertyChanged(); }
        }

        public bool isDiceAvalible;

        public Kosc(int diceNumber)
        {
            if (diceNumber <= 0 || diceNumber > 6)
                diceNumber = 0;

            this.ImgId = diceNumber;
            isDiceAvalible = true;
            diceInstances++;
            throwResult = diceNumber;
        }

        public Kosc()
        {
            int randomDrawDiceNumber;
            Random random = new Random();
            randomDrawDiceNumber = random.Next(1, 7);
            this.ImgId = randomDrawDiceNumber;
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

            this.ImgId = diceNumber;
            this.throwResult = diceNumber;
        }

        public void blockDice()
        {
            this.isDiceAvalible = false;
        }

        public string getDiceNumberToPhotoName()
        {
            switch (this.throwResult)
            {
                case (0):
                    return "kosc0.png";
                case (1):
                    return "kosc1.png";
                case (2):
                    return "kosc2.png";
                case (3):
                    return "kosc3.png";
                case (4):
                    return "kosc4.png";
                case (5):
                    return "kosc5.png";
                case (6):
                    return "kosc6.png";
                default:
                    return "kosc7.png";
            }
        }
    }
}

