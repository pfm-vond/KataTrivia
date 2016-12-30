using System;
using Autofac;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    internal class Player : IPlayer
    {
        private readonly IPlayerObserver Notify;

        public Player(IPlayerObserver notify)
        {
            Notify = notify;
        }

        private GoldCoin _purse;

        public bool IsInPenaltyBox { get; private set; }

        public string Name { get; set; }

        public Square Place { get; set; }
        
        public GoldCoin Purse
        {
            get
            {
                return _purse;
            }
            set
            {
                _purse = value;
                Notify.PurseUpdated(this);
            }
        }

        public void Move(int roll)
        {
            Place += roll;

            Notify.PlayerMovedTo(this);
            Notify.CategoryChanged(Place.Category);
        }

        public void MustBeInPenaltyBox()
        {
            NotifyInPenaltyBox();

            IsInPenaltyBox = true;
        }

        private void NotifyInPenaltyBox()
        {
            if (IsInPenaltyBox)
            {
                Notify.PlayerFailedToBreakFree(this);
            }
            else
            {
                Notify.PlayerGoToPenaltyBox(this);
            }
        }

        public void MustBeFree()
        {
            if (IsInPenaltyBox)
            {
                IsInPenaltyBox = false;
                Notify.PlayerBreakFree(this);
            }
        }
    }
}
