using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SOLIDapp.BusinessLayer;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.Models;

namespace SOLIDapp.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IBusinessManagement<IngredientBusinessModel> _ingredientBl;

        public IngredientController(IBusinessManagement<IngredientBusinessModel> ingredientManagement)
        {
            _ingredientBl = ingredientManagement;
        }

        // GET: Ingredient
        public ActionResult IngredientIndex()
        {
            List<IngredientViewModel> products = _ingredientBl.GetEntities().Select(Mapper.Map<IngredientViewModel>).ToList();
            return View("IngredientIndex", products);
        }

        // GET: Ingredient/Create
        public ActionResult IngredientCreate()
        {
            return View("IngredientCreate");
        }

        // POST: Ingredient/Create
        [HttpPost]
        public ActionResult IngredientCreate(IngredientViewModel model)
        {
            try
            {
                var ingredient = new IngredientBusinessModel()
                {
                    Name = model.Name,
                };
                _ingredientBl.Add(ingredient);
                return RedirectToAction("IngredientIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Ingredient/Edit/5
        public ActionResult IngredientEdit(int id)
        {
            var ingredient = Mapper.Map<IngredientViewModel>(_ingredientBl.GetById(id));
            return View(ingredient);
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        public ActionResult IngredientEdit(int id, IngredientViewModel model)
        {
            try
            {
                var ingredient = Mapper.Map<IngredientBusinessModel>(model);
                _ingredientBl.Update(ingredient);
                return RedirectToAction("IngredientIndex");
            }
            catch
            {
                return View("Error");
            }
        }

      // POST: Ingredient/Delete/5
        public ActionResult IngredientDelete(int id, FormCollection collection)
        {
            try
            {
                _ingredientBl.Remove(id);
                return RedirectToAction("IngredientIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        private List<SelectListItem> GetIngredientsAsSelectList()
        {
            return _ingredientBl.GetEntities().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
    }
}
