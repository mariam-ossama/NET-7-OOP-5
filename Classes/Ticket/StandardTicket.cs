using G_NET_7_CsharpOOP1;
using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_5.Classes.Ticket
{
    internal class StandardTicket : Ticket, IPrintable
    {
        public Seat Seat { get; set; }
        public StandardTicket(string movieName, decimal price, Seat seat)
        : base(movieName, price)
        {
            Seat = seat;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Seat: {Seat}");
        }
        public override object Clone()
        {
            StandardTicket copy = (StandardTicket)base.Clone();
            copy.Seat = (Seat)Seat.Clone();
            return copy;
        }
    }
}
