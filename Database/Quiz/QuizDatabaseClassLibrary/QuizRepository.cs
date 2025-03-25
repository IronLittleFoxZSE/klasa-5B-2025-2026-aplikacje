using Microsoft.EntityFrameworkCore;
using QuizDatabaseClassLibrary.DTOs;
using QuizDatabaseClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDatabaseClassLibrary
{
    public class QuizRepository
    {
        private QuizDBContext dbContext;

        public QuizRepository()
        {
            dbContext = new QuizDBContext();
        }

        #region CREATE

        public QuestionDTO? AddNewQuestion(QuestionDTO questionDTO)
        {
            Question newQuestion = new Question()
            {
                QuestionText = questionDTO.QuestionText,
                QuestionType = questionDTO.QuestionType
            };
            dbContext.Questions.Add(newQuestion);
            dbContext.SaveChanges();

            questionDTO.Id = newQuestion.Id;

            return questionDTO;
        }

        public AnswerDTO AddNewAnswer(AnswerDTO answerDTO)
        {
            Answer newAnswer = new Answer()
            {
                AnswerText = answerDTO.AnswerText,
                IsCorrect = answerDTO.IsCorrect,
                QuestionId = answerDTO.QuestionId
            };
            dbContext.Answers.Add(newAnswer);
            dbContext.SaveChanges();

            answerDTO.Id = newAnswer.Id;

            return answerDTO;
        }

        #endregion

        #region READ

        public int GetQuestionCount()
        {
            return dbContext.Questions.Count();
        }

        public QuestionDTO? GetFirstQuestion()
        {
            Question? findQuestion = dbContext.Questions.OrderBy(q => q.Id).FirstOrDefault();

            if (findQuestion == null)
                return null;

            QuestionDTO questionDTO = new QuestionDTO()
            {
                Id = findQuestion.Id,
                QuestionText = findQuestion.QuestionText,
                QuestionType = findQuestion.QuestionType,
            };

            return questionDTO;
        }

        public QuestionDTO? GetQuestion(int id)
        {
            Question? findQuestion = dbContext.Questions.FirstOrDefault(x => x.Id == id);

            if (findQuestion == null)
                return null;

            QuestionDTO questionDTO = new QuestionDTO()
            {
                Id = findQuestion.Id,
                QuestionText = findQuestion.QuestionText,
                QuestionType = findQuestion.QuestionType,
            };

            return questionDTO;
        }

        public QuestionDTO? GetNextQuestion(int currentQuestionId)
        {
            Question? findQuestion = dbContext.Questions.OrderBy(q => q.Id).FirstOrDefault(q => q.Id > currentQuestionId);

            if (findQuestion == null)
                findQuestion = dbContext.Questions.OrderBy(q => q.Id).FirstOrDefault();

            if (findQuestion == null)
                return null;

            QuestionDTO questionDTO = new QuestionDTO()
            {
                Id = findQuestion.Id,
                QuestionText = findQuestion.QuestionText,
                QuestionType = findQuestion.QuestionType,
            };

            return questionDTO;
        }

        public QuestionDTO? GetPrevQuestion(int currentQuestionId)
        {
            Question? findQuestion = dbContext.Questions.OrderByDescending(q => q.Id).FirstOrDefault(q => q.Id < currentQuestionId);

            if (findQuestion == null)
                findQuestion = dbContext.Questions.OrderByDescending(q => q.Id).FirstOrDefault();

            if (findQuestion == null)
                return null;

            QuestionDTO questionDTO = new QuestionDTO()
            {
                Id = findQuestion.Id,
                QuestionText = findQuestion.QuestionText,
                QuestionType = findQuestion.QuestionType,
            };

            return questionDTO;
        }

        public List<QuestionDTO> GetAllQuestions()
        {
            return dbContext.Questions.Select(q => new QuestionDTO() { Id = q.Id, QuestionText = q.QuestionText, QuestionType = q.QuestionType }).ToList();
        }

        public List<AnswerDTO> GetAllAnswers(int questionId)
        {
            return dbContext
                .Answers
                .Where(a => a.QuestionId == questionId)
                .Select(a => new AnswerDTO() { Id = a.Id, AnswerText = a.AnswerText, IsCorrect = a.IsCorrect, QuestionId = a.QuestionId })
                .ToList();
        }

        public int GetCountOfCorrectAnsvers(Dictionary<int, List<AnswerDTO>> ansversToCheck)
        {
            var questionIds = ansversToCheck.Keys.ToList(); // Pobranie listy ID z dictionary
            var allAnswers = ansversToCheck.Values.SelectMany(list => list).ToList();

            int count = 0;

            count = dbContext
                .Questions
                .Where(q => questionIds.Contains(q.Id))
                .Include(q => q.Answers)
                .AsEnumerable()
                .Where(q => q.Answers
                             .Where(a => a.IsCorrect)
                             .All(a => allAnswers.Where(aDto => aDto.QuestionId == a.QuestionId)
                                                 .Any(aDto => aDto.Id == a.Id))
                             && !q.Answers
                                  .Where(a => !a.IsCorrect)
                                  .Any(a => allAnswers.Any(aDto => aDto.Id == a.Id)))
                .Count();
            return count;
        }

        #endregion

    }
}
