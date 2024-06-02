using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<Cliente, ClienteDTO>(). ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<EmprestimoDTO, Emprestimo>().ReverseMap().
                ForMember(dest => dest.LivroDTO, opt => opt.MapFrom(x => x.Livro)).
                ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(x => x.Cliente));
            CreateMap<Emprestimo, EmprestimoPostDTO>().ReverseMap();
        }
    }
}
