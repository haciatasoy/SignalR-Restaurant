using AutoMapper;
using DTOlayer.AboutDtos;
using DTOlayer.BasketDtos;
using DTOlayer.BookingDtos;
using DTOlayer.CategoryDtos;
using DTOlayer.ContactDtos;
using DTOlayer.DiscountDtos;
using DTOlayer.FeatureDtos;
using DTOlayer.MenuTableDtos;
using DTOlayer.MessageDtos;
using DTOlayer.NotificationDtos;
using DTOlayer.OrderDtos;
using DTOlayer.ProductDtos;
using DTOlayer.SocialMediaDtos;
using DTOlayer.TestimonialDtos;
using EntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping() {
			CreateMap<About, ResultAboutDto>().ReverseMap();
			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, GetByIdAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();

			CreateMap<Booking, ResultBookingDto>().ReverseMap();
			CreateMap<Booking, CreateBookingDto>().ReverseMap();
			CreateMap<Booking, GetByIdBookingDto>().ReverseMap();
			CreateMap<Booking, UpdateBookingDto>().ReverseMap();

			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, GetByIdContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();

			CreateMap<Discount, ResultDiscountDto>().ReverseMap();
			CreateMap<Discount, CreateDiscountDto>().ReverseMap();
			CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();
			CreateMap<Discount, UpdateDiscountDto>().ReverseMap();

			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, GetByIdProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
			

			CreateMap<SocialMedia, ResultSocialDto>().ReverseMap();
			CreateMap<SocialMedia, CreateSocialDto>().ReverseMap();
			CreateMap<SocialMedia, GetByIdSocialDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialDto>().ReverseMap();

			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, DeleteBasketDto>().ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

			CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

			CreateMap<Order, CreateOrderDto>().ReverseMap();

		}
	}
}
