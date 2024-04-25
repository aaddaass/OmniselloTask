using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OmniselloTask.Models;
using Repository.Interface;

namespace OmniselloTask.Controllers
{
    public class VegetablesController : Controller
    {
        private readonly IVegetables _vegetables;
        public VegetablesController(IVegetables vegetables)
        {
            _vegetables = vegetables;     
        }
        // GET: VegetablesController
        public ActionResult Index()
        {
            return View(_vegetables.GetAllVege());
        }

      

        // GET: VegetablesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VegetablesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vegetables vege)
        {
            if(ModelState.IsValid)
            {
                Vegetables vegetables = new Vegetables()
                {
                    NameVegetables = vege.NameVegetables,
                    VegetablesPrice = vege.VegetablesPrice,
                    VegetablesUnit = vege.VegetablesUnit,
                };
                _vegetables.AddVegetable(vege);
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: VegetablesController/Edit/5
        public ActionResult Edit(int id)
        {
            Vegetables vegetables=_vegetables.GetVegetable(id);
            return View(vegetables);
        }

        // POST: VegetablesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vegetables vegetables)
        {
           if (ModelState.IsValid)
            {
                _vegetables.UpdateVegetable(vegetables);
                return RedirectToAction("Index");
            }
           return View();
        }

        // GET: VegetablesController/Delete/5
        public ActionResult Delete(int id)
        {
            var vege =_vegetables.GetVegetable(id); 
            return View(vege);
        }

        // POST: VegetablesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _vegetables.DeleteVegetable(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
