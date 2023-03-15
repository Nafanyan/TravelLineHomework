
using Microsoft.EntityFrameworkCore;
using Shop.Databases;
using System.Diagnostics;
using System.Globalization;

namespace Shop.Models
{
    internal class ModelDB : IModels
    {
        private string _result;



        public string AddRequest(string request)
        {
            _result = "";

            string[] args = request.Split(' ');

            using (var db = new ShopContext())
            {

                var product = db.Products.OrderBy(p => p.Id);

                Product newProduct = new Product
                {
                    NameProduct = Convert.ToString(args[1]),
                    WeightProduct = float.Parse(args[2].Replace('.', ',')),
                    Price = Convert.ToDecimal(args[3]),
                    DescriptionProduct = Convert.ToString(args[4]),
                    CountInStock = Convert.ToInt32(args[5]),
                    TypeProduct = Convert.ToString(args[0])
                };


                db.Products.Add(newProduct);
                db.SaveChanges();
            }
            return ReadAll();
        }

        public string GetTypeProduct()
        {
            _result = "";
            using (var db = new ShopContext())
            {
                var product = db.Products.OrderBy(p => p.TypeProduct).GroupBy(x => x.TypeProduct).Select(y => y.First());

                foreach (Product p in product)
                {
                    _result += $"{p.TypeProduct}\n";
                }
            }
            return _result;
        }

        public string ReadAll()
        {
            _result = "";
            using (var db = new ShopContext())
            {
                var product = db.Products.OrderBy(p => p.TypeProduct);

                foreach (Product p in product)
                {
                    _result += $"id: {p.Id}, name: {p.NameProduct}, weight kg: {p.WeightProduct}, price: {p.Price}, description: {p.DescriptionProduct}, count in stock: {p.CountInStock}, type: {p.TypeProduct}\n";
                }
            }
            return _result;
        }

        public string ReadRequest(string request)
        {
            _result = "";

            using (var db = new ShopContext())
            {
                var product = db.Products.OrderBy(p => p.TypeProduct);

                foreach (Product p in product)
                {
                    if (p.TypeProduct == request)
                    {
                        _result += $"id: {p.Id}, name: {p.NameProduct}, weight kg: {p.WeightProduct}, price: {p.Price}, description: {p.DescriptionProduct}, count in stock: {p.CountInStock}, type: {p.TypeProduct}\n";
                    }
                    
                }
            }

            return _result;
        }

        public string RemoveElement(string id)
        {
            _result = "";
            using (var db = new ShopContext())
            {
                var product = db.Products.OrderBy(p => p.TypeProduct);

                foreach (Product p in product)
                {
                    if (p.Id == Convert.ToInt32(id)) p.CountInStock--;
                    _result += $"id: {p.Id}, name:{p.NameProduct}, weight kg: {p.WeightProduct}, price: {p.Price}, description: {p.DescriptionProduct}, count in stock: {p.CountInStock}, type: {p.TypeProduct}\n";
                }
            }
            return _result;
        }
    }
}

