using AutoMapper;
using PartyProductAPI.Data;
using PartyProductAPI.Models;

namespace PartyProductAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Party, PartyModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductRate, ProductRateModel>().ReverseMap();
            CreateMap<PartyProduct, PartyProductModel>().ReverseMap();
            CreateMap<Invoice, InvoiceModel>().ReverseMap();
        }
    }
}
