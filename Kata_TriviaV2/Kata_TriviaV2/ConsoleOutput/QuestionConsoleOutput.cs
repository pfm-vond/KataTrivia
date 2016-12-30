using Kata_TriviaV2.Public;
using System.IO;

namespace Kata_TriviaV2
{
    internal class QuestionConsoleOutput : IQuestionObserver
    {
        private readonly TextWriter Out;

        public QuestionConsoleOutput(TextWriter textWriter)
        {
            Out = textWriter;
        }

        public void CorrectAnswer()
        {
            Out.WriteLine("Answer was correct!!!!");
        }

        public void WrongAnswer()
        {
            Out.WriteLine("Question was incorrectly answered");
        }
    }
}