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



        public ActionResult Index()
        {
            //var model = _repository.FindAllContacts();
            var model = _repository.GetLastContacts();
            return View(model);
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
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ContactID")]int id)
        {
            try
            {
                var contactToDelete = new Contact { ContactID = id };
                _repository.Delete(contactToDelete);
                _repository.Save();
                TempData["success"] = "The contact has been removed!";
            }
            catch (DataException ex)
            {
                TempData["error"] = String.Format("Failed to remove contact. Try again. {0}", ex.InnerException.InnerException.Message);
                return RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("ContactNotFound");//TODO: gör så att den fugnerar
            }
            return View(contact);

        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (contact == null)
            {
                return View("ContactNotFound");
            }

            if (TryUpdateModel(contact, String.Empty, new string[] { "EmailAddress", "FirstName", "LastName" }))//skyddar mig mot over-posting
            {
                try
                {
                    _repository.Update(contact);
                    _repository.Save();
                    TempData["success"] = "Saved changes.";
                    return RedirectToAction("Index");
                }
                catch (DataException ex)
                {
                    TempData["error"] = String.Format("Failed to edit contact. Try again. {0}", ex.InnerException.InnerException.Message);
                }
            }

            return View(contact);
        }


        
        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}