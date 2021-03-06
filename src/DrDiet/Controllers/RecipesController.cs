using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrDiet.Data;
using DrDiet.Data.Entities;
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

            ViewBag.products = _ctx.Products.OrderBy(p => p.Name);

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
            _ctx.Remove(ingredientToRemove);

            _ctx.Recipes.Update(model);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = modelId });
        }

        public IActionResult AddIngredient(int modelId, int productId, int weightInGrams)
        {
            var model = _ctx.Recipes
                .Where(r => r.Id == modelId)
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Product)
                .FirstOrDefault();

            var product = _ctx.Products.Find(productId);
            var ammountInKilos = (double)weightInGrams / 1000.0;
            var newIngredient = new Ingredient() { Ammount = ammountInKilos, Product = product };
            model.Ingredients.Add(newIngredient);

            _ctx.Recipes.Update(model);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = modelId });
        }

        public IActionResult Rename(int id, string newName)
        {
            var model = _ctx.Recipes.Find(id);
            model.Name = newName;

            _ctx.Update(model);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = id });
        }

        public IActionResult EditInstructions(int id, string newInstructions)
        {
            var model = _ctx.Recipes.Find(id);
            model.Instructions = newInstructions;

            _ctx.Update(model);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = id });
        }

        public IActionResult Add([FromForm] Recipe recipe)
        {
            // TODO: add ViewModel insted adapting ammount
            if (recipe.Ingredients is { })
            {

                var usedProductIds = recipe.Ingredients.Select(i => i.Product).Select(p => p.Id);
                var productsInDb = _ctx.Products.Where(p => usedProductIds.Contains(p.Id)).ToDictionary(p => p.Id, p => p);
                foreach(var ingredient in recipe.Ingredients)
                {
                    ingredient.Product = productsInDb[ingredient.Product.Id];
                    ingredient.Ammount /= 1000;
                }
                _ctx.Recipes.Add(recipe);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.products = _ctx.Products.OrderBy(p => p.Name);

            return View();
        }

        public IActionResult Delete(int id)
        {
            var recipeToDelete = _ctx.Recipes
                .Where(r => r.Id == id)
                .Include(r => r.Ingredients)
                .FirstOrDefault();
            recipeToDelete.Ingredients.ToList().ForEach(i => _ctx.Remove(i));
            _ctx.Recipes.Remove(recipeToDelete);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
