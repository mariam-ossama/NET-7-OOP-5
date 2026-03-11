using NET_7_OOP_5.Classes.Ticket;
using NET_7_OOP_5.Interfaces;
using NET_7T_OOP_3.Classes;

namespace NET_7_OOP_2.Classes
{
    internal class Cinema : IPrintable
    {
        private const int MaxTickets = 20;
        private Ticket[] _tickets = new Ticket[MaxTickets];
        public Projector Projector { get; }
        public string CinemaName { get; }

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
            _tickets = new Ticket[MaxTickets];
            Projector = new Projector();
        }
        public Ticket this[int index]
        {
            get 
            {
                if(index < 0 || index >= _tickets.Length)
                {
                    return null;
                }
                else
                {
                    return _tickets[index];
                }
            }
            set
            {
                if(index >= 0 && index < _tickets.Length)
                {
                    _tickets[index] = value;
                }
            }
        }
        public Ticket this[string movieName]
        {
            get
            {
                for(int i=0;i<_tickets.Length;i++)
                {
                    if (_tickets[i] != null && movieName == _tickets[i].MovieName)
                    {
                         return _tickets[i];
                    }
                }
                return null;
            }
            
        }
        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == null)
                {
                    _tickets[i] = t;
                    return true;
                }
            }

            return false;
        }
        public static void ProcessTicket(Ticket t)
        {
            t.Print();
        }
        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            Projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine();
            Console.WriteLine("========== Cinema Closed ==========");
            Projector.Stop();
        }

        public void Print()
        {
            Console.WriteLine("\n========== All Tickets ==========");

            foreach (var ticket in _tickets)
            {
                if (ticket != null)
                {
                    ticket.Print();
                }
            }
        }
    }
}
