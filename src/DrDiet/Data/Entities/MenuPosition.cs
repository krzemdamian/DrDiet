using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Data.Entities
{
    public class MenuPosition
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Ingredient> OtherProducts { get; set; }
    }
}
