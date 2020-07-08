using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTécnica.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            try
            {
                using (Modelo.DBPruebaEntities1 db = new Modelo.DBPruebaEntities1())
                {
                    var kUSer = (from k in db.USUARIOS
                                 where k.Correo == User.Trim() && k.Contraseña == Password.Trim()
                                 select k).FirstOrDefault();

                    if (kUSer == null)

                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["User"] = kUSer;
                }

                return RedirectToAction("Index", "Home");
            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

            }


        }
    }
}