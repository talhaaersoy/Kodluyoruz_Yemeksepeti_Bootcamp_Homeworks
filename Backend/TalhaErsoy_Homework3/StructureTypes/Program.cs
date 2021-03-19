using System;

namespace StructureTypes
{
    class Program
    {
        struct Urun
        {
            public int urunNo;
            public string urunAdi;
            public string urunKategori;
            public string urunAciklama;
            public Urun(int a, string b, string c, string d) // Structture yapıları  Parametresiz constructor içeremezlerler***
            {
                urunNo = a;
                urunAdi = b;
                urunKategori = c;
                urunAciklama = d;
            }
        }
        static void Main(string[] args)
        {
            Urun yeniurun = new Urun(1, "Tablet Pc", "Elektronik", "Ev Kullanımı İçin Uygun");
            Console.WriteLine(yeniurun.urunNo);
            Console.WriteLine(yeniurun.urunAdi);
            Console.WriteLine(yeniurun.urunKategori);
            Console.WriteLine(yeniurun.urunAciklama);
            Console.ReadKey();
        }

        /*
         Temel olarak Struct için "Aralarında mantıksal bir ilişki bulunan farklı türden bilgilerin tanımnladığı
        ve üstlernde işlemlerin yapıldığı yapılardır." diyebiliriz.
        -Struct yapılar constructorlar, sabitler,fields'lar methodlar propertyler indexler,operatörler event ve nested tipleri içerebilirler.
        -Structlar parametresiz constructor veya destructor içeremezler.
        -Structlar İnterfacelerden implemnte olurlar ancak classlardan olamazlar.
         */
    }
}
