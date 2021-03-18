using System;

namespace Delegates
{
    /*
     Delegate, Methotların bellek adresini tutmak için kullanılan yapılardır.(yani referans tipli yapılardır)
    -Delegateler bize bir methodu parametre olarak kullanabilmeyi sağlar.
     */
    class Program
    {
        public delegate int MyDelegate(int number1,int number2);

        static int Method1(int a ,int b)
        {
            return a + b;
        }

        static int Method2(int a, int b)
        {
            return a - b;
        }
        static void Main(string[] args)
        {
            MyDelegate del =new MyDelegate(Method1);
            MyDelegate del1 = new MyDelegate(Method2);

            Console.WriteLine(del(15,25));
            Console.WriteLine(del1(25,15));

        }
    }
}
