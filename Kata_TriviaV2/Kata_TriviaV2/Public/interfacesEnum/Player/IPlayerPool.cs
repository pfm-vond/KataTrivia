namespace Kata_TriviaV2.Public
{
    public interface IPlayerPool
    {
        int HowMany();

        void MoveNext();

        IPlayer Current { get; }

        void Add(string playerName);
    }
}