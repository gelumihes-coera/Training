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
    public class StudentController : Controller
    {
        private readonly IBusinessManagement<StudentBusinessModel> _studentManagement;
        private readonly IBusinessManagement<AddressBusinessModel> _addressManagement;

        public StudentController(IBusinessManagement<StudentBusinessModel> student, IBusinessManagement<AddressBusinessModel> address)
        {
            _studentManagement = student;
            _addressManagement = address;
        }

        // GET: Student
        public ActionResult Index()
        {
            var students = _studentManagement.GetEntities().Select(Mapper.Map<StudentViewModel>).ToList();
            return View("Index", students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
