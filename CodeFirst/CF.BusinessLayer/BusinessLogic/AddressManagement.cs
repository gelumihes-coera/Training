using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CF.BusinessLayer.Models;
using CF.DataAccessLayer.Models;
using CF.DataAccessLayer.Repositories;
using SOLIDapp.BusinessLayer.BusinessLogic;

namespace CF.BusinessLayer.BusinessLogic
{
    public class AddressManagement : IBusinessManagement<AddressBusinessModel>
    {
        private readonly IRepository<Address> _repository;

        public AddressManagement(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public void Add(AddressBusinessModel entity)
        {
            var entityDb = Mapper.Map<Address>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object id)
        {
            _repository.Delete(id);
        }

        public void Update(AddressBusinessModel entity)
        {
            var entityDb = Mapper.Map<Address>(entity);
            _repository.Update(entityDb, entityDb.StudentId);
        }

        public IEnumerable<AddressBusinessModel> GetEntities()
        {
            var list = _repository.GetEntities().ToList();
            return list.Select(Mapper.Map<AddressBusinessModel>).ToList();
        }

        public AddressBusinessModel GetById(int id)
        {
            return Mapper.Map<AddressBusinessModel>(_repository.GetById(id));
        }
    }
}
