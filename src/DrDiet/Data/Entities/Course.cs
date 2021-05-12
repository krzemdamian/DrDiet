using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDiet.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public double Ammount { get; set; }
    }
}
