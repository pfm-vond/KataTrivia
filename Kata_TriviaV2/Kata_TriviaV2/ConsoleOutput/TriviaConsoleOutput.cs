using Kata_TriviaV2.Public;
using System.IO;

namespace Kata_TriviaV2
{
    class TriviaConsoleOutput : ITriviaObserver
    {
        private readonly TextWriter Out;

        public TriviaConsoleOutput(TextWriter textWriter)
        {
            Out = textWriter;
        }

        public void Asking(IQuestion question)
        {
            Out.WriteLine(question.Statement);
        }

        public void DiceDisplay(TriviaDice6 value)
        {
            Out.WriteLine(value.ToString());
        }

        public void TurnStartFor(IPlayer player)
        {
            Out.WriteLine($"{player.Name} is the current player");
        }
    }
}
