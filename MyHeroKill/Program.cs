using MyHeroKill.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHeroKill
{
    class Program
    {
        static void Main(string[] args)
        {

            TestCard();
            Console.Read();
        }
        static void TestCard()
        {
            var cardService = new CardService();
            for (int i = 0; i < 5; i++)
            {
                var ret = cardService.GetNewCards();
                Print(ret);
                Console.WriteLine("_______________");
                Thread.Sleep(1000);
            }
        }
        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }
    }
}
