using AutoMapper;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiBanco.App_Start
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClienteDTO, ClienteVM>();
            CreateMap<ClienteVM, ClienteDTO>();
            CreateMap<IMapperWrapper, AutoMapperWrapper>();
        }       
    }
}