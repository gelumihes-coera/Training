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
            foreach (var student in students)
            {
                var address = _addressManagement.GetById(student.Id);
                if (address != null)
                    student.Address = $"{address.Streeet}, {address.City}, {address.County}";
            }

            return View("Index", students);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel model, AddressBusinessModel addressModel)
        {
            try
            {
                StudentBusinessModel student = new StudentBusinessModel()
                {
                    Name = model.Name,
                    BirthDate = model.BirthDate,
                    Height = model.Height,
                    Weight = model.Weight
                };
                _studentManagement.Add(student);

                AddressBusinessModel address = new AddressBusinessModel()
                {
                    StudentId = student.Id,
                    Streeet = addressModel.Streeet,
                    City = addressModel.City,
                    County = addressModel.County,
                    StudentName = model.Name
                };

                _addressManagement.Add(address);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = Mapper.Map<StudentViewModel>(_studentManagement.GetById(id));
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModel model)
        {
            try
            {
                var student = Mapper.Map<StudentBusinessModel>(model);
                student.Name = model.Name;
                student.BirthDate = model.BirthDate;
                student.Height = model.Height;
                student.Weight = model.Weight;
                student.Id = id;
                _studentManagement.Update(student);

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
                _studentManagement.Remove(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
    }
}
