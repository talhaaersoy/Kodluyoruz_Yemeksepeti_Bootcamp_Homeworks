using System;
using FirstApplication.Model;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace FirstApplication.Data
{
    public class NewData
    {
        private NewData()
        {
            FillData();
        }

            public static NewData Instance { get { return Nested.instance; } }

            private class Nested
            {
                static Nested()
                {
                }

                internal static readonly NewData instance = new NewData();
            }

            //Oluşturduğum Patternin içinde verileri Jsondan çektim.
            public void FillData()
            {
                string strResultJson = String.Empty;
                strResultJson = File.ReadAllText(@"products.json");
                List<Product> List = JsonConvert.DeserializeObject<List<Product>>(strResultJson);
                foreach (var item in List)
                {
                    products.Add(item);
                }

            }
            public List<Product> products = new List<Product>();
    }

    
}
