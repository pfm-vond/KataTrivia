using Trivia_csharp;

namespace Kata_TriviaV2.Public
{
    public struct Square
    {
        int Id { get; set; }
        
        public Category Category { get; private set; }

        public Square(int id)
        {
            Id = id;
            Category = (Category)(id % 4);
        }

        public override string ToString()
        {
            return Id.ToString();
        }
        
        public static implicit operator int(Square d)
        {
            return d.Id;
        }

        public static implicit operator Square(int d)
        {
            return new Square(d%Trivia.SQUARES_ON_BOARD);
        }
    }
}
