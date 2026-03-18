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

		private List<Answer> currentAnswers;
        public List<Answer> CurrentAnswers
        {
			get { return currentAnswers; }
			set { currentAnswers = value; OnPropertyChanged(); }
		}

		private Answer selectedAnswer;

		public Answer SelectedAnswer
		{
			get { return selectedAnswer; }
			set { selectedAnswer = value; OnPropertyChanged(); }
		}

		private Command checkAnswer;

		public Command CheckAnswer
		{
			get {
                if (checkAnswer == null)
                {
                    checkAnswer = checkAnswer = new Command(
                    () =>
                    {
						
                    });
                }
                return checkAnswer;
                }

			set { checkAnswer = value; OnPropertyChanged(); }
		}

		private int ammountOfGoodAnswers;

		public int AmmountOfGoodAnswers
        {
			get { return ammountOfGoodAnswers; }
			set { ammountOfGoodAnswers = 0 ;OnPropertyChanged(); }
		}


		public MainVievModel()
        {
            QuestionDTO questionDTO = quizReposytory.GetCurrentQuestion(1);
            currentQuestion = new Question() { Id = questionDTO.Id, QuestionText = questionDTO.QuestionText };

			CurrentAnswers = new List<Answer>();
            List<AnswersDTO> answersDTO = quizReposytory.GetCurrentAnswers(1);
			foreach (AnswersDTO answer in answersDTO)
			{
				CurrentAnswers.Add(new Answer() { AnswerText = answer.AnswerText, IsCorrect = answer.IsCorrect, Id = answer.Id, QuestionId = answer.QuestionId });
			}
			
        }
    }
}
