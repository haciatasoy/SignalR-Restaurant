using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.OrderDtos
{
	public class CreateOrderDto
	{
		public string Description { get; set; }

		
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
		public int MenuTableId { get; set; }
		public MenuTable MenuTable { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
