using System;

namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> i = null;
            // Veya    int? i = null;


            if (i.HasValue)
                Console.WriteLine(i.Value); // or Console.WriteLine(i)
            else
                Console.WriteLine("Null");

            /* Değer tipler null değer atanamaz. Bir değer tipine null bir değer atarsak compile anınnda hata alırız.
             Ancak C#, Nullable <T> kullanarak veya "int? = null;" bu  örnekteki gibi  değişken türünün yanına soru işareti koyarak null bir atama imkanı sunar. "" 
             
            Nullable tipler System.Nullable<T> türündedirler (T, Yalnızca değer tipi olabilir.) 

    
             */
        }
    }
}
