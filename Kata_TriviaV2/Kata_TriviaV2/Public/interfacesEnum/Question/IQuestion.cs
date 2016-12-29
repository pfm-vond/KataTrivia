namespace Kata_TriviaV2.Public
{
    public interface IQuestion
    {
        string Statement { get; set; }
        
        void WasCorrectlyAnsweredBy(IPlayer p);

        void WasIncorrectlyAnsweredBy(IPlayer p);
    }
}
