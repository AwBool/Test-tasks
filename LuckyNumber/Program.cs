using System;

namespace LuckyNumber
{

    class Program
    {
        static void Main(string[] args)
        {
            var basis = 13; //[0,1,2,3,4,5,6,7,8,9,A,B,C]
            var digits = 13;//1234AB988BABA
            var count = new DynaProg().GetCount(basis, digits);
            Console.WriteLine(count);
        }
    }
}
