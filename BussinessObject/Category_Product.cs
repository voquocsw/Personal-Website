﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Category_Product
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}
