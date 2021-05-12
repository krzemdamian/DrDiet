using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public double GetTotalEnergy() => this.Ingredients.Sum(i => (double)i.Product.Energy * i.Ammount);
        public double GetTotalEnergyPerKilo()
            => this.Ingredients.Sum(i => (double)i.Product.Energy * i.Ammount) * GetMultiplierToKilo();

        public double GetMultiplierToKilo() => 1 / this.Ingredients.Sum(i => i.Ammount);
    }
}
