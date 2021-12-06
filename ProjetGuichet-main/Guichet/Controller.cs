using System;

namespace Guichet
{
    public class Controller
    {
        public static void Main(string[] args)
        {
            Guichet guichet = Guichet.GetInstance();
            guichet.CheckGuichetState();

            Console.ReadKey();
        }
    }
}
