﻿using MiBancoService.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiBanco.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteService _clienteService;

        public HomeController(IClienteService clienteService)
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