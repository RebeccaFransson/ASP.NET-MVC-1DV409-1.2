using rf222cz_1_2_aventyrliga_kontakter.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rf222cz_1_2_aventyrliga_kontakter.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository = new Repositroy();//skapar connection till vårt repositroy vida interfacxe

        public ActionResult Index()
        {
            var model = _repository.FindAllContacts();
            return View(model);
        }
    }
}