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

        public ClienteController(IClienteService clienteService) 
        {
            _clienteService = clienteService;
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
                       }

            }, JsonRequestBehavior.AllowGet);
        }

        private static ClienteDTO GetParameterSearch(ClienteVM Vm)
        {
            var vistaAlmacen = new ClienteDTO
            {
                start = MiBancoService.Domain.Utility.Utils.CalculaNumeroPagina(int.Parse(Vm.start), Vm.length).ToString()
               ,length = Vm.length
               ,Nombre = Vm.Nombre
            };
            return vistaAlmacen;
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        [HttpGet]
        public async Task<ActionResult> Create(int Codigo = 0)
        {
            var Vm = new ClienteVM();

            if (Codigo > 0)
            {
                var Result = await _clienteService.ObtenerClienteByCodigo(Codigo);
                Vm = ConvertToClienteVm(Result.ResultObject);
            }
            
            return View("CreateCliente",Vm);
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(ClienteVM Vm)
        {
            
            var DtoCliente = ConvertToClienteDto(Vm);

              var Result = await _clienteService.GuardarCliente(DtoCliente);

            return Json(new
            {
                Result.Success,
                Result.Warning,
                Result.Messages
            }, JsonRequestBehavior.AllowGet);
          
        }

        public ClienteVM ConvertToClienteVm(ClienteDTO Vm)
        {
            return new ClienteVM
            {
                Codigo = Vm.Codigo,
                Nombre = Vm.Nombre,
                Apellido = Vm.Apellido,
                Ocupacion = Vm.Ocupacion,
                NumeroContacto = Vm.NumeroContacto             
            };        
        }

        public ClienteDTO ConvertToClienteDto(ClienteVM Vm)
        {
            return new ClienteDTO
            {
                Codigo = Vm.Codigo,
                Nombre = Vm.Nombre,
                Apellido = Vm.Apellido,
                Ocupacion = Vm.Ocupacion,
                NumeroContacto = Vm.NumeroContacto
            };
        }



        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
