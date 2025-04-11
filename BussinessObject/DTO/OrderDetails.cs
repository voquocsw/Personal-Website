using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int UnitStock { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
