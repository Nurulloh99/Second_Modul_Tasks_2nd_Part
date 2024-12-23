using _1._1_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_Lesson.Models
{
    public class Meals
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public List<string> Comments { get; set; }
        public List<string> NegativeComments { get; set; }
    }
}
