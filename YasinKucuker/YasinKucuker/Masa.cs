using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinKucuker
{
    static class ExtensionsClass
    {
        private static Random rng = new Random();

        // Fisher-Yates shuffle algoritmasi
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Masa
    {
        public int Gosterge;
        public List<int> Taslar;
        public Oyuncu[] Oyuncular;

        public void TaslariOlustur()
        {
            Taslar = new List<int>();
            for (int i = 0; i < 106; i++)
                Taslar.Add(i % 53);
            Taslar.Shuffle();
        }

        public void OyuncularaDagit()
        {
            Random rnd = new Random();
            int baslayanOyuncu = rnd.Next(3);
            int index = 0;
            Gosterge = Taslar[0];
            for (int i = 1; i < 106;)
            {

                int len = index == baslayanOyuncu ? 15 : 14;
                for (int j = 0; j < len; j++)
                {
                    Oyuncular[index].Taslarim.Add(Taslar[i++]);
                    Console.Write(Taslar[i]  + ",");
                }
                Console.WriteLine();
                index++;
                if (i == 58)
                {
                    Console.WriteLine("Gösterge : " + Gosterge);
                    break;
                }
            }
        }

        public void OyuncuOlustur()
        {
            Random rnd = new Random();
            int baslayanOyuncu = rnd.Next(3);
            Oyuncular = new Oyuncu[4];
            for (int i = 0; i < 4; i++)
                Oyuncular[i] = new Oyuncu();
        }

        public void OyunuBaslat()
        {
            TaslariOlustur();
            OyuncuOlustur();
            OyuncularaDagit();
        }
    }
}
