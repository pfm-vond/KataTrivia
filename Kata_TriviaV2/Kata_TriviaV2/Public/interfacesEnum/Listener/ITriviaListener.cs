namespace Kata_TriviaV2.Public
{
    public interface ITriviaListener
    {
        void TurnStartFor(IPlayer current);
        void DiceDisplay(TriviaDice6 roll);
        void Asking(IQuestion current);
    }
}
