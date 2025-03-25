using Microsoft.Extensions.Logging;
using QuizDatabaseClassLibrary;
using QuizDatabaseClassLibrary.DTOs;

namespace QuizMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            AddNewQuestions();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void AddNewQuestions()
        {
            QuizRepository quizRepository = new QuizRepository();

            if (quizRepository.GetQuestionCount() == 0)
            {
                QuestionDTO? questionDTO;
                AnswerDTO answerDTO;

                #region Question 1

                questionDTO = new QuestionDTO();

                questionDTO.QuestionText = "Ile to 2+2?";
                questionDTO.QuestionType = (int)Enums.QuestionType.SingleChoice;

                questionDTO = quizRepository.AddNewQuestion(questionDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "1",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "2",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "3",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "4",
                    IsCorrect = true,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                #endregion

                #region Question 2

                questionDTO = new QuestionDTO();

                questionDTO.QuestionText = "Jakie zwierze ma Ala?";
                questionDTO.QuestionType = (int)Enums.QuestionType.SingleChoice;

                questionDTO = quizRepository.AddNewQuestion(questionDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "psa",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "kota",
                    IsCorrect = true,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "lwa",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "mysz",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                #endregion

                #region Question 3

                questionDTO = new QuestionDTO();

                questionDTO.QuestionText = "Jakie kolory są na fladze Polski?";
                questionDTO.QuestionType = (int)Enums.QuestionType.MultipleChoice;

                questionDTO = quizRepository.AddNewQuestion(questionDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "biały",
                    IsCorrect = true,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "czarny",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "zielony",
                    IsCorrect = false,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                answerDTO = new AnswerDTO()
                {
                    AnswerText = "czerwony",
                    IsCorrect = true,
                    QuestionId = questionDTO!.Id
                };
                quizRepository.AddNewAnswer(answerDTO);

                #endregion

            }
        }
    }
}
