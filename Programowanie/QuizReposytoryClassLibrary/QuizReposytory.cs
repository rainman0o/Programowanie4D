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
            return context.Questions.Where(p => p.Id == currentQuestionId).Select(q => new QuestionDTO(){Id = q.Id, QuestionText = q.QuestionText}).First();
        }

        public List<AnswersDTO> GetCurrentAnswers(int currentQuestionId)
        {
            return context.Answers.Where(a => a.QuestionId == currentQuestionId).Select(a => new AnswersDTO() { Id = a.Id,
                AnswerText = a.AnswerText,
                IsCorrect = a.IsCorrect,
                QuestionId = a.QuestionId}).ToList();
        }
        public Question GetLastId()
        {
            return context.Questions.OrderByDescending(x => x.Id).FirstOrDefault();
        }

    }
}
