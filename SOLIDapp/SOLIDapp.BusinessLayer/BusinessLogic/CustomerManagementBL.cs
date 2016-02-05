using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class CustomerManagementBl : IBusinessManagement<CustomerBusinessModel>
    {
        private readonly IRepository _repository;

        public CustomerManagementBl(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(CustomerBusinessModel entity)
        {
            var entityDb = Mapper.Map<Customer>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object id)
        {
            _repository.Delete<Customer>(id);
        }

        public void Update(CustomerBusinessModel entity)
        {
            var entityDb = Mapper.Map<Customer>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<CustomerBusinessModel> GetEntities()
        {
            return _repository.GetEntities<Customer>().ToList().Select(Mapper.Map<CustomerBusinessModel>).ToList();
        }

        public CustomerBusinessModel GetById(int id)
        {
            return Mapper.Map<CustomerBusinessModel>(_repository.GetById<Customer>(id));
        }
    }
}
