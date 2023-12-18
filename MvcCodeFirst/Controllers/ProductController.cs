using Microsoft.AspNetCore.Mvc;
using MvcCodeFirst.Models.Entities;
using MvcCodeFirst.Models.ViewModels;
using MvcCodeFirst.Repositories.Abstracts;

namespace MvcCodeFirst.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _ProductRepository;
        public ProductController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }//dependency injection (contexti interface e aldırıp tek sefer kullanarak dahil etme )



        public IActionResult Index()
        {
            List<Product> result = _ProductRepository.ProductList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM model)
        {


            if (ModelState.IsValid)
            {
                var result = _ProductRepository.ProductCrate(model);
                TempData["Result"] = result;
                return View();
            }
            else
            {
              
                return View(model);
            }


        }
    }
}
