using QuizMauiApp.Enums;
using QuizMauiApp.Model;
using QuizMauiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp.TemplateSelector
{
    public class AnswersTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SingleChoiceTemplate { get; set; }
        public DataTemplate MultipleChoiceTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (container.BindingContext is MainPageViewModel mainPageViewModel)
                return mainPageViewModel.CurrentQuestion.QuestionType switch
                {
                    QuestionType.SingleChoice => SingleChoiceTemplate,
                    QuestionType.MultipleChoice => MultipleChoiceTemplate,
                    _ => throw new Exception("Brak szablonu"),
                };

            return null;

        }
    }
}
