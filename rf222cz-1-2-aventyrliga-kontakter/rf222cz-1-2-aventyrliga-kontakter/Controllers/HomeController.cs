using rf222cz_1_2_aventyrliga_kontakter.Models;
using rf222cz_1_2_aventyrliga_kontakter.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rf222cz_1_2_aventyrliga_kontakter.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository = new Repositroy();//skapar connection till vårt repositroy via interface
        //ingen unity därför en till konstrukt
        public HomeController()
        {
            //tom!
        }

        //constructor with instance to a repository
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "ContactID")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(contact);
                    _repository.Save();//något fel på min save
                    TempData["success"] = "Contact is saved.";
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                TempData["error"] = "Failed to add contact. Try again.";
            }

            return View(contact);
        }

        public ActionResult Delete(int id = 0)
        {
            throw new NotImplementedException();
        }
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int id = 0)
        {
            throw new NotImplementedException();
        }
        public ActionResult Edit(Contact contact)
        {
            throw new NotImplementedException();
        }


        public ActionResult Index()
        {
            var model = _repository.FindAllContacts();
            //var model = _repository.GetLastContacts();
            return View(model);
        }
    }
}