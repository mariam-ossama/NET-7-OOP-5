using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_2.Classes
{
    internal static class BookingHelper
    {
        private static int bookingCounter = 0;
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            if(numberOfTickets >= 5)
            {
                return numberOfTickets * pricePerTicket * 0.9;
            }
            return numberOfTickets * pricePerTicket;
        }
        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }
        public static void PrintAllTickets(IPrintable[] printable)
        {
            foreach (IPrintable item in printable)
            {
                item.Print();
                Console.WriteLine();
            }
        }
    }
}
