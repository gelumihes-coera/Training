using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class StorageManagementBl : IBusinessManagement<StorageBusinessModel>
    {
        private readonly IRepository _repository;

        public StorageManagementBl(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(StorageBusinessModel entity)
        {
            try
            {
                var entityDb = Mapper.Map<Storage>(entity);
                _repository.Add(entityDb);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(object id)
        {
            _repository.Delete<Customer>(id);
        }

        public void Update(StorageBusinessModel entity)
        {
            var entityDb = Mapper.Map<Storage>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<StorageBusinessModel> GetEntities()
        {
            return _repository.GetEntities<Storage>().ToList().Select(Mapper.Map<StorageBusinessModel>).ToList();
        }

        public StorageBusinessModel GetById(int id)
        {
            return Mapper.Map<StorageBusinessModel>(_repository.GetById<Customer>(id));
        }
    }
}
