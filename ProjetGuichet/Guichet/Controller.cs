using System;

namespace Guichet
{
    public class Controller
    {
        public void StartMain()
        {
            Guichet guichet = Guichet.GetInstance();
            guichet.CheckGuichetState();

            Console.ReadKey();
        }
    }
}
