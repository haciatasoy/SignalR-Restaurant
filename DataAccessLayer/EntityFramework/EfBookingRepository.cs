using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBookingRepository : GenericRepository<Booking>, IBookingDal
	{
        SignalRContext context=new SignalRContext();
		public EfBookingRepository(SignalRContext context) : base(context)
		{
		}

        public void BookingStatusApproved(int id)
        {
            var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
            value.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
            value.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
