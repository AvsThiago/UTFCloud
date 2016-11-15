using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTFCloud.Controllers
{
    public class ArquivosController : Controller
    {
        // GET: Arquivos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Arquivos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Arquivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arquivos/Create
        [HttpPost]
        public ActionResult Create(Arquivos arquivo, HttpPostedFileBase logotipo = null)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Arquivos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Arquivos/Edit/5
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

        // GET: Arquivos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Arquivos/Delete/5
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
