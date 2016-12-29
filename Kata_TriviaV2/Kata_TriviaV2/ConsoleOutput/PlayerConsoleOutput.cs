using System;
using Autofac;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    class PlayerConsoleOutput : IPlayerListener
    {
        private readonly ITextWriterProvider Out = DependencyInjectionProvider.Builder.Resolve<ITextWriterProvider>();

        public void CategoryChanged(Category category)
        {
            Out.Get().WriteLine($"The category is {category}");
        }

        public void NbPlayerChangeTo(int howMany)
        {
            Out.Get().WriteLine($"They are player number {howMany}");
        }

        public void PlayerBreakFree(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name} is getting out of the penalty box");
        }

        public void PlayerFailedToBreakFree(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name} is not getting out of the penalty box");
        }

        public void PlayerGoToPenaltyBox(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name} was sent to the penalty box");
        }

        public void PlayerMovedTo(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name}'s new location is {player.Place}");
        }

        public void PlayerWasAdded(IPlayer player)
        {
            Out.Get().WriteLine($"{player.Name} was added");
        }

        public void PurseUpdated(IPlayer player)
        {
            Console.WriteLine($"{player.Name} now has {player.Purse}");
        }
    }
}
