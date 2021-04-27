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
            ViewBag.recipes = _ctx.Recipes.Include(r=>r.Ingredients).ThenInclude(i => i.Product).OrderBy(p => p.Name);
            ViewBag.products = _ctx.Products.OrderBy(p => p.Name);

            return View();
        }
    }
}
