using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinKucuker
{
    class Program
    {
        static void Main(string[] args)
        {
            string dagit;
            string kazanan;
            while (true)
            {
                Console.WriteLine("\nTaşları dağıtmak için D, çıkmak için herhangi bir tuşa bas..\n");
                dagit = Console.ReadLine();           
                if(dagit == "D" || dagit == "d")
                {
                    // Taşları Oyunculara Dağıt ve ekrana yazdır.
                    Kazanan k = new Kazanan();
                    Console.WriteLine("\nKazananı görmek için K, çıkmak için herhangi bir tuşa bas..\n");
                    kazanan = Console.ReadLine();

                    if(kazanan == "K" || kazanan == "k")
                    {
                        k.CiftKazananBul();
                        k.SiraliPerKazananBul();
                        continue;
                    }
                    else
                        break;
                }
                else
                    break;
            }        
            Console.ReadLine();
        }
    }
}
