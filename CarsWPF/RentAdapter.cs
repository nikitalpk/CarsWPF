using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWPF
{
    public class RentAdapter : IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public int ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalCost { get; set; }
    }


}
