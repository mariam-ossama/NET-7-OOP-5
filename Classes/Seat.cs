
namespace G_NET_7_CsharpOOP1
{
    internal struct Seat : ICloneable
    {
        public char Row;
        public int Number;

        public Seat(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public object Clone()
        {
            return (Seat)this.MemberwiseClone();
        }

        public override string ToString() => $"{Row}{Number}";
    }
}
