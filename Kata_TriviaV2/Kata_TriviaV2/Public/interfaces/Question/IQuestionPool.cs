namespace Kata_TriviaV2.Public
{
    public interface IQuestionPool
    {
        IQuestion Current{ get; }

        bool MoveNext(Category category);
    }
}

