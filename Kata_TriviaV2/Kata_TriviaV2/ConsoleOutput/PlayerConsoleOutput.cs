using Kata_TriviaV2.Public;
using System.IO;

namespace Kata_TriviaV2
{
    class PlayerConsoleOutput : IPlayerObserver
    {
        private readonly TextWriter Out;

        public PlayerConsoleOutput(TextWriter textWriter)
        {
            Out = textWriter;
        }

        public void CategoryChanged(Category category)
        {
            Out.WriteLine($"The category is {category}");
        }

        public void NbPlayerChangeTo(int howMany)
        {
            Out.WriteLine($"They are player number {howMany}");
        }

        public void PlayerBreakFree(IPlayer player)
        {
            Out.WriteLine($"{player.Name} is getting out of the penalty box");
        }

        public void PlayerFailedToBreakFree(IPlayer player)
        {
            Out.WriteLine($"{player.Name} is not getting out of the penalty box");
        }

        public void PlayerGoToPenaltyBox(IPlayer player)
        {
            Out.WriteLine($"{player.Name} was sent to the penalty box");
        }

        public void PlayerMovedTo(IPlayer player)
        {
            Out.WriteLine($"{player.Name}'s new location is {player.Place}");
        }

        public void PlayerWasAdded(IPlayer player)
        {
            Out.WriteLine($"{player.Name} was added");
        }

        public void PurseUpdated(IPlayer player)
        {
            Out.WriteLine($"{player.Name} now has {player.Purse}");
        }
    }
}
