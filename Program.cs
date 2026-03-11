using G_NET_7_CsharpOOP1;
using NET_7_OOP_2.Classes;
using NET_7_OOP_5.Classes.Ticket;
using NET_7_OOP_5.Interfaces;

namespace NET_7_OOP_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions
            #region Question 1
            /*
             * Q1 : What is an interface in C#? Why do we use interfaces instead
             * of depending on concrete classes directly?
             * Mention at least three benefits of using interfaces.
             */
            // the interface is a contract that a class which implement it must follow,
            // interface definces what to do NOT how it does it.

            // the interface defines a behavior, so if we want to define just a behavior not identity
            // so it is best to use interface not a concrete class that defines an identity.

            // benefits of using interface: 
            // 1- Apply loosly coupling.
            // 2- Enable multible inherirtance.
            // 3- Enable polymorphism without inheritance.
            #endregion

            #region Question 2
            /*
             * interface IEnglishSpeaker
               {
                  void Greet();
               }

               interface IArabicSpeaker
               {
                   void Greet();
               }

               class Translator : IEnglishSpeaker, IArabicSpeaker
               {
                   public void Greet()
               {
               Console.WriteLine("Hello / Ahlan");
               }
              }
             */

            /*
             * a) What is the problem with this design?
             *    Both interfaces have a method called Greet()
             *    — how does the class handle it currently?
             */
            // The problem is both interfaces IEnglishSpeaker and IArabicSpeaker defines
            //  a function using the same name and signature while class Translator
            //  implements both interfaces so it only implement one of them with same
            //  implementation and this is confusing because it made both methods have the same behavior.
            //  it is okay if the business case allow this but if no, we will have a logical error.
            // =======================================================================================
            /*
             * b) How would you fix this so IEnglishSpeaker.Greet() 
             * says "Hello" and IArabicSpeaker.Greet() says "Ahlan"?
             * What is this technique called?
             */
            // We will need to use Explicit implementation to solve this problem
            // this is the new implementation:-
            //    interface IEnglishSpeaker
            //{
            //    void Greet();
            //}
            //interface IArabicSpeaker
            //{
            //    void Greet();
            //}
            //class Translator : IEnglishSpeaker, IArabicSpeaker
            //{
            //    public void IEnglishSpeaker.Greet()
            //    {
            //        Console.WriteLine("Hello");
            //    }
            //    public void IArabicSpeaker.Greet()
            //    {
            //        Console.WriteLine("Ahlan");
            //    }
            //}
            // =======================================================================================
            /*
             * c) After applying your fix, can you call Greet() directly
             *    on a Translator object (e.g. translator.Greet())?
             *    Why or why not? How do you call each version?
             */

            // Not directly, we will need to cast to spcify which interface.
            // Translator translator = new Translator();
            // IEnglishSpeaker english = translator;
            // english.Greet(); // prints Hello
            // IArabicSpeaker arabic = translator;
            // arabic.Greet(); // prints Ahlan

            // OR directly cast
            // ((IEngkishSpeaker)translator).Greet(); // prints Hello
            // ((IArabicSpeaker)translator).Greet(); // prints Ahlan

            #endregion

            #region Question 3
            /*
             * Q3 : Explain the difference between a shallow copy and a deep copy.
             * When would you use each one? What is the risk of using a shallow copy
             * when the object has reference-type fields?
             */
            // Shallow Copy => Creates a new object, but copies the values of the fields as they are.
            //              => If the object has a reference-type like an object, the address/reference itself is copied
            //              => so any modification to it both objects will be modified.
            // Deep Copy => A deep copy creates a completely independent copy of the object.
            //           => All reference-type fields are also copied into new objects.

            // Use Shallow Copy When:
            // 1. Object is immutable.
            // 2. No nested reference type attributes/fields.
            // 3. Good performance is necessary.

            // Use Deep Copy when:
            // 1. Objects must be isolated.
            // 2. Modifications shouldn't affect the original object.

            // Risk of using Shallow copy is that objects contains reference type fields share the same object
            // so any modification to one copy affects the other which may result in an unexpected behavior
            // or bugs.
            #endregion

            #region Question 4
            // The output is: 
            // Dev - Testing
            // QA - Testing

            // This output is because it uses shallow copy so e2 is a copy of e1
            // but since the Employee object has Department object which is a 
            // reference type so e1 and e2 shares the same department object
            // as shallow copy copies the reference/adderess of nested refernce type fields.

            // e2.Title = "QA"; // this line changes the title of e2 from "Dev" to "QA"
            // e2.Dept.Name = "Testing"; // this line affects both object so both department name will be "Testing"

            // Finally
            // e1.Title => "Dev"
            // e1.Dept.Name => "Testing"
            // e2.Title => "QA"
            // e2.Dept.Name => "Testing"
            #endregion
            #endregion

            #region Part 02 : Practical (Extending the Movie Ticket Booking System)
            // a. Create Cinema and open it
            Cinema cinema = new Cinema("VOX");
            cinema.OpenCinema();

            // b. Create tickets
            StandardTicket t1 = new StandardTicket("Inception", 80, new Seat('A',5));
            VIPTicket t2 = new VIPTicket("Avengers", 200, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 130, true);

            // Book them
            t1.BookTicket();
            t2.BookTicket();
            t3.BookTicket();

            // Add to cinema
            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            // c. Print all tickets through cinema
            cinema.Print();

            // d. Clone VIP ticket
            Console.WriteLine("\n--- Clone Test ---");

            VIPTicket clone = (VIPTicket)t2.Clone();
            clone.MovieName = "Interstellar";

            Console.Write("Original : ");
            t2.Print();

            Console.Write("Clone    : ");
            clone.Print();

            // e. Cancel one ticket
            Console.WriteLine("\n--- After Cancellation ---");
            t1.Cancel();
            t1.Print();

            // f. Use utility method
            Console.WriteLine("\n--- BookingHelper.PrintAll ---");

            IPrintable[] printableTickets = { t1, t2, t3 };

            BookingHelper.PrintAllTickets(printableTickets);

            // g. Close cinema
            cinema.CloseCinema();
            #endregion
        }
    }
}
