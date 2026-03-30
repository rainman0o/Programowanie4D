using QuizReposytoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizReposytoryClassLibrary.DTO;

namespace QuizReposytoryClassLibrary
{
    public class QuizReposytory
    {
        private QuizDBContext context;
        public QuizReposytory()
        {
            context = new QuizDBContext();
        }

        public QuestionDTO GetCurrentQuestion(int currentQuestionId)
        {
            return context.Questions.OrderBy(q => q.Id).Where(q => q.Id >= currentQuestionId).Select(q => new QuestionDTO(){Id = q.Id, QuestionText = q.QuestionText}).First();
        }

        public List<AnswersDTO> GetCurrentAnswers(int currentQuestionId)
        {
            return context.Answers.Where(a => a.QuestionId == currentQuestionId).Select(a => new AnswersDTO() { Id = a.Id,
                AnswerText = a.AnswerText,
                IsCorrect = a.IsCorrect,
                QuestionId = a.QuestionId}).ToList();
        }
       
        public QuestionDTO GetLastQuestion()
        {
            return context.Questions.OrderBy(q => q.Id).Select(q => new QuestionDTO() { Id = q.Id, QuestionText = q.QuestionText }).Last();
        }
    }
}
