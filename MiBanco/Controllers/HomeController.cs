using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiBanco.Controllers
{
    public class HomeController : Controller
    {
        private readonly MiBancoService.Application.Contracts.Services.IClienteService _clienteService;

        public HomeController(MiBancoService.Application.Contracts.Services.IClienteService clienteService)
        {
            _clienteService = clienteService;        
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
    }
}