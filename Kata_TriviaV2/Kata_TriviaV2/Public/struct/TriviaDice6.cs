using System;

namespace Kata_TriviaV2.Public
{
    public struct TriviaDice6
    {
        private static Random Generate = new Random();
        const int Size = 6;

        int Roll { get; set; }

        public TriviaDice6(int value)
        {
            Roll = value;
        }

        public static TriviaDice6 Throw()
        {
            return new TriviaDice6(Generate.Next(Size));
        }

        public bool AllowHimToGetOut()
        {
            return Roll % 2 != 0; 
        }

        public override string ToString()
        {
            return $"They have rolled a {Roll.ToString()}";
        }
        
        public static implicit operator int(TriviaDice6 d)
        {
            return d.Roll;
        }
        
        public static implicit operator TriviaDice6(int d)
        {
            return new TriviaDice6(d);
        }
    }
}
