using QuizMauiApp.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.Model
{
    public class TestQuestion : BindableObject
    {
		private string questionText;

		public string QuestionText
        {
			get { return questionText; }
			set { questionText = value; OnPropertyChanged(); }
		}

		private ObservableCollection<AnswerOption> answerOptions;
		public ObservableCollection<AnswerOption> AnswerOptions
        {
			get { return answerOptions; }
			set { answerOptions = value; OnPropertyChanged(); }
		}

		private QuestionType questionType;

		public QuestionType QuestionType
        {
			get { return questionType; }
			set { questionType = value; OnPropertyChanged(); }
		}

	}
}
