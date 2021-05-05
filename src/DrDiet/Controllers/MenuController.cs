using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrDiet.Data;
using DrDiet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrDiet.Controllers
{
    public class MenuController : Controller
    {
        private readonly DrdietContext _ctx;

        public MenuController(DrdietContext _ctx)
        {
            this._ctx = _ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Add));
            //return View();

        }
        public IActionResult Add([FromForm] MenuPosition newPosition)
        {
            if (newPosition.Courses is { } || newPosition.OtherProducts is { })
            {
                var usedRecipesIds = newPosition.Courses.Select(c => c.Recipe.Id);
                var reciresInDB = _ctx.Recipes.Where(r => usedRecipesIds.Contains(r.Id))
                    .ToDictionary(r => r.Id, r => r);
                foreach (var course in newPosition.Courses ?? Enumerable.Empty<Course>())
                {
                    course.Recipe = reciresInDB[course.Recipe.Id];
                }

                var usedProductIds = newPosition.OtherProducts.Select(i => i.Product).Select(p => p.Id);
                var productsInDb = _ctx.Products.Where(p => usedProductIds.Contains(p.Id)).ToDictionary(p => p.Id, p => p);
                foreach (var otherProduct in newPosition.OtherProducts ?? Enumerable.Empty<Ingredient>())
                {
                    otherProduct.Product = productsInDb[otherProduct.Product.Id];
                    otherProduct.Ammount /= 1000;
                }

                _ctx.MenuPositions.Add(newPosition);
                _ctx.SaveChanges();
            }

            ViewBag.recipes = _ctx.Recipes.Include(r=>r.Ingredients).ThenInclude(i => i.Product).OrderBy(p => p.Name);
            ViewBag.products = _ctx.Products.OrderBy(p => p.Name);

            return View();
        }
    }
}
