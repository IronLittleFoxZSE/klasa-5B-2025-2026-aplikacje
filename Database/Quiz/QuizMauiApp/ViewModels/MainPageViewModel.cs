using QuizDatabaseClassLibrary;
using QuizDatabaseClassLibrary.DTOs;
using QuizMauiApp.Enums;
using QuizMauiApp.Extensions;
using QuizMauiApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {

        private TestQuestion currentQuestion;
        public TestQuestion CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; OnPropertyChanged(); }
        }

        private Command prevQuestionCommand;
        public Command PrevQuestionCommand
        {
            get
            {
                if (prevQuestionCommand == null)
                    prevQuestionCommand = new Command(() =>
                    {
                        selectedAnswers.Remove(CurrentQuestion.Id);
                        selectedAnswers.Add(CurrentQuestion.Id
                            , CurrentQuestion.AnswerOptions.Where(ao => ao.IsSelected).ToList());


                        QuestionDTO questionDto = quizRepository.GetPrevQuestion(CurrentQuestion.Id);

                        if (questionDto == null)
                            return;

                        CurrentQuestion = ConvertToTestQuestion(questionDto);

                        foreach (AnswerOption answerOption in ConvertTo(quizRepository.GetAllAnswers(CurrentQuestion.Id)))
                        {
                            CurrentQuestion.AnswerOptions.Add(answerOption);
                        }
                    });
                return prevQuestionCommand;
            }
        }

        private Command nextQuestionCommand;
        public Command NextQuestionCommand
        {
            get
            {
                if (nextQuestionCommand == null)
                    nextQuestionCommand = new Command(() =>
                    {
                        selectedAnswers.Remove(CurrentQuestion.Id);
                        selectedAnswers.Add(CurrentQuestion.Id
                            , CurrentQuestion.AnswerOptions.Where(ao => ao.IsSelected).ToList());

                        QuestionDTO questionDto = quizRepository.GetNextQuestion(CurrentQuestion.Id);

                        if (questionDto == null)
                            return;

                        CurrentQuestion = ConvertToTestQuestion(questionDto);

                        foreach (AnswerOption answerOption in ConvertTo(quizRepository.GetAllAnswers(CurrentQuestion.Id)))
                        {
                            CurrentQuestion.AnswerOptions.Add(answerOption);
                        }
                    });
                return nextQuestionCommand;
            }
        }

        private string testResultMessage;

        public string TestResultMessage
        {
            get { return testResultMessage; }
            set { testResultMessage = value; OnPropertyChanged(); }
        }

        private Command checkQuestionsCommand;
        public Command CheckQuestionsCommand
        {
            get
            {
                if (checkQuestionsCommand == null)
                    checkQuestionsCommand = new Command(() =>
                    {
                        selectedAnswers.Remove(CurrentQuestion.Id);
                        selectedAnswers.Add(CurrentQuestion.Id
                            , CurrentQuestion.AnswerOptions.Where(ao => ao.IsSelected).ToList());

                        int countOfcorrect;

                        Dictionary<int, List<AnswerDTO>> ansversToCheck = new Dictionary<int, List<AnswerDTO>>();
                        foreach(var keyValuePair in selectedAnswers)
                        {
                            ansversToCheck.Add(keyValuePair.Key,
                                keyValuePair.Value.Select(ao => new AnswerDTO() { Id = ao.Id, QuestionId = keyValuePair.Key }).ToList());
                        }

                        countOfcorrect = quizRepository.GetCountOfCorrectAnsvers(ansversToCheck);
                        TestResultMessage = $"Wynik to {countOfcorrect}/";
                        /*
                        int countOfcorrect = TestQuestions
                        .Where(tq => tq.AnswerOptions
                                       .Where(ao => ao.IsCorrect)
                                       .All(ao => ao.IsSelected)
                                     && !tq.AnswerOptions
                                          .Where(ao => !ao.IsCorrect)
                                          .Any(ao => ao.IsSelected)
                        ).Count();
                        TestResultMessage = $"Wynik to {countOfcorrect}/{TestQuestions.Count()}";
                        */
                    });
                return checkQuestionsCommand;
            }
        }

        private QuizRepository quizRepository;
        private Dictionary<int, List<AnswerOption>> selectedAnswers;
        public MainPageViewModel()
        {
            quizRepository = new QuizRepository();
            selectedAnswers = new Dictionary<int, List<AnswerOption>>();

            QuestionDTO firstQuestionDto = quizRepository.GetFirstQuestion();

            if (firstQuestionDto == null)
                return;

            CurrentQuestion = ConvertToTestQuestion(firstQuestionDto);

            foreach (AnswerOption answerOption in ConvertTo(quizRepository.GetAllAnswers(CurrentQuestion.Id)))
            {
                CurrentQuestion.AnswerOptions.Add(answerOption);
            }

            TestResultMessage = "";
        }

        private TestQuestion ConvertToTestQuestion(QuestionDTO questionDTO)
        {
            TestQuestion testQuestion = new TestQuestion();
            testQuestion = new TestQuestion()
            {
                Id = questionDTO.Id,
                QuestionText = questionDTO.QuestionText,
                QuestionType = (QuestionType)questionDTO.QuestionType,
                AnswerOptions = new ObservableCollection<AnswerOption>()
            };

            return testQuestion;
        }

        private List<AnswerOption> ConvertTo(List<AnswerDTO> answerDTOs)
        {
            List<AnswerOption> answerOptions = new List<AnswerOption>();

            foreach (AnswerDTO answerDTO in answerDTOs)
            {
                AnswerOption answerOption = new AnswerOption()
                {
                    Id = answerDTO.Id,
                    OptionText = answerDTO.AnswerText,
                    IsSelected = false
                };
                answerOptions.Add(answerOption);
            }
            return answerOptions;
        }

    }
}
