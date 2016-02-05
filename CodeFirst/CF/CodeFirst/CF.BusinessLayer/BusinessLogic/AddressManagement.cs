using System;
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
            return _repository.GetEntities().ToList().Select(Mapper.Map<AddressBusinessModel>).ToList();
        }

        public AddressBusinessModel GetById(int id)
        {
            return Mapper.Map<AddressBusinessModel>(_repository.GetById(id));
        }
    }
}
