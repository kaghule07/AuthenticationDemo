using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthenticationDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthenticationDemo.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        AdminDAL db = new AdminDAL();
        // GET: ProductWithModelController
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            
            return View(model);
            
        }
        

        // GET: ProductWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var product = db.GetProductById(id);
            return View(product);
        }
  
        // GET: ProductWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Admin ad)
        {
            try
            {
                db.Save(ad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        // GET: ProductWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Admin ad = db.GetProductById(id);
            return View(ad);
        }
        // POST: ProductWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Admin ad)
        {
            try
            {
                db.Update(ad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Admin ad = db.GetProductById(id);
            return View(ad);
        }

        // POST: ProductWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}