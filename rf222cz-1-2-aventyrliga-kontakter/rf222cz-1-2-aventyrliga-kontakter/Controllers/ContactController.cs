using rf222cz_1_2_aventyrliga_kontakter.Models;
using rf222cz_1_2_aventyrliga_kontakter.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rf222cz_1_2_aventyrliga_kontakter.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;//skapar connection till vårt repositroy via interface
        
        //constructor with instance to a repository
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
        public ActionResult Create(Contact contact)
        {
            throw new NotImplementedException();
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
            return View(model);
        }
    }
}