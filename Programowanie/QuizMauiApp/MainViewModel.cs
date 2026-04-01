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
    internal class MainViewModel : BindableObject
    {
        QuizReposytory quizReposytory = new QuizReposytory();
		private Question currentQuestion;
		public Question CurrentQuestion
		{
			get { return currentQuestion; }
			set { currentQuestion = value; OnPropertyChanged(); }
		}

        private Question lastQuestion;
        public Question LastQuestion
        {
            get { return lastQuestion; }
            set { lastQuestion = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Answer> currentAnswers;
        public ObservableCollection<Answer> CurrentAnswers
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
                    checkAnswer = new Command(
                    () =>
                    {
                        if (selectedAnswer == null)
                        {
                            Notification = "Podaj odpowiedz!";
                        }
						else if(selectedAnswer != null)
						{
							if (selectedAnswer.IsCorrect == true)
                            {
                                if (enableOrDisableAnswers == true)
                                {
                                    AmmountOfGoodAnswers++;
                                    EnableOrDisableAnswers = false;
                                    Notification = " ";
                                    selectedAnswer.Color = "Green";
                                    
                                }
                            }
                            else if (selectedAnswer.IsCorrect == false)
                            {
                                Notification = "ZłA ODPOWIEDZ!";
                                EnableOrDisableAnswers = false;
                                selectedAnswer.Color = "Red";
                                currentAnswers.First(a => a.IsCorrect).Color = "Green";
                            }
                        }						              
                    });
                }
                return checkAnswer;
                }

			set { checkAnswer = value; OnPropertyChanged(); }
		}

		private Command nextQuestion;
		public Command NextQuestion
		{
			get {
                if (nextQuestion == null)
                {
                    nextQuestion = nextQuestion = new Command(
                    () =>
                    {
                        if (currentQuestion.Id < lastQuestion.Id && selectedAnswer != null)
                        {
                            SetDefaultSettingsForQuestion();
                        }
                        else if(currentQuestion.Id > lastQuestion.Id)
                        {
                            Notification = "koniec pytań";
                        }
                        else
                        {
                            Notification = "Podaj odpowiedz!";
                        }
                    });
                }
                 return nextQuestion; }
			set { nextQuestion = value; }
		}

		private int whichQuestionAndAnswer;
		public int WhichQuestionAndAnswer
        {
			get { return whichQuestionAndAnswer; }
			set { whichQuestionAndAnswer = value; OnPropertyChanged(); }
		}

		private int ammountOfGoodAnswers;
		public int AmmountOfGoodAnswers
        {
			get { return ammountOfGoodAnswers; }
			set { ammountOfGoodAnswers = value ;OnPropertyChanged(); }
		}

		private string notification;
		public string Notification
        {
			get { return notification; }
			set { notification = value; OnPropertyChanged(); }
		}


		private bool enableOrDisableAnswers;
		public bool EnableOrDisableAnswers
        {
			get { return enableOrDisableAnswers; }
			set { enableOrDisableAnswers = value; OnPropertyChanged(); }
		}

		public void SetAnswerAndQuestion(int whichQuestionAndAnswerNow)
		{
            QuestionDTO questionDTO = quizReposytory.GetCurrentQuestion(whichQuestionAndAnswerNow);
            CurrentQuestion = new Question() { Id = questionDTO.Id, QuestionText = questionDTO.QuestionText };

            CurrentAnswers = new ObservableCollection<Answer>();
            List<AnswersDTO> answersDTO = quizReposytory.GetCurrentAnswers(whichQuestionAndAnswerNow);
            foreach (AnswersDTO answer in answersDTO)
            {
                CurrentAnswers.Add(new Answer() { AnswerText = answer.AnswerText, IsCorrect = answer.IsCorrect, Id = answer.Id, QuestionId = answer.QuestionId, Color = "White" });
            }
        }

        public void SetLastQuestion()
        {
            QuestionDTO lastQuestionDto = quizReposytory.GetLastQuestion();
            LastQuestion = new Question() { Id = lastQuestionDto.Id, QuestionText = lastQuestionDto.QuestionText };
        }

        public void SetDefaultSettingsForQuestion()
        {
            whichQuestionAndAnswer++;
            SetAnswerAndQuestion(whichQuestionAndAnswer);
            EnableOrDisableAnswers = true;
            Notification = "";
            SelectedAnswer = null;
        }

        public MainViewModel()
        {
			WhichQuestionAndAnswer = 1;
			AmmountOfGoodAnswers = 0;
			EnableOrDisableAnswers = true;
            Notification = "";
			SetAnswerAndQuestion(whichQuestionAndAnswer);
            SetLastQuestion();
        }
    }
}
