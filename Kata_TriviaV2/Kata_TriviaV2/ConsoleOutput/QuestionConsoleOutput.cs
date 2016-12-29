using System;
using Autofac;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    internal class QuestionConsoleOutput : IQuestionListener
    {
        private readonly ITextWriterProvider Out = DependencyInjectionProvider.Builder.Resolve<ITextWriterProvider>();

        public void CorrectAnswer()
        {
            Out.Get().WriteLine("Answer was correct!!!!");
        }

        public void WrongAnswer()
        {
            Out.Get().WriteLine("Question was incorrectly answered");
        }
    }
}