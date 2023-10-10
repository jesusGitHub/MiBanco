using MiBancoService.Application.Contracts.Services;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Models;
using MiBancoService.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MiBanco.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ITarjetaService _tarjetaService;

        public TarjetaController(ITarjetaService tarjetaService, IClienteService clienteService)
        {
            _tarjetaService = tarjetaService;
            _clienteService = clienteService;
        }


        // GET: Tarjeta/Create
        [HttpPost]
        public async Task<ActionResult> GetPartialCreate(int CodigoCliente = 0, int CodigoTarjeta = 0)
        {
            var Vm = new TarjetaVM();
           
            if (CodigoTarjeta > 0)
            {
                  var Result = await _tarjetaService.OtenerTarjetaByCodigo(CodigoTarjeta);
                          Vm = ConvertVM.ConvertToTarjetaVm(Result.ResultObject);
            }

            var TipoResult = await _tarjetaService.ObtenerTiposTarjeta();
            Vm.DDlTipoTarjeta = new SelectList(TipoResult.ResultList, nameof(TipoResult.ResultObject.TipoTarjetaId), nameof(TipoResult.ResultObject.Descripcion));
            Vm.CodigoCliente = CodigoCliente;

            return PartialView("Partials/_CrearTarjeta", Vm);
        }
        
        // POST: Tarjeta/Create
        [HttpPost]
        public async Task<ActionResult> Create(TarjetaVM Vm)
        {
             var DtoTarjeta = ConvertVM.ConvertToTarjetaDto(Vm);
            var Result = new OperationResult<TarjetaDTO>();

               var ResultCliente = await _clienteService.ObtenerClienteByCodigo(Vm.CodigoCliente);
                ValidaCreacionTarjetaPorClietne(ResultCliente.ResultObject);
                ValidaTarjeta(Vm);

            if (ModelState.IsValid)
            {
                Result = await _tarjetaService.GuardarTarjeta(DtoTarjeta);
            }
            else {
                Result.Success = false;
                Result.Warning = true;
                Result.Messages = Utils.GetModelStateMessage(ModelState);
            }

            return Json(new
            {
                Result.Success,
                Result.Warning,
                Result.Messages
            }, JsonRequestBehavior.AllowGet);

        }

        public void ValidaCreacionTarjetaPorClietne(ClienteDTO Dto)
        {            
            if (Dto != null)
            {
                if (!Dto.Estado)
                    ModelState.AddModelError(nameof(Dto.Estado), "Estimado usuario el cliente al que está intentando agregarle la tarjeta se encuentra INACTIVO, favor recargue la página nuevamente para poder activarlo. ");
            }
        }

        public void ValidaTarjeta(TarjetaVM Vm)
        {
            var Tarjeta = _tarjetaService.OtenerTarjetaByNumero(Vm.Numero).ResultObject;

            if (Tarjeta != null && Vm.CodigoTarjeta <= 0)
            {                
                    ModelState.AddModelError(nameof(Vm.Numero), "Estimado usuario el numero de tarjeta que esta intentando utilizar ya esta registrado. ");
            }

            if (Tarjeta != null && Vm.CodigoTarjeta > 0)
            {
                if(Tarjeta.CodigoTarjeta != Vm.CodigoTarjeta)
                    ModelState.AddModelError(nameof(Vm.Numero), "Estimado usuario el numero de tarjeta que esta intentando utilizar ya esta registrado. ");
            }
        }


    }
}
