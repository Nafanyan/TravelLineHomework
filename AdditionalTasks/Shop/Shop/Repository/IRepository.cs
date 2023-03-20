﻿namespace Shop.Repository
{
    interface IRepository<Product> : IDisposable
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();

    }
}
