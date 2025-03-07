﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOlayer.DiscountDtos
{
	public class GetByIdDiscountDto
	{
		public int DiscountID { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}
