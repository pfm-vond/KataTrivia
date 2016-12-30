using Autofac;
using ApprovalTests;
using ApprovalTests.Reporters;
using Kata_TriviaV2.Public;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using Trivia_csharp;
namespace Kata_TriviaV2
{
    [TestFixture]
    public class GameApprovalTest
    {
        [SetUp]
        public void SetUp()
        {
            DependencyInjectionProvider.ResetBuilder();
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ApprovalTestStayInPenaltyBox()
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));
            this.Scenario1();
            Approvals.Verify(output.ToString());
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ApprovalTestGetOutPenaltyBox()
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));
            this.Scenario2();
            Approvals.Verify(output.ToString());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void TestIsPlayableWithNoPlayer_False(int NbPlayers)
        {
            Trivia aGame = CreateGameWith(NbPlayers);
            Assert.That(aGame.IsPlayable(), Is.False);
        }

        [Test]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(100)]
        public void TestIsPlayableWithPlayers_True(int NbPlayers)
        {
            Trivia aGame = CreateGameWith(NbPlayers);

            Assert.That(aGame.IsPlayable(), Is.True);
        }

        private Trivia CreateGameWith(int NbPlayers)
        {
            Trivia aGame = DependencyInjectionProvider.Builder.Resolve<Trivia>();
            for (int i = 0; i < NbPlayers; i++)
            {
                aGame.AddPlayer($"Chet {i}");
            }

            return aGame;
        }

        [Test]
        public void IndexOutOfRangeExceptionWhenNoMoreQuestion()
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            Trivia aGame = DependencyInjectionProvider.Builder.Resolve<Trivia>();
            aGame.AddPlayer("Chet");

            for (var i = 0;i<50; i++)
            {
                aGame.Roll(3);
                aGame.WrongAnswer();
                aGame.Roll(1);
                aGame.WrongAnswer();
            }

            Assert.That(() => aGame.Roll(3), Throws.Exception.AssignableTo<IndexOutOfRangeException>());
        }

        public void Scenario1()
        {
            Trivia aGame = DependencyInjectionProvider.Builder.Resolve<Trivia>();
            aGame.IsPlayable();
            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");
            aGame.IsPlayable();


            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
        }
        public void Scenario2()
        {
            Trivia aGame = DependencyInjectionProvider.Builder.Resolve<Trivia>();
            aGame.IsPlayable();
            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");
            aGame.IsPlayable();


            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(3);
            aGame.WrongAnswer();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(5);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WrongAnswer();
            aGame.Roll(5);
            aGame.WrongAnswer();
            aGame.Roll(3);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(2);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(3);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(2);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WrongAnswer();
            aGame.Roll(4);
            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();
        }
    }
}
