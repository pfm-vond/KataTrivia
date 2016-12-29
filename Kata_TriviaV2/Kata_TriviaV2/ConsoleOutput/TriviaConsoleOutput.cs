using Kata_TriviaV2.Public;
using Autofac;

namespace Kata_TriviaV2
{
    class TriviaConsoleOutput : ITriviaListener
    {
        private readonly ITextWriterProvider Out = DependencyInjectionProvider.Builder.Resolve<ITextWriterProvider>();

        public void Asking(IQuestion question)
        {
            Out.Get().WriteLine(question.Statement);
        }

        public void DiceDisplay(TriviaDice6 value)
        {
            Out.Get().WriteLine(value.ToString());
        }

        public void TurnStartFor(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name} is the current player");
        }
    }
}
