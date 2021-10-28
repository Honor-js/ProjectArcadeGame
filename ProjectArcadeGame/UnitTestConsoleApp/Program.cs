using System;

namespace UnitTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("6^7=" + TotDeMacht(6, 7));
        }
        public static int TotDeMacht(int grondtal, int macht)
        {
            return (int)Math.Pow(grondtal, macht);
        }
    }

}
   