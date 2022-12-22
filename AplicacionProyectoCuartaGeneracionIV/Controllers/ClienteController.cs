using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionProyectoCuartaGeneracionIV.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpPost]
        public ActionResult Insert(ClienteBO dto)
        {
            NegocioCliente obj = new NegocioCliente();
            obj.Insertar(dto);
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Update(ClienteBO dto)
        {
            NegocioCliente obj = new NegocioCliente();
            obj.Actualizar(dto);
            return RedirectToAction("List");
        }
        public ActionResult Delete(string USER_ID)
        {
            NegocioCliente obj = new NegocioCliente();
            obj.Eliminar(USER_ID);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            NegocioCliente obj = new NegocioCliente();
            return View(obj.Listar());
        }

        [HttpGet]
        public ActionResult Update(string USER_ID)
        {
            NegocioCliente obj = new NegocioCliente();
            ClienteBO dto = obj.Listar().FirstOrDefault(a => a.USER_ID == USER_ID);
            return View("Update", dto);
        }

        public ActionResult Insert()
        {
            return View("Insert", new ClienteBO());
        }



    }
}