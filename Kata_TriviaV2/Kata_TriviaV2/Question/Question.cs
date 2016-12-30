using Kata_TriviaV2.Public;
using System;
using Autofac;

namespace Kata_TriviaV2
{
    internal class Question : IQuestion
    {
        private readonly IQuestionObserver Notify;

        public Question(IQuestionObserver observer)
        {
            Notify = observer;
        }

        public string Statement { get; set; }

        public void WasCorrectlyAnsweredBy(IPlayer player)
        {
            if (!player.IsInPenaltyBox)
            {
                Notify.CorrectAnswer();

                player.Purse++;
            }
        }

        public void WasIncorrectlyAnsweredBy(IPlayer player)
        {
            Notify.WrongAnswer();
            player.MustBeInPenaltyBox();
        }
    }
}
