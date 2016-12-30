namespace Kata_TriviaV2.Public
{
    public interface ITriviaObserver
    {
        void TurnStartFor(IPlayer current);
        void DiceDisplay(TriviaDice6 roll);
        void Asking(IQuestion current);
    }
}
