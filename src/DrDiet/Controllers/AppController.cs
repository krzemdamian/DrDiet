using DrDiet.Data;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Products()
        {
            var result = _ctx.Products.ToList();
            var result2 = _ctx.Recipes.ToList();
            var result3 = _ctx.Courses.ToList();
            var result4 = _ctx.MenuPositions.ToList();

            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
    }
}
