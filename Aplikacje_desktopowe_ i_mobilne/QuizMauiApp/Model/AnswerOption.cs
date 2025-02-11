using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.Model
{
    public class AnswerOption : BindableObject
    {
		private bool isCorrect;
		public bool IsCorrect
		{
			get { return isCorrect; }
			set { isCorrect = value; OnPropertyChanged(); }
		}

		private bool isSelected;
		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value; OnPropertyChanged(); }
		}

		private string optionText;

		public string OptionText
		{
			get { return optionText; }
			set { optionText = value; OnPropertyChanged(); }
		}
	}
}
