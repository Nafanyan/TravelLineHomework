
using Shop.Databases;

namespace Shop.Models
{
    public class ModelDB : IModels
    {
        private string _result;

        public ShopContext DB
        {
            get { return new ShopContext(); }
        }

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

        public void DeleteWithID(string id)
        {
            using (var db = new ShopContext())
            {

                var product = db.Products
                     .Where(i => i.Id == Convert.ToInt32(id))
                     .FirstOrDefault();

                db.Products.Remove(product);
                db.SaveChanges();
            }
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
                    if (p.Id == Convert.ToInt32(id) && p.CountInStock > 0) p.CountInStock--;
                    _result += $"id: {p.Id}, name:{p.NameProduct}, weight kg: {p.WeightProduct}, price: {p.Price}, description: {p.DescriptionProduct}, count in stock: {p.CountInStock}, type: {p.TypeProduct}\n";
                }
                db.SaveChanges();
            }
            return _result;
        }

        public bool WriteFile(string path)
        {
            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(ReadAll());
            }

            return File.Exists(path);
        }
    }
}

