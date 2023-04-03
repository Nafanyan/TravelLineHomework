
using Shop.Database;
using Shop.Repository;
using Shop.Views;

namespace Shop.Models
{
    internal abstract class BaseProductModel
    {
        public Product Result { get { return product; } }

        protected Product product;
        protected IRepository<Product> db;
        protected IViews views;

        protected BaseProductModel(IRepository<Product> db, IViews views)
        {
            this.db = db;
            this.views = views;
        }
        public abstract void Start();

    }
}
