using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrDiet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrDiet.Controllers
{
    public class RecipesController : Controller
    {
        private readonly DrdietContext _ctx;

        public RecipesController(DrdietContext ctx)
        {
            this._ctx = ctx;
        }

        public IActionResult Index()
        {
            var model = _ctx.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Product);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _ctx.Recipes
                .Where(r => r.Id == id)
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Product)
                .FirstOrDefault();

            return View(model);
        }

        public IActionResult DeleteIngredient(int modelId, int ingedientId)
        {
            var model = _ctx.Recipes
                .Where(r => r.Id == modelId)
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Product)
                .FirstOrDefault();

            var ingredientToRemove = model.Ingredients.FirstOrDefault(i => i.Id == ingedientId);
            model.Ingredients.Remove(ingredientToRemove);

            _ctx.Recipes.Update(model);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = modelId });
        }
    }
}
