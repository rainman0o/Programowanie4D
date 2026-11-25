using Android.Locations;
using System.Collections.ObjectModel;

namespace KoscEgzaminMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            diceFirstRow = new ObservableCollection<Kosc>();
            for(int i = 0; i < 2; i++)
                diceFirstRow.Add(new Kosc(0));
            
            diceSecondRow = new ObservableCollection<Kosc>();
            for (int i = 0; i < 3; i++)
                diceSecondRow.Add(new Kosc(0));

            InitializeComponent();
            ThrowResult = 0;
        }

        private ObservableCollection<Kosc> diceFirstRow;
        public ObservableCollection<Kosc> DiceFirstRow
        {
            get { return diceFirstRow; }
            set { diceFirstRow = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Kosc> diceSecondRow;
        public ObservableCollection<Kosc> DiceSecondRow
        {
            get { return diceSecondRow; }
            set { diceSecondRow = value; OnPropertyChanged(); }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           ThrowResult = 0;
           foreach (Kosc dice in diceFirstRow)
            {
                dice.ThrowDice();
                ThrowResult += dice.ImgId;
            }
           foreach(Kosc dice2 in diceSecondRow)
            {
                dice2.ThrowDice();
                ThrowResult += dice2.ImgId;
            }
        }

        private int throwResult;
        public int ThrowResult
        {
            get { return throwResult; }
            set { throwResult = value; OnPropertyChanged(); }
        }

        private Command changeAvailability;
        public Command ChangeAvailability
        {
            get
            {
                if (changeAvailability == null)
                    changeAvailability = new Command(
                        () =>
                        {
                            
                        });
                return changeAvailability;
            }
            
        }

    }
}
