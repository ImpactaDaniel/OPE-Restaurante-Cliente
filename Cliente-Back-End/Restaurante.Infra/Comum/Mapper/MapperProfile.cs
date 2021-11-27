using AutoMapper;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using Restaurante.Integrations;

namespace Restaurante.Clientes.Infra.Comum.Mapper
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PhotoResponseDTO, Domain.Produtos.Modelos.Photo>()
                .ForMember(x => x.Path, opt => opt.MapFrom(s => s.PhotoPath));
            CreateMap<ProductCategoryResponseDTO, Domain.Produtos.Modelos.ProductCategory>();
            CreateMap<ProductResponseDTO, Produto>();
            CreateMap<Product, Produto>();
            CreateMap<Integrations.Photo, Domain.Produtos.Modelos.Photo>();
            CreateMap<Integrations.ProductCategory, Domain.Produtos.Modelos.ProductCategory>();
            CreateMap<Payment, Restaurante.Domain.Pedidos.Models.Payment>();
            CreateMap<InvoiceLog, Restaurante.Domain.Pedidos.Models.InvoiceLog>();
            CreateMap<InvoiceAddress, Restaurante.Domain.Pedidos.Models.InvoiceAddress>();
            CreateMap<InvoiceLine, Restaurante.Domain.Pedidos.Models.InvoiceLine>();
            CreateMap<Invoice, Restaurante.Domain.Pedidos.Models.Invoice>();
        }
    }
}
