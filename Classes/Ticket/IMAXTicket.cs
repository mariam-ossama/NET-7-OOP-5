using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_5.Classes.Ticket
{
    internal class IMAXTicket : Ticket, IPrintable
    {
        public bool Is3D { get; set; }
        public IMAXTicket(string movieName, decimal price, bool is3D)
        : base(movieName, is3D ? price + 30m : price)
        {
            Is3D = is3D;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"IMAX 3D: {(Is3D ? "Yes" : "No")}");
        }
        public override object Clone()
        {
            return (IMAXTicket)base.Clone();
        }
    }
}
