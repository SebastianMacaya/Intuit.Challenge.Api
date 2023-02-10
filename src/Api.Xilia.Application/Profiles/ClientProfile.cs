using Api.Intuit.Application.Models.Clients.Response;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Intuit.Application.Profiles
{
    public class ClientProfile :Profile
    {

        public ClientProfile()
        {
            CreateMap<Cliente, GetByIdClientResponseModel>()
                .ForMember(destino => destino.id, origen => origen.MapFrom(src => src.ID))
                .ForMember(destino => destino.name, origen => origen.MapFrom(src => src.name))
                .ForMember(destino => destino.surname, origen => origen.MapFrom(src => src.surname))
                .ForMember(destino => destino.birthdate, origen => origen.MapFrom(src => src.birthdate))
                .ForMember(destino => destino.cuit, origen => origen.MapFrom(src => src.cuit))
                .ForMember(destino => destino.address, origen => origen.MapFrom(src => src.address))
                .ForMember(destino => destino.phone, origen => origen.MapFrom(src => src.phone))
                .ForMember(destino => destino.email, origen => origen.MapFrom(src => src.email));

            CreateMap<Cliente, GetAllClientsResponseModel>()
             .ForMember(destino => destino.id, origen => origen.MapFrom(src => src.ID))
             .ForMember(destino => destino.name, origen => origen.MapFrom(src => src.name))
             .ForMember(destino => destino.surname, origen => origen.MapFrom(src => src.surname))
             .ForMember(destino => destino.birthdate, origen => origen.MapFrom(src => src.birthdate))
             .ForMember(destino => destino.cuit, origen => origen.MapFrom(src => src.cuit))
             .ForMember(destino => destino.address, origen => origen.MapFrom(src => src.address))
             .ForMember(destino => destino.phone, origen => origen.MapFrom(src => src.phone))
             .ForMember(destino => destino.email, origen => origen.MapFrom(src => src.email));

            CreateMap<Cliente, PutClientResponseModel>()
                .ForMember(destino => destino.id, origen => origen.MapFrom(src => src.ID))
             .ForMember(destino => destino.name, origen => origen.MapFrom(src => src.name))
             .ForMember(destino => destino.surname, origen => origen.MapFrom(src => src.surname))
             .ForMember(destino => destino.birthdate, origen => origen.MapFrom(src => src.birthdate))
             .ForMember(destino => destino.cuit, origen => origen.MapFrom(src => src.cuit))
             .ForMember(destino => destino.address, origen => origen.MapFrom(src => src.address))
             .ForMember(destino => destino.phone, origen => origen.MapFrom(src => src.phone))
             .ForMember(destino => destino.email, origen => origen.MapFrom(src => src.email));




        }
    }
}
