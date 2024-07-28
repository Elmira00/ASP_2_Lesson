using ASP_2_Lesson.Entity;
using ASP_2_Lesson.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_2_Lesson.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Keyboard",
                Category = "Tech",
                Price = 28,
                Discount = 2,
                ImagePath="https://avatars.mds.yandex.net/i?id=33692e98abfff628bcee7af8038d8d2d1363a341-12602658-images-thumbs&n=13"
            },
            new Product
            {
                Id = 2,
                Name = "Nike Shoes",
                Category = "Shoes",
                Price = 199,
                Discount = 15,
                ImagePath = "https://avatars.mds.yandex.net/i?id=55caec03d4442fe88c1211150117666b45f5ccbb-12471273-images-thumbs&n=13"
            },
            new Product
            {
                Id = 3,
                Name = "Red Skirt",
                Price = 60,
                Category = "Dress",
                Discount = 0,
                ImagePath = "https://avatars.mds.yandex.net/i?id=6b4ee0c28b6a53b9c30f0cc0ce8519df2d61e84bb4f0a112-11408895-images-thumbs&n=13"
            },

        };

        public IActionResult Index()
        {
            var ProductVM = new ProductViewModel
            {
                Products = Products
            };
            return View(ProductVM);
        }

        [HttpGet]
        public IActionResult Update(int myid)
        {
            myid -= 1;
            var product = Products[myid];
            var vm = new ProductUpdateViewModel
            {
                Product = product
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm, int myid)
        {
            myid -= 1;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == vm.Product.Id)
                {
                    myid = Products[i].Id;
                    break;
                }
            }
            var prod = Products[myid];
            prod.Price = vm.Product.Price;
            prod.Name = vm.Product.Name;
            prod.Category = vm.Product.Category;
            prod.Discount = vm.Product.Discount;
            prod.ImagePath = vm.Product.ImagePath;
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int myid)
        {
            myid -= 1;
            var prod = Products[myid];
            Products.Remove(prod);
            for (int i = (myid); i < Products.Count; i++)
            {
                Products[i].Id--;
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            Products.Add(vm.Product);
            vm.Product.Id = Products.Count;
            return RedirectToAction("index");
        }
    }
}