using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class ProductManagementBl : IBusinessManagement<ProductBusinessModel>
    {
        private readonly IRepository _repository;

        public ProductManagementBl(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(ProductBusinessModel entity)
        {
            var entityDb = Mapper.Map<Product>(entity);
            _repository.Add(entityDb);
            entity.Id = entityDb.ID;
        }

        public void Remove(object id)
        {
            _repository.Delete<Product>(id);
        }

        public void Update(ProductBusinessModel entity)
        {
            var entityDb = Mapper.Map<Product>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<ProductBusinessModel> GetEntities()
        {
            return _repository.GetEntities<Product>().ToList().Select(Mapper.Map<ProductBusinessModel>).ToList();
        }

        public ProductBusinessModel GetById(int id)
        {
            return Mapper.Map<ProductBusinessModel>(_repository.GetById<Product>(id));
        }

    }
}
