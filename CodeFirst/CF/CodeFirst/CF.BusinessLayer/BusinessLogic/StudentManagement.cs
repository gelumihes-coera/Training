﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CF.BusinessLayer.Models;
using CF.DataAccessLayer.Models;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.DataLayer.Repositories;

namespace CF.BusinessLayer.BusinessLogic
{
    public class StudentManagement : IBusinessManagement<StudentBusinessModel>
    {
        private readonly IRepository<Student> _repository;

        public StudentManagement(IRepository<Student> repository)
        {
            _repository = repository;

        }

        public void Add(StudentBusinessModel entity)
        {
            var entityDb = Mapper.Map<Student>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object id)
        {
            _repository.Delete(id);
        }

        public void Update(StudentBusinessModel entity)
        {
            var entityDb = Mapper.Map<Student>(entity);
            _repository.Update(entityDb, entityDb.Id);
        }

        public IEnumerable<StudentBusinessModel> GetEntities()
        {
            return _repository.GetEntities().ToList().Select(Mapper.Map<StudentBusinessModel>).ToList();
        }

        public StudentBusinessModel GetById(int id)
        {
            return Mapper.Map<StudentBusinessModel>(_repository.GetById(id));
        }
    }
}
