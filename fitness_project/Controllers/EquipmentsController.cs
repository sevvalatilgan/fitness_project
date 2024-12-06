using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;

// Generated from Custom Template.

namespace fitness_project.Controllers
{
    public class EquipmentsController : MvcController
    {
        // Service injections:
        private readonly IEquipmentService _equipmentService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public EquipmentsController(
			IEquipmentService equipmentService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _equipmentService = equipmentService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        // GET: Equipments
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _equipmentService.Query().ToList();
            return View(list);
        }

        // GET: Equipments/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _equipmentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Equipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EquipmentModel equipment)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _equipmentService.Create(equipment.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = equipment.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _equipmentService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Equipments/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EquipmentModel equipment)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _equipmentService.Update(equipment.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = equipment.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _equipmentService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Equipments/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _equipmentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
