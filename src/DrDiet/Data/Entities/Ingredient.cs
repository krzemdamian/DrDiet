using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Data.Entities
{
    public class Ingredient
    {
        public Product Product { get; set; }
        public double Ammount { get; set; }
    }
}
