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
        private ObservableCollection<TestQuestion> testQuestions;

        public ObservableCollection<TestQuestion> TestQuestions
        {
            get { return testQuestions; }
            set { testQuestions = value; OnPropertyChanged(); }
        }

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
                        CurrentQuestion = TestQuestions.GetPrevious(currentQuestion);
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
                        CurrentQuestion = TestQuestions.GetNext(currentQuestion);
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
                        int countOfcorrect = TestQuestions
                        .Where(tq => tq.AnswerOptions
                                       .Where(ao => ao.IsCorrect)
                                       .All(ao => ao.IsSelected)
                                     && !tq.AnswerOptions
                                          .Where(ao => !ao.IsCorrect)
                                          .Any(ao => ao.IsSelected)
                        ).Count();
                        TestResultMessage = $"Wynik to {countOfcorrect}/{TestQuestions.Count()}";
                    });
                return checkQuestionsCommand;
            }
        }


        public MainPageViewModel()
        {
            TestQuestions = new ObservableCollection<TestQuestion>()
            {
                new TestQuestion()
                {
                    QuestionText = "Ile to 2+2?",
                    QuestionType = Enums.QuestionType.SingleChoice,
                    AnswerOptions = new ObservableCollection<AnswerOption>()
                    {
                        new AnswerOption()
                        {
                            OptionText = "1",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "2",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "3",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "4",
                            IsCorrect = true,
                            IsSelected = false,
                        }
                    }
                },
                new TestQuestion()
                {
                    QuestionText = "Jakie zwierze ma Ala?",
                    QuestionType = Enums.QuestionType.SingleChoice,
                    AnswerOptions = new ObservableCollection<AnswerOption>()
                    {
                        new AnswerOption()
                        {
                            OptionText = "psa",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "kota",
                            IsCorrect = true,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "lwa",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "mysz",
                            IsCorrect = false,
                            IsSelected = false,
                        }
                    }
                }
                ,new TestQuestion()
                {
                    QuestionText = "Jakie kolory są na fladze Polski?",
                    QuestionType = Enums.QuestionType.MultipleChoice,
                    AnswerOptions = new ObservableCollection<AnswerOption>()
                    {
                        new AnswerOption()
                        {
                            OptionText = "biały",
                            IsCorrect = true,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "czarny",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "zielony",
                            IsCorrect = false,
                            IsSelected = false,
                        },
                        new AnswerOption()
                        {
                            OptionText = "czerwony",
                            IsCorrect = true,
                            IsSelected = false,
                        }
                    }
                },
            };
            CurrentQuestion = TestQuestions.FirstOrDefault();
            TestResultMessage = "";
        }

    }
}
