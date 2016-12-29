namespace Kata_TriviaV2.Public
{
    public interface IPlayer
    {
        string Name { get; set; }

        GoldCoin Purse { get; set; }

        Square Place { get; set; }

        bool IsInPenaltyBox { get; }

        void MustBeInPenaltyBox();

        void MustBeFree();

        void Move(int roll);
    }
}