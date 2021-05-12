using DrDiet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Data
{
    public class DrdietSeeder
    {
        private readonly DrdietContext _ctx;

        public DrdietSeeder(DrdietContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product() { Id=1, Name = "Chleb graham", Energy = 2208 },
                    new Product() { Id=2, Name = "Ser twarogowy półtłusty", Energy = 1330 },
                    new Product() { Id=3, Name = "Oliwa z oliwek", Energy = 8800 },
                    new Product() { Id=4, Name = "Natka pietruszki", Energy = 417 },
                    new Product() { Id=5, Name = "Sałata", Energy = 100 },
                    new Product() { Id=6, Name = "Ogórek", Energy = 100 },
                    new Product() { Id=7, Name = "Papryka czerwona", Energy = 240 },
                    new Product() { Id=8, Name = "Pomidor", Energy = 145 },
                    new Product() { Id=9, Name = "Rzodkiewka", Energy = 89 },
                    new Product() { Id=10, Name = "Jajko", Energy = 1207 },
                    new Product() { Id=11, Name = "Kasza jęczmienna pęczak", Energy = 3267 },
                    new Product() { Id=12, Name = "Indyk, mięso mielone", Energy = 927 },
                    new Product() { Id=13, Name = "Makaron razowy", Energy = 3640 },
                    new Product() { Id=14, Name = "Przecier pomidorowy", Energy = 1000 },
                    new Product() { Id=15, Name = "Chleb żytni razowy", Energy = 2133 },
                };

                _ctx.Products.AddRange(products);
                _ctx.SaveChanges();
            }

            if (!_ctx.Recipes.Any())
            {
                var recipes = new List<Recipe>()
                {
                    new Recipe()
                    {
                        Id=1,
                        Name="Kanapka z twarogiem i natką",
                        Ingredients = new List<Ingredient>
                        {
                            new Ingredient() { Id = 1, Product = _ctx.Products.Where(p => p.Id == 1).FirstOrDefault(), Ammount = 0.120 },
                            new Ingredient() { Id = 2, Product = _ctx.Products.Where(p => p.Id == 2).FirstOrDefault(), Ammount = 0.100 },
                            new Ingredient() { Id = 3, Product = _ctx.Products.Where(p => p.Id == 3).FirstOrDefault(), Ammount = 0.010 },
                            new Ingredient() { Id = 4, Product = _ctx.Products.Where(p => p.Id == 4).FirstOrDefault(), Ammount = 0.012 },
                        },
                        Instructions = "Twaróg wymieszaj z oliwą i drobno posiekaną natką."
                    },
                    new Recipe()
                    {
                        Id=2,
                        Name="Sałatka ze świerzych warzyw i jajka",
                        Ingredients = new List<Ingredient>
                        {
                            new Ingredient() { Id = 5, Product = _ctx.Products.Where(p => p.Id == 5).FirstOrDefault(), Ammount = 0.030 },
                            new Ingredient() { Id = 6, Product = _ctx.Products.Where(p => p.Id == 6).FirstOrDefault(), Ammount = 0.050 },
                            new Ingredient() { Id = 7, Product = _ctx.Products.Where(p => p.Id == 7).FirstOrDefault(), Ammount = 0.050 },
                            new Ingredient() { Id = 8, Product = _ctx.Products.Where(p => p.Id == 8).FirstOrDefault(), Ammount = 0.200 },
                            new Ingredient() { Id = 9, Product = _ctx.Products.Where(p => p.Id == 9).FirstOrDefault(), Ammount = 0.045 },
                            new Ingredient() { Id = 10, Product = _ctx.Products.Where(p => p.Id == 10).FirstOrDefault(), Ammount = 0.150 },
                            new Ingredient() { Id = 11, Product = _ctx.Products.Where(p => p.Id == 3).FirstOrDefault(), Ammount = 0.015 },
                            new Ingredient() { Id = 12, Product = _ctx.Products.Where(p => p.Id == 11).FirstOrDefault(), Ammount = 0.075 },
                        },
                        Instructions = "Na sałatę położyć pokrojone warzywa i kaszę. Sałatkę polać oliwą i położyć pokrojone jajko."
                    }
                };

                _ctx.Recipes.AddRange(recipes);
                _ctx.SaveChanges();
            }

            if (!_ctx.Courses.Any())
            {
                var courses = new List<Course>()
                {
                    new Course() { Id = 1, Recipe = _ctx.Recipes.Where(r => r.Id == 1).FirstOrDefault(), Ammount = 1},
                    new Course() { Id = 2, Recipe = _ctx.Recipes.Where(r => r.Id == 2).FirstOrDefault(), Ammount = 1},
                };

                _ctx.Courses.AddRange(courses);
                _ctx.SaveChanges();
            }

            if (!_ctx.MenuPositions.Any())
            {
                var menuPositions = new List<MenuPosition>()
                {
                    new MenuPosition() { Id = 1, Courses = _ctx.Courses.Where(c => c.Id == 1).ToList(), DateTime = new DateTime(2021, 02, 15, 8, 30, 0), },
                    new MenuPosition() { Id = 2, Courses = _ctx.Courses.Where(c => c.Id == 2).ToList(), DateTime = new DateTime(2021, 02, 15, 12, 0, 0), },
                };

                _ctx.MenuPositions.AddRange(menuPositions);
                _ctx.SaveChanges();
            }

            _ctx.SaveChanges();
        }
    }
}
