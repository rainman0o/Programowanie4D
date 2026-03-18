using QuizMauiApp.ViewModelModels;
using QuizReposytoryClassLibrary;
using QuizReposytoryClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp
{
    internal class MainVievModel : BindableObject
    {
        QuizReposytory quizReposytory = new QuizReposytory();

		private Question currentQuestion;
		public Question CurrentQuestion
		{
			get { return currentQuestion; }
			set { currentQuestion = value; }
		}

        public MainVievModel()
        {
            QuestionDTO questionDTO = quizReposytory.GetCurrentQuestion(1);
            currentQuestion = new Question() { Id = questionDTO.Id, QuestionText = questionDTO.QuestionText };
        }
    }
}
