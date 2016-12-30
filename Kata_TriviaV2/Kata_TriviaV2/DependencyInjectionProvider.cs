using Autofac;
using System;
using Trivia_csharp;

namespace Kata_TriviaV2.Public
{
    public static class DependencyInjectionProvider
    {
        private static Lazy<IContainer> _builder = new Lazy<IContainer>(() => InitializeDI());

        public static IContainer Builder => _builder.Value;
        
        public static void ResetBuilder() {
            _builder = new Lazy<IContainer>(() => InitializeDI());
        }

        private static IContainer InitializeDI()
        {
            var builder = new ContainerBuilder();

            RegisterTriviaBinding(builder);

            RegisterOutputBinding(builder);
            
            return builder.Build();
        }

        private static void RegisterOutputBinding(ContainerBuilder builder)
        {
            builder.RegisterType<TriviaConsoleOutput>().As<ITriviaObserver>().SingleInstance();
            builder.RegisterType<PlayerConsoleOutput>().As<IPlayerObserver>().SingleInstance();
            builder.RegisterType<QuestionConsoleOutput>().As<IQuestionObserver>().SingleInstance();
        }

        private static void RegisterTriviaBinding(ContainerBuilder builder)
        {
            builder.RegisterType<Trivia>().AsSelf();
            builder.RegisterInstance(Console.Out).As<System.IO.TextWriter>();

            RegisterPlayerBinding(builder);
            RegisterQuestionBinding(builder);
        }

        private static void RegisterQuestionBinding(ContainerBuilder builder)
        {
            builder.RegisterType<Question>().As<IQuestion>();
            builder.RegisterType<QuestionPool>().As<IQuestionPool>();
        }

        private static void RegisterPlayerBinding(ContainerBuilder builder)
        {
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<PlayerPool>().As<IPlayerPool>();
        }
    }
}
