using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Order
    {
        [Key]
        public int OrderId {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = 1;
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }

    }
}
