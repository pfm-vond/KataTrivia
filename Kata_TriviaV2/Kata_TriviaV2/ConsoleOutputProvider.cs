using System;
using System.IO;
using Kata_TriviaV2.Public;

namespace Kata_TriviaV2
{
    internal class ConsoleOutputProvider : ITextWriterProvider
    {
        public TextWriter Get()
        {
            return Console.Out;
        }
    }
}