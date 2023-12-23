using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWPF
{
    public class CarAdapter : IEntity
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Status { get; set; }
    }

}
