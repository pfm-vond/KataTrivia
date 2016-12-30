using Autofac;
using Kata_TriviaV2;
using Kata_TriviaV2.Public;
using System;

namespace Trivia_csharp
{
    public class Trivia
    {
        public const int SQUARES_ON_BOARD = 12;
        public const int NB_MINIMUM_PLAYERS = 2;
        public const int COIN_TO_WIN = 6;

        private readonly IPlayerPool Players;
        
        private readonly IQuestionPool Questions;
        
        private readonly ITriviaObserver Notify;

        private Category CurrentCategory => Players.Current.Place.Category;

        public Trivia(IPlayerPool players, IQuestionPool questions, ITriviaObserver observer)
        {
            Players = players;
            Questions = questions;
            Notify = observer;
        }

        public void AddPlayer(string playerName)
        {
            Players.Add(playerName);
        }

        public bool IsPlayable()
        {
            return (Players.HowMany() >= NB_MINIMUM_PLAYERS);
        }

        public void Roll(TriviaDice6 roll)
        {
            BeginTurn(roll);

            if (ShouldPlayerBeInPenaltyBox(roll))
            {
                SkipTurn();
            }
            else
            {
                PlayTurn(roll);
            }
        }

        private void SkipTurn()
        {
            Players.Current.MustBeInPenaltyBox();
        }

        private void BeginTurn(TriviaDice6 roll)
        {
            Notify.TurnStartFor(Players.Current);
            Notify.DiceDisplay(roll);
        }

        private void PlayTurn(TriviaDice6 roll)
        {
            Players.Current.MustBeFree();
            Players.Current.Move(roll);
            AskNextQuestion();
        }

        private bool ShouldPlayerBeInPenaltyBox(TriviaDice6 roll)
        {
            return Players.Current.IsInPenaltyBox && !roll.AllowHimToGetOut();
        }

        private void AskNextQuestion()
        {
            if (Questions.MoveNext(CurrentCategory))
            {
                Notify.Asking(Questions.Current);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool WasCorrectlyAnswered()
        {
            Questions.Current.WasCorrectlyAnsweredBy(Players.Current);

            return EndOfTurn();
        }

        public bool WrongAnswer()
        {
            Questions.Current.WasIncorrectlyAnsweredBy(Players.Current);

            return EndOfTurn();
        }

        private bool EndOfTurn()
        {
            Players.MoveNext();
            return !DidPlayerWin();
        }

        private bool DidPlayerWin()
        {
            return Players.Current.Purse >= COIN_TO_WIN;
        }
    }
}