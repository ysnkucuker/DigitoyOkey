using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinKucuker
{
    class Kazanan
    {
        Masa _masa;
        public Kazanan()
        {
            _masa = new Masa();
            _masa.OyunuBaslat();
        }

        public int CiftPerBul(Oyuncu O)
        {
            List<int> taslar = O.Taslarim;
            int ciftSayisi = 0;
            for (int i = 0; i < taslar.Count; i++)
            {
                int tempTasNo = taslar[i];
                for (int j = i + 1; j < taslar.Count; j++)
                {
                    var ikinciTas = taslar[j];
                    if (tempTasNo == ikinciTas)
                    {
                        ciftSayisi++;
                        continue;
                    }
                }
            }
            return ciftSayisi;
        }

        public int OkeySayisiBul(List<int> taslar)
        {
            int okeySayisi = 0;
            for (int i = 0; i < taslar.Count; i++)
            {
                if (taslar[i] == _masa.Gosterge + 1)
                    okeySayisi++;

            }
            return okeySayisi;
        }

        public int CiftKazananBul()
        {
            int kazananOyuncuNo = 0;
            int yuksek = 0;

            for (int i = 0; i < 4; i++)
            {
                var tempTasList = _masa.Oyuncular[i].Taslarim;
                var okeySayisi = OkeySayisiBul(tempTasList);
                var tempPuan = CiftPerBul(_masa.Oyuncular[i]) + okeySayisi;
                _masa.Oyuncular[i].CiftSayisi = tempPuan;
                Console.WriteLine("Oyuncu : " + i + " Çift Sayısı :  " + _masa.Oyuncular[i].CiftSayisi);
                if (tempPuan > yuksek)
                {
                    yuksek = tempPuan;
                    kazananOyuncuNo = i;
                }
            }
            Console.WriteLine("En çok çift bulunduran oyuncu : " + kazananOyuncuNo + "\n");
            return kazananOyuncuNo;
        }

        /// <summary>
        /// Bu metod gereksiz taşların sayısını döner
        /// </summary>
        /// <param name="taslar"></param>
        /// <returns></returns>
        public int SiraliKazananBul(List<int> taslar)
        {
            int okeySayisi = OkeySayisiBul(taslar);
            int gereksizTasSayisi = taslar.Count;
            var tempList = new List<int>();
            var tempTaslar = new List<int>(taslar);
            taslar.Sort();
            int counter = 0;
            // Ardışık aynı renk seri bulma
            for (int i = 0; i < taslar.Count; i++)
            {
                Console.Write(taslar[i] + ",");
                if (i == taslar.Count - 1 || (taslar[i + 1] % 13 - taslar[i] % 13 == 1 && taslar[i + 1] / 13 == taslar[i] / 13)) // ardışıksa 
                {
                    counter++;
                }

                else if (i == taslar.Count - 2 || (taslar[i + 2] % 13 - taslar[i] % 13 == 2 && taslar[i + 2] / 13 == taslar[i] / 13 && okeySayisi > 0)) // aralarındaki fark 2 ama okey varsa per yap
                {
                    counter += 2; // okeey birleştirildi. boolen değer set et true yap
                }

                else
                {
                    if (counter >= 2)
                    {
                        for (int j = i - counter; j < i + 1; j++)
                        {
                            // boolean true ise okey ekle (gösterge+1)
                            tempList.Add(taslar[j]);
                            tempTaslar.Remove(taslar[j]);
                        }
                        gereksizTasSayisi -= tempList.Count;
                    }

                    else if (counter == 2 && okeySayisi > 0) // okey varsa ardışık iki sayının yanına ekle per elde et.
                    {
                        gereksizTasSayisi -= counter + 1;
                    }
                    counter = 0;
                }
                
            }
            Console.WriteLine();

            var tempRenkList = new List<int>();
            counter = 0;
            // Aynı rakamlar farklı renk serisi
            for (int i = 0; i < tempTaslar.Count; i++)
            {
                var tempNumara = tempTaslar[i] % 13;
                for (int j = i + 1; j < tempTaslar.Count; j++)
                {
                    if (tempTaslar[j] % 13 == tempNumara)
                    {
                        counter++;
                    }
                }
                if (counter >= 2)
                {
                    gereksizTasSayisi -= counter;
                }
                counter = 0;
            }

            return gereksizTasSayisi;
        }

        public int SiraliPerKazananBul()
        {
            int kazananOyuncuNo = 0;
            int gereksizTasSayisi = 14;
            for (int i = 0; i < 4; i++)
            {
                var tempTasList = _masa.Oyuncular[i].Taslarim;
                Console.Write("Oyuncu Numarasi : " + "[" + i + "]" + " ");
                var tempGereksizTasSayisi = SiraliKazananBul(tempTasList);
                if (tempGereksizTasSayisi < gereksizTasSayisi)
                {
                    gereksizTasSayisi = tempGereksizTasSayisi;
                    kazananOyuncuNo = i;
                }
            }
            Console.WriteLine("\nKazanan oyuncu : " + kazananOyuncuNo);
            return kazananOyuncuNo;
        }
    }
}
