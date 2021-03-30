using DrDiet.Data;
using DrDiet.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrDiet.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly DrdietContext _ctx;

        public ProductsController(DrdietContext ctx)
        {
            this._ctx = ctx;
        }

        public IActionResult Index()
        {
            var model = _ctx.Products.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string name, int kcal)
        {
            var newProduct = new Product()
            {
                Name = name,
                Energy = kcal * 10
            };

            _ctx.Add(newProduct);
            _ctx.SaveChanges();

            var model = _ctx.Products.ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var productToRemove = _ctx.Products.Find(id);
            _ctx.Remove(productToRemove);
            _ctx.SaveChanges();

            var model = _ctx.Products.ToList();

            return RedirectToAction(nameof(Index));
        }
    }
}
