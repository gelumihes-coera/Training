using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class OrderItemManagementBl:IBusinessManagement<OrderItemBusinessModel>
    {
        private readonly IRepository _repository;

        public OrderItemManagementBl(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(OrderItemBusinessModel entity)
        {
            var entityDb = Mapper.Map<OrderItem>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object entity)
        {
            _repository.Delete<OrderItem>(entity);
        }

        public void Update(OrderItemBusinessModel entity)
        {
            var entityDb = Mapper.Map<OrderItem>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<OrderItemBusinessModel> GetEntities()
        {
            return _repository.GetEntities<OrderItem>().ToList().Select(Mapper.Map<OrderItemBusinessModel>).ToList();
        }

        public OrderItemBusinessModel GetById(int id)
        {
            return Mapper.Map<OrderItemBusinessModel>(_repository.GetById<OrderItem>(id));
        }
    }
}
