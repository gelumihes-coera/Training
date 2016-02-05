using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.BusinessLayer.Ultils;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer
{
    public class BusinessLayerManagement : IBusinessLayer
    {
        private readonly IRepository _repository;

        public BusinessLayerManagement()
        {
            _repository = new Repository();
            AutoMapperConfiguration.Initialize();
        }

        public void Add<T>(T entity) where T : class
        {
            var entityDb = Mapper.Map<T>(entity);
            _repository.Add(entityDb);
        }

        public void Remove<T>(object id) where T : class
        {
            _repository.Delete<T>(id);
        }

        public void Update<T>(T entity) where T : class, IEntityWithId
        {
            var entityDb = Mapper.Map<T>(entity);
            _repository.Update(entityDb, entityDb.Id);
        }


        public IEnumerable<BaseModel> GetEntities<T>() where T : class
        {
            List<T> list = _repository.GetEntities<T>().ToList();
            var listBV = list.Select(s =>  Mapper.Map<ProductBusinessModel>(s)).ToList();
            return listBV;
        }

        public IEnumerable<ProductBusinessModel> GetProducts()
        {
            return _repository.GetEntities<Product>().ToList().Select(s => Mapper.Map<ProductBusinessModel>(s)).ToList();
        }

        public T GetById<T>(int id) where T : class, IEntityWithId
        {
            return _repository.GetById<T>(id);
        }
    }
}
