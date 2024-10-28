using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
           services.AddScoped<ICategoryDal, EfCategoryRepository>();
           services.AddScoped<ICategoryService, CategoryManager>();

           services.AddScoped<IAboutDal, EfAboutRepository>();
           services.AddScoped<IAboutService, AboutManager>();

           services.AddScoped<IBookingDal, EfBookingRepository>();
           services.AddScoped<IBookingService, BookingManager>();

           services.AddScoped<IContactDal, EfContactRepository>();
           services.AddScoped<IContactService, ContactManager>();

           services.AddScoped<IDiscountDal, EfDiscountRepository>();
           services.AddScoped<IDiscountService, DiscountManager>();

           services.AddScoped<IFeatureDal, EfFeatureRepository>();
           services.AddScoped<IFeatureService, FeatureManager>();

           services.AddScoped<IProductDal, EfProductRepository>();
           services.AddScoped<IProductService, ProductManager>();

           services.AddScoped<ISocialMediaDal, EfSocialMediaRepository>();
           services.AddScoped<ISocialMediaService, SocialMediaManager>();

           services.AddScoped<ITestimonialDal, EfTestimonialDal>();
           services.AddScoped<ITestimonialService, TestimonialManager>();

           services.AddScoped<IOrderDal, EfOrderRepository>();
           services.AddScoped<IOrderService, OrderManager>();

           services.AddScoped<IOrderDetailDal, EfOrderDetailRepository>();
           services.AddScoped<IOrderDetailService, OrderDetailManager>();

           services.AddScoped<IMoneyCaseDal, EfMoneyCaseRepository>();
           services.AddScoped<IMoneyCaseService, MoneyCaseManager>();

           services.AddScoped<IMenuTableDal, EfMenuTableRepository>();
           services.AddScoped<IMenuTableService, MenuTableManager>();

           services.AddScoped<IBasketDal, EfBasketRepository>();
           services.AddScoped<IBasketService, BasketManager>();

           services.AddScoped<INotificationDal, EfNotificationRepository>();
           services.AddScoped<INotificationService, NotificationManager>();

           services.AddScoped<IMessageDal, EfMessageRepository>();
           services.AddScoped<IMessageService, MessageManager>();
        }
    }
}
