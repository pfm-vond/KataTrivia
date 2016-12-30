using System;
using Autofac;
using Kata_TriviaV2.Public;

namespace Trivia_csharp
{
    public class TriviaRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Trivia aGame = DependencyInjectionProvider.Builder.Resolve<Trivia>();

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            Random rand = new Random();

            do
            {

                aGame.Roll(TriviaDice6.Throw());

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.WasCorrectlyAnswered();
                }



            } while (notAWinner);

        }


    }

}