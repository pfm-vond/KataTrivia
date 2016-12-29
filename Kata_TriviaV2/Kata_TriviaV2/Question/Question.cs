using Kata_TriviaV2.Public;
using System;
using Autofac;

namespace Kata_TriviaV2
{
    internal class Question : IQuestion
    {
        private readonly IQuestionListener Notify = DependencyInjectionProvider.Builder.Resolve<IQuestionListener>();

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
