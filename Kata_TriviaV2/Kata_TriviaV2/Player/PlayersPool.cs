using System.Collections.Generic;
using Autofac;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    class PlayerPool : IPlayerPool
    {
        private readonly List<IPlayer> Players = new List<IPlayer>();
        private readonly ILifetimeScope LifeTimeScope;

        private readonly IPlayerObserver Notify;

        public PlayerPool(IPlayerObserver notify, ILifetimeScope lifetimeInjector)
        {
            Notify = notify;
            LifeTimeScope = lifetimeInjector;
        }

        public IPlayer Current
        {
            get;
            private set;
        }

        public void Add(string playerName)
        {
            var player = LifeTimeScope.Resolve<IPlayer>();
            
            player.Name = playerName;
            Players.Add(player);

            InitializeCurrent(player);

            NotifyPlayerWasAdded(player);
        }

        private void NotifyPlayerWasAdded(IPlayer player)
        {
            Notify.PlayerWasAdded(player);
            Notify.NbPlayerChangeTo(HowMany());
        }

        private void InitializeCurrent(IPlayer player)
        {
            if (Current == null)
            {
                Current = player;
            }
        }

        public int HowMany()
        {
            return Players.Count;
        }

        public void MoveNext()
        {
            int indexOfNextPlayer = (Players.IndexOf(Current) + 1) % HowMany();
            Current = Players[indexOfNextPlayer];
        }
    }
}
