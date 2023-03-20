
using Shop.Database;
using Shop.Repository;
using Shop.Views;

namespace Shop.Models
{
    internal interface IProductModel
    {
        public Product Result { get; }
        public void Start(IRepository<Product> db, IViews views);

    }
}
