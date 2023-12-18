using MvcCodeFirst.Models.Entities;
using MvcCodeFirst.Models.ViewModels;

namespace MvcCodeFirst.Repositories.Utils.ProductUtils
{
    public class VMConvertProduct
    {
        public static Product ProductConvert(ProductVM productVM)
        {
            Product product = new Product()
            {
                ProductName = productVM.ProductName,
                UnitPrice = productVM.UnitPrice,
                Category = productVM.Category,
                Description = productVM.Description,
                UnitsInStock = productVM.UnitsInStock,
            };
            return product;
        }
    }
}
