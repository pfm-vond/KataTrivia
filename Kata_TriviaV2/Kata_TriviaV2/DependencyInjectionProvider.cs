using Autofac;
using Kata_TriviaV2.Public;
using System;

namespace Kata_TriviaV2
{
    public static class DependencyInjectionProvider
    {
        private readonly static Lazy<IContainer> _builder = new Lazy<IContainer>(() => InitializeDI());

        public static IContainer Builder => _builder.Value;

        private static IContainer InitializeDI()
        {
            var builder = new ContainerBuilder();

            RegisterTriviaBinding(builder);

            RegisterOutputBinding(builder);

            builder.RegisterType<ConsoleOutputProvider>().As<ITextWriterProvider>().SingleInstance();
            
            return builder.Build();
        }

        private static void RegisterOutputBinding(ContainerBuilder builder)
        {
            builder.RegisterType<TriviaConsoleOutput>().As<ITriviaListener>().SingleInstance();
            builder.RegisterType<PlayerConsoleOutput>().As<IPlayerListener>().SingleInstance();
            builder.RegisterType<QuestionConsoleOutput>().As<IQuestionListener>().SingleInstance();
        }

        private static void RegisterTriviaBinding(ContainerBuilder builder)
        {
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
