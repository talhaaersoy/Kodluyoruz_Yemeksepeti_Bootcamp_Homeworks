using System;

namespace FuncActionPredicate
{
    /*
     Func,System namespace'inde bulunan generic yapılı bir delegate'dir .Birden fazla delagate alabilir (max 16)
     Son parametresi çıkış parametresi olarak kabul edilir.

     Action ise Func delegate'nin değer dönmeyen versiyonu diyebiliriz.

     Predicate ise Func ve Action gibi bir delagatedir tek Parametre alır ve sadece boolean bir veri tipi döner.

     */
    class Program
    {
        static void Main(string[] args)
        {
            
            Func<int, int, int, int> sum = Summary;
            Console.WriteLine(sum(3, 4, 17));
            Action<int, int> sumAction = SummaryAction;
            sumAction(5,15);
            Predicate<int> valid = IsValid;
            Console.WriteLine(valid(35));

        }

        static bool IsValid(int number) => number < 30;
        static int Summary(int a, int b, int c) => a + b + c;
        static void SummaryAction(int a, int b) => Console.WriteLine(a + b);
    }
}
