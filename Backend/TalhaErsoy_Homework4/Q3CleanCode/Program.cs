using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Channels;

namespace _3CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Bu Console Appi Yazarken iç içe olacak karışık işlemlerden korunmak amaçlı bütün işlemleri methodlara böldüm ve her methodun sadece bir işi var
             */
            BePositive();
            Ternary();
            DefineVariable();
            Simplyfy();
            ToolUsage();
            RuleOfSeven();
            FailFast(12);
            ReturnEarly(75);
        }

        private static bool ReturnEarly(int number)
        {
            int maxValue = 100;
            if (number > maxValue)
                return false;
            int minValue = 30;
            if (number < minValue)
                return false;
            else
                return true;
        }

        private static bool FailFast(int number)
        {
            if (number % 2 != 0)
            {
                throw new Exception("Sayı 6 ya bölünmüyor");
            }

            if (number % 3 != 0)
            {
                throw new Exception("Sayı 6 ya bölünmüyor");
            }

            return true;
        }

        private static void RuleOfSeven()
        {
            int yourMoney = 25;
            int hamburger = 15;
            if (yourMoney < hamburger)
            {
                Console.WriteLine("içecek iç");
            }

            int cola = 5;
            if (yourMoney < cola)
            {
                Console.WriteLine("Su iç!!");
            }
        }

        private static void ToolUsage()
        {
            List<string> members = new List<string>
            {
                "Talha", "şeyma", "buse", "Oğuz"
            };
            List<string> goldenMembers = new List<string>();
            goldenMembers.AddRange(members.Where(c => c.Length > 4 && c.StartsWith("T")));
        }

        private static void Simplyfy()
        {
            bool hungry = true;
            int yourMoney = 38;
            bool eat = hungry && yourMoney >= 20;
            if (eat)
            {
                Console.WriteLine("afiyet olsun");
            }
        }

        private static void DefineVariable()
        {
            string variable = "abc";
            int minLenght = 2;
            if (variable.Length < minLenght)
            {
            }
        }

        private static void Ternary()
        {
            int value = 30;
            string result = value <= 25 ? "Bakiyeniz yetersiz" : "İşlem başarılı";
        }

        private static void BePositive()
        {
            int yourMoney = 50;
            int foodPrice = 30;
            bool eat = yourMoney > foodPrice;

            if (eat)
            {
                yourMoney = yourMoney - foodPrice;
            }
        }
    }
}
