using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Databases;

namespace Shop.Repository
{
    internal class SQLProductRepository : IRepository<Product>
    {
        private ShopContext _db;
        private bool _disposed;

        public SQLProductRepository()
        {
            _db = new ShopContext();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products;
        }

        public Product GetProduct(int id)
        {
            return _db.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
        }

        public void Create(Product product)
        {
            _db.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public override string ToString()
        {
            string result = "";
            foreach(Product product in _db.Products)
            {
                result += $"{product}\n";
            }
            return result;
        }

    }
}
