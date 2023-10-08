using MiBancoService.Domain.Models;
using MiBancoService.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiBanco.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var Vm = new ClienteVM();

            return View("CreateCliente",Vm);
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteVM Vm)
        {

            var result = new OperationResult<ClienteVM>();

            result.Success = true;
            result.Messages.Add("Operacion realizada correctamente.");
            result.ResultObject = null;

            return Json(new
            {
                result.Success,
                result.Warning,
                result.Messages
            }, JsonRequestBehavior.AllowGet);
          
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
