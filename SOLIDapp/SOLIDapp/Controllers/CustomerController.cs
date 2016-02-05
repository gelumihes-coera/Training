using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SOLIDapp.BusinessLayer;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.Models;

namespace SOLIDapp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IBusinessManagement<CustomerBusinessModel> _customerBl;// = new CustomerManagementBl();

        public CustomerController(IBusinessManagement<CustomerBusinessModel> customerManagement)
        {
            _customerBl = customerManagement;
        }

        // GET: Customer
        public ActionResult CustomerIndex()
        {
            List<CustomerViewModel> customers = _customerBl.GetEntities().Select(Mapper.Map<CustomerViewModel>).ToList();
            return View("CustomerIndex", customers);
        }

        // GET: Customer/Create
        public ActionResult CustomerCreate()
        {
            return View("CustomerCreate");
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CustomerCreate(CustomerViewModel model)
        {
            try
            {
                var customer = Mapper.Map<CustomerBusinessModel>(model);
                _customerBl.Add(customer);
                return RedirectToAction("CustomerIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult CustomerEdit(int id)
        {
            var customer = Mapper.Map<CustomerViewModel>(_customerBl.GetById(id));
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult CustomerEdit(int id, CustomerViewModel model)
        {
            try
            {
                var customer = Mapper.Map<CustomerBusinessModel>(model);
                _customerBl.Update(customer);
                return RedirectToAction("CustomerIndex");
            }
            catch
            {
                return View("Error");
            }
        }


        // POST: Customer/Delete/5
        public ActionResult CustomerDelete(int id, CustomerViewModel model)
        {
            try
            {
                _customerBl.Remove(id);
                return RedirectToAction("CustomerIndex");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
