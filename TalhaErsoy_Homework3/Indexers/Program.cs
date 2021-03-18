using System;

namespace Indexers
{
    /*
     Indexer bir class'a veya bir struct'a dizi gibi erişilmesini sağlayan yapıdır.
     */
    class Program
    {
        static void Main(string[] args)
        {
            IndexedNames names = new IndexedNames();
            names[0] = "Talha";
            names[1] = "ahmet ";
            names[2] = "Ali";
            names[3] = "Ayşe";
            names[4] = "Mahmut";
            names[5] = "Hayriye";
            names[6] = "Hasan";

            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine(names[10]);

        }
    }

    class IndexedNames
    {
        private string[] namelist = new string[size];
        static public int size = 10;

        public string this[int index] // Bir indexleyiciyi her zaman this anahtar sözcüğü ile tanımlamalıyız."this" burada IndexedNames classını işaret eder.
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = $"Listemizde {size} adet isim mevcut ";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }

        }
    }
}
