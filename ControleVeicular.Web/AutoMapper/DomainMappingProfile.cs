using AutoMapper;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Web.ViewModels;

namespace ControleVeicular.Web.AutoMapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<MarcaViewModel, Marca>();

            CreateMap<Modelo, ModeloViewModel>();
            CreateMap<ModeloViewModel, Modelo>();

            CreateMap<Anuncio, AnuncioViewModel>();
            CreateMap<AnuncioViewModel, Anuncio>();

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, Usuario>();

            CreateMap<Usuario, UsuarioEditViewModel>();
            CreateMap<UsuarioEditViewModel, Usuario>();
        }
    }
}
