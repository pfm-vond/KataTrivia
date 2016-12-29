using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    class PlayerPool : IPlayerPool
    {
        private readonly IPlayerListener Notify = DependencyInjectionProvider.Builder.Resolve<IPlayerListener>();

        private readonly List<IPlayer> Players = new List<IPlayer>();
        
        public IPlayer Current
        {
            get;
            private set;
        }

        public void Add(string playerName)
        {
            var player = DependencyInjectionProvider.Builder.Resolve<IPlayer>();
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
