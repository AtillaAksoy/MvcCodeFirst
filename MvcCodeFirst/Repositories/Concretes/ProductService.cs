using MvcCodeFirst.Models.Context;
using MvcCodeFirst.Models.Entities;
using MvcCodeFirst.Models.ViewModels;
using MvcCodeFirst.Repositories.Abstracts;
using MvcCodeFirst.Repositories.Utils.ProductUtils;

namespace MvcCodeFirst.Repositories.Concretes
{
    public class ProductService:IProductRepository
    {
        private readonly ProjectContext _context;

        public ProductService(ProjectContext context)
        {
            _context = context;
        }//dependency injection instance

        public string ProductCrate(ProductVM model)
        {
            var result = VMConvertProduct.ProductConvert(model);
            try
            {
                _context.Products.Add(result);
                _context.SaveChanges();
                return "ürün oluşturuldu";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public string ProductDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> ProductList()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        //veriyi çekip liste halinde productvm e gönderip indexte onu sıralamak istedim fakat yapamadım. o yüzden direkt db yi çekip listeleteceğim
        //public List<ProductVM> ProductList()
        //{
        //    List<>
        //    //var products = _context.Products.ToList();
        //    return products;
        //}
    }
}
