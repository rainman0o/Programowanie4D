using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.ViewModelModels
{
    public class Question : BindableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string questionText;

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; OnPropertyChanged(); }
        }




    }
}
