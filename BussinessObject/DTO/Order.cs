using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class OrderDTO
    {
        public int OrderId {  get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; } = 1;
        public int AccountId { get; set; }

    }
}
