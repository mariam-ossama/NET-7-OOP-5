
namespace NET_7T_OOP_3.Classes
{
    internal class Projector
    {
        public bool On { get; private set; }

        public void Start()
        {
            On = true;
            Console.WriteLine("Projector started.");
        }

        public void Stop()
        {
            On = false;
            Console.WriteLine("Projector stopped.");
        }
    }
}
