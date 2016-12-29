using System;
using System.Text;

namespace Trivia_csharp.Init
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void CreateTest(String[] args)
        {
            var program = new StringBuilder();

            Trivia aGame = new Trivia();
            program.AppendLine("Game aGame = new Game();");

            aGame.IsPlayable();
            program.AppendLine("aGame.isPlayable();");

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");
            program.AppendLine("aGame.add(\"Chet\");");
            program.AppendLine("aGame.add(\"Pat\"); ");
            program.AppendLine("aGame.add(\"Sue\"); ");

            aGame.IsPlayable();
            program.AppendLine("aGame.isPlayable();");

            Random rand = new Random();

            do
            {
                int rolled = rand.Next(5) + 1;
                aGame.Roll(rolled);
                program.AppendLine($"aGame.roll({rolled});");

                if (rand.Next(9) > 5)
                {
                    notAWinner = aGame.WrongAnswer();
                    program.AppendLine("aGame.wrongAnswer();");
                }
                else
                {
                    notAWinner = aGame.WasCorrectlyAnswered();
                    program.AppendLine("aGame.wasCorrectlyAnswered();");
                }



            } while (notAWinner);

            Console.Out.WriteLine(program);

        }
    }

}
