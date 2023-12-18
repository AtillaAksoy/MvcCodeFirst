using MvcCodeFirst.Models.Entities;
using MvcCodeFirst.Models.ViewModels;

namespace MvcCodeFirst.Repositories.Abstracts
{
    public interface IProductRepository
    {
        public string ProductCrate(ProductVM model);

        //public List<ProductVM> ProductList();
        public List<Product> ProductList();
        public string ProductDelete(int id);
    }
}
