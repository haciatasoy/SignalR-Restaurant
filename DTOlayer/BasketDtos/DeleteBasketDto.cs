﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.BasketDtos
{
    public class DeleteBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get => Price * Count; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
