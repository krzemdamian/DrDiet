using DrDiet.Data;
using DrDiet.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Controllers
{
    public class AppController : Controller
    {
        private readonly DrdietContext _ctx;

        public AppController(DrdietContext ctx)
        {
            this._ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            //var model = _ctx.Recipes.Include(r => r.Ingredients).ToList();
            var model = _ctx.Recipes.Include(r => r.Ingredients).ThenInclude(i => i.Product);
            return View(model);
        }

        public IActionResult Menu()
        {
            var model = _ctx.Courses.ToList();
            var model2 = _ctx.MenuPositions.ToList();
            return View();
        }
    }
}
