using NET_7_OOP_2.Classes;
using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_5.Classes.Ticket
{
    internal class Ticket : IPrintable, ICloneable
    {
        private string _movieName;
        private decimal _price;
        private static int ticketCounter = 0;
        public bool BookingStatus { get; private set; }
        public string MovieName
        {
            get { return _movieName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                _movieName = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        public int TicketId { get; private set; }
        public string BookingReference { get; private set; }
        public decimal PriceAfterTax => Price + Price * 0.14m;
        public Ticket(string movieName, decimal price)
        {
            _movieName = movieName;
            _price = price;

            ticketCounter++;
            TicketId = ticketCounter;

            BookingReference = BookingHelper.GenerateBookingReference();
        }
        public virtual void Print()
        {
            Console.WriteLine(
        $"Ticket #{TicketId} | {MovieName} | " +
        $"Price: {Price} egp | After Tax: {PriceAfterTax} egp | " +
        $"Status: {(BookingStatus ? "Booked" : "Available")}"
    );
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public void SetPrice(decimal price, decimal multiplier)
        {
            Price = price * multiplier;
        }
        public static int GetTotalTickets()
        {
            return ticketCounter;
        }

        public bool BookTicket()
        {
            if(BookingStatus)
            {
                Console.WriteLine($"This Ticket with Id {TicketId} is Already Booked! Book a different one");
                return false;
            }
            BookingStatus = true;
            Console.WriteLine($"Ticket with Id {TicketId} is Booked Successfully");
            return true;
        }
        public bool Cancel()
        {
            if (!BookingStatus)
            {
                Console.WriteLine($"Ticket with Id {TicketId} is not booked!!");
                return false;
            }

            BookingStatus = false;
            Console.WriteLine($"Ticket with Id {TicketId} booking cancelled.");
            return true;
        }

        public virtual object Clone()
        {
            Ticket copy = (Ticket)this.MemberwiseClone();
            ticketCounter++;
            copy.TicketId = ticketCounter;
            // generating new booking reference to the copied Ticket
            copy.BookingReference = BookingHelper.GenerateBookingReference();
            copy.BookingStatus = false;

            return copy;
        }
    }
}
