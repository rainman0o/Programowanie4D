using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.ViewModelModels
{
    public class Answer :BindableObject
    {
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; OnPropertyChanged(); }
		}

		private string answerText;
		public string AnswerText
        {
			get { return answerText; }
			set { answerText = value; OnPropertyChanged(); }
		}

		private bool isCorrect;
		public bool IsCorrect
        {
			get { return isCorrect; }
			set { isCorrect = value; OnPropertyChanged(); }
		}

		private int questionId;
		public int QuestionId
        {
			get { return questionId; }
			set { questionId = value; OnPropertyChanged(); }
		}

	}
}
