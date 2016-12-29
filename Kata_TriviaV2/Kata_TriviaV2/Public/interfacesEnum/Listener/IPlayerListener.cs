using Trivia_csharp;

namespace Kata_TriviaV2.Public
{
    public interface IPlayerListener
    {
        void PlayerMovedTo(IPlayer player);
        void PlayerFailedToBreakFree(IPlayer player);
        void PlayerGoToPenaltyBox(IPlayer player);
        void PlayerBreakFree(IPlayer player);
        void PlayerWasAdded(IPlayer player);
        void NbPlayerChangeTo(int v);
        void PurseUpdated(IPlayer player);
        
        // small break of SOLID (should be in a ICategoryListener)
        void CategoryChanged(Category category);
    }
}
