using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class OrderManagementBl : IBusinessManagement<OrderBusinessModel>
    {
        private readonly IRepository _repository;

        public OrderManagementBl(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(OrderBusinessModel entity)
        {
            var entityDb = Mapper.Map<Order>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object id)
        {
            _repository.Delete<Order>(id);
        }

        public void Update(OrderBusinessModel entity)
        {
            var entityDb = Mapper.Map<Order>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<OrderBusinessModel> GetEntities()
        {
            return _repository.GetEntities<Order>().ToList().Select(Mapper.Map<OrderBusinessModel>).ToList();
        }

        public OrderBusinessModel GetById(int id)
        {
            return Mapper.Map<OrderBusinessModel>(_repository.GetById<Order>(id));
        }
    }
}
