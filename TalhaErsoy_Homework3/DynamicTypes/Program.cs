using System;

namespace DynamicTypes
{
/*
 
 */
    class Program
    {
        static void Main(string[] args)
        {
            // C# 4.0 Öncesi
            Icecek secim = NeAlirsiniz(Menu.Icecek) as Icecek; // Metodun döndürdüğü tipi cast ederek Icecek tipine çevirmemiz gerekiyor
            secim.IcecekIc();

            // C# 4.0 Dynamic Language Runtime
            dynamic secim2 = NeAlirsiniz(Menu.Icecek); // Tip dinamik olarak belirleniyor
            secim2.IcecekIc();

            
            Console.WriteLine(secim2.GetType().Name);
        }
        static Object NeAlirsiniz(Menu menu)
        {
            if (menu == Menu.Icecek)
                return new Icecek();
            else
                return new Yiyecek();
        }

        enum Menu
        {
            Yiyecek,
            Icecek
        }

        public class Icecek
        {
            public void IcecekIc()
            {
                Console.WriteLine("Yarasın..");
            }
        }

        public class Yiyecek
        {
            public void YemekYe()
            {
                Console.WriteLine("Afiyet olsun..");
            }
        }
    }
}
