using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRWebUI.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int OrderID { get; set; }      
        public string Description { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
		public int MenuTableId { get; set; }
		public MenuTable MenuTable { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
    }
}
