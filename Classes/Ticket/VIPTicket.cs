using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_5.Classes.Ticket
{
    internal class VIPTicket : Ticket, IPrintable
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; } = 50m;

        public VIPTicket(string movieName, decimal price, bool loungeAccess)
            : base(movieName, price)
        {
            Price = price + ServiceFee;
            LoungeAccess = loungeAccess;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Lounge: {(LoungeAccess ? "Yes" : "No")} | Service Fee: {ServiceFee} EGP");
        }
        public override object Clone()
        {
            return (VIPTicket)base.Clone();
        }
    }
}
