namespace Kata_TriviaV2.Public
{
    public interface IQuestionObserver
    {
        void CorrectAnswer();
        void WrongAnswer();
    }
}
