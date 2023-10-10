using MiBancoService.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Domain.Models
{
    public static class ConvertVM
    {
        public static ClienteVM ConvertToClienteVm(ClienteDTO Dto)
        {
            return new ClienteVM
            {
                Codigo = Dto.Codigo,
                CodigoActivacion = Dto.Codigo,
                Nombre = Dto.Nombre,
                Apellido = Dto.Apellido,
                Ocupacion = Dto.Ocupacion,
                NumeroContacto = Dto.NumeroContacto,
                Estado = Dto.Estado,
                EstadoActivo = Dto.Estado
            };
        }

        public static ClienteDTO ConvertToClienteDto(ClienteVM Vm)
        {
            return new ClienteDTO
            {
                Codigo = Vm.Codigo,
                Nombre = Vm.Nombre,
                Apellido = Vm.Apellido,
                Ocupacion = Vm.Ocupacion,
                NumeroContacto = Vm.NumeroContacto.Replace("-",""),
                Estado = Vm.Estado
            };
        }

        public static TarjetaVM ConvertToTarjetaVm(TarjetaDTO Dto)
        {
            return new TarjetaVM
            {
                CodigoTarjeta = Dto.CodigoTarjeta,
                TipoTarjetaId = Dto.TipoTarjetaId,
                CodigoCliente = Dto.CodigoCliente,
                Tipo = Dto.Tipo,
                Banco = Dto.Banco,
                Numero = Dto.Numero,
                MesVence = Dto.MesVence,
                AnioVence = Dto.AnioVence                
            };
        }

        public static TarjetaDTO ConvertToTarjetaDto(TarjetaVM Dto)
        {
            return new TarjetaDTO
            {
                CodigoTarjeta = Dto.CodigoTarjeta,
                TipoTarjetaId = Dto.TipoTarjetaId,
                CodigoCliente = Dto.CodigoCliente,
                Tipo = Dto.Tipo,
                Banco = Dto.Banco,
                Numero = Dto.Numero,
                MesVence = Dto.MesVence,
                AnioVence = Dto.AnioVence
            };
        }

        public static List<TarjetaVM> ConvertToTarjetaVm(List<TarjetaDTO> Dto)
        {

            if (Dto == null || !Dto.Any())
                return new List<TarjetaVM>();

              return  Dto.Select(x => new TarjetaVM
                                                { CodigoTarjeta = x.CodigoTarjeta,
                                                    TipoTarjetaId = x.TipoTarjetaId, 
                                                    Tipo = x.Tipo, Banco = x.Banco, 
                                                    Numero = x.Numero, 
                                                    MesVence = x.MesVence,
                                                    AnioVence = x.AnioVence
                                                    }).ToList();

        }    
    }
}
