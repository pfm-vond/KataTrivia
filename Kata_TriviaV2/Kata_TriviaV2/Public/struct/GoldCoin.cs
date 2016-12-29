namespace Kata_TriviaV2.Public
{ 
    public struct GoldCoin
    {
        int Howmany { get; set; }

        public GoldCoin(int value)
        {
            Howmany = value;
        }

        public override string ToString()
        {
            return Howmany.ToString() + " Gold Coins.";
        }

        public static implicit operator int(GoldCoin d)
        {
            return d.Howmany;
        }

        public static implicit operator GoldCoin(int d)
        {
            return new GoldCoin(d);
        }
    }
}
