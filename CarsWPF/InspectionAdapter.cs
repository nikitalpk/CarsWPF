using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWPF
{
    public class InspectionAdapter : IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }


}
