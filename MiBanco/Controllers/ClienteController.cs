using AutoMapper;
using MiBanco.App_Start;
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
    public class ClienteController : Controller
    {

        private readonly IClienteService _clienteService;
        private readonly ITarjetaService _tarjetaService;

        public ClienteController(IClienteService clienteService, ITarjetaService tarjetaService) 
        {
            _clienteService = clienteService;
            _tarjetaService = tarjetaService;
        }


        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult> ConsultaCliente(ClienteVM vm = null)
        {
            var DtoCliente = GetParameterSearch(vm);
            DtoCliente.search = Request.Form.GetValues("search[value]")[0];

            var Result = await _clienteService.ObtenerCliente(DtoCliente);

            return Json(new
            {
                draw = "",
                vm.length,
                recordsFiltered = Result.TotalRecords.ToString(),
                recordsTotal = Result.TotalRecords.ToString(),
                data = from datos in Result.ResultList
                       select new
                       {
                           datos.Codigo
                          ,datos.Nombre
                          ,datos.Apellido
                          ,datos.NumeroContacto
                          ,datos.Ocupacion
                          ,Estado = datos.Estado ? "Activo" : "Inactivo"
                       }

            }, JsonRequestBehavior.AllowGet);
        }

        private static ClienteDTO GetParameterSearch(ClienteVM Vm)
        {
            var vistaAlmacen = new ClienteDTO
            {
                start = Utils.CalculaNumeroPagina(int.Parse(Vm.start), Vm.length).ToString()
               ,length = Vm.length
               ,Nombre = Vm.Nombre
            };
            return vistaAlmacen;
        }


        // GET: Cliente/Create
        [HttpGet]
        public async Task<ActionResult> Create(int Codigo = 0)
        {
            var Vm = new ClienteVM();

            if (Codigo > 0)
            {
                var Result = await _clienteService.ObtenerClienteByCodigo(Codigo);
                var ResultTarjeta = await _tarjetaService.ObtenerTarjetaByCliente(Codigo);
                var ListTarjeta = ConvertVM.ConvertToTarjetaVm(ResultTarjeta.ResultList);
                Vm = ConvertVM.ConvertToClienteVm(Result.ResultObject);
                Vm.TarjetaVMs = ListTarjeta;
            }
            
            return View("CreateCliente",Vm);
        }


        // POST: Cliente/GetPartialListadoTarjeta
        [HttpPost]
        public async Task<ActionResult> GetPartialListadoTarjeta(int CodigoCliente = 0)
        {
            var Vm = new List<TarjetaVM>();

            var Result = await _tarjetaService.ObtenerTarjetaByCliente(CodigoCliente);
            var ListTarjeta = ConvertVM.ConvertToTarjetaVm(Result.ResultList);


            return PartialView("Partials/_Tarjetas", ListTarjeta);
        }


        // POST: Cliente/Create 
        [HttpPost]
        public async Task<ActionResult> Create(ClienteVM Vm)
        {
            var Result = new OperationResult<ClienteDTO>();

            if(Vm.Codigo > 0)
                 Result = await _clienteService.ObtenerClienteByCodigo(Vm.Codigo);

            ValidaCreacionCliente(Result.ResultObject);

            if (ModelState.IsValid)
            {
                var DtoCliente = ConvertVM.ConvertToClienteDto(Vm);
                Result = await _clienteService.GuardarCliente(DtoCliente);
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

        public void ValidaCreacionCliente(ClienteDTO Dto)
        {
            if (Dto != null)
            {
                if (!Dto.Estado)
                    ModelState.AddModelError(nameof(Dto.Estado), "Estimado usuario el cliente que está intentando actualizar se encuentra INACTIVO, favor recargue la página nuevamente para poder activarlo. ");
            }
        }


        // POST: AcivarUsuario
        [HttpPost]
        public async Task<ActionResult> AcivarUsuario(int CodigoActivacion)
        {
   
            var Result = await _clienteService.ActivarUsuario(CodigoActivacion);

            return Json(new
            {
                Result.Success,
                Result.Warning,
                Result.Messages
            }, JsonRequestBehavior.AllowGet);

        }

    }
}
