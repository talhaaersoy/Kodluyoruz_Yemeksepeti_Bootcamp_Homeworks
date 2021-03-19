using System;
using FirstApplication.Data;
using FirstApplication.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Headers;
using Newtonsoft.Json;

namespace FirstApplication.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //private readonly List<ProductModel> _data = new List<ProductModel>();
        private readonly NewData _newData;

        public ProductsController()
        {
            _newData = NewData.Instance;

        }

        [HttpGet]
        public List<Product> Get()
        {

            return _newData.products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var data = _newData.products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var data = _newData.products.FirstOrDefault(c => c.Id == product.Id);
            if (data == null)
            {
                _newData.products.Add(product);
                SaveToMemory(_newData.products);
                return Ok();
            }
            else
            {
                data.Name = product.Name;
                data.Price = product.Price;
                SaveToMemory(_newData.products);

                return Ok();
            }


        }




        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var data = _newData.products.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                data.Name = product.Name;
                data.Price = product.Price;
                SaveToMemory(_newData.products);
                
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _newData.products.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                _newData.products.Remove(data);
                SaveToMemory(_newData.products);
                return Ok();
            }
        }

        [HttpOptions] 
        public HttpResponseMessage Options()
        {
                var resp = new HttpResponseMessage();
                resp.Headers.Add("Access-Control-Allow-Origin", "*");
                resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTİONS");

                return resp;
        }

        
        //Yapılan işlemleri product.Json'a bastım 
        public void SaveToMemory(List<Product> products)
        {
            string strResultJson = JsonConvert.SerializeObject(products);
            System.IO.File.WriteAllText(@"products.json",strResultJson);

        }
      





    }
}