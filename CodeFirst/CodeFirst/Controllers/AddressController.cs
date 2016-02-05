using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CF.BusinessLayer.Models;
using CodeFirst.Models;
using SOLIDapp.BusinessLayer.BusinessLogic;

namespace CodeFirst.Controllers
{
    public class AddressController : Controller
    {
        private readonly IBusinessManagement<AddressBusinessModel> _addressManagement;
        private readonly IBusinessManagement<StudentBusinessModel> _studentManagement;

        public AddressController(IBusinessManagement<AddressBusinessModel> address, IBusinessManagement<StudentBusinessModel> student)
        {
            _studentManagement = student;
            _addressManagement = address;
        }

        // GET: Address
        public ActionResult Index()
        {
            List<AddressViewModel> addresses = _addressManagement.GetEntities().Select(Mapper.Map<AddressViewModel>).ToList();
            return View("Index", addresses);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            AddressViewModel model = new AddressViewModel
            {
                Students = PopulateOptions()
            };
            return View(model);
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(AddressViewModel model)
        {
            try
            {
                var address = new AddressBusinessModel()
                {
                    StudentId = model.StudentId,
                    Streeet = model.Streeet,
                    City = model.City,
                    County = model.County
                };
                _addressManagement.Add(address);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var address = Mapper.Map<AddressViewModel>(_addressManagement.GetById(id));
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AddressViewModel model)
        {
            try
            {
                var address = Mapper.Map<AddressBusinessModel>(model);
                address.Streeet = model.Streeet;
                address.City = model.City;
                address.County = model.County;
                address.StudentId = id;
                _addressManagement.Update(address);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                _addressManagement.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        private List<SelectListItem> PopulateOptions()
        {
            return _studentManagement.GetEntities().Select(s =>
                    new SelectListItem()
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                    }).ToList();
        }
    }
}
