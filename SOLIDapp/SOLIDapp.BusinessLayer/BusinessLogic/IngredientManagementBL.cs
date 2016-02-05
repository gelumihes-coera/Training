using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.DataLayer.Repositories;

namespace SOLIDapp.BusinessLayer.BusinessLogic
{
    public class IngredientManagementBl : IBusinessManagement<IngredientBusinessModel>
    {
        private readonly IRepository _repository;

        public IngredientManagementBl(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(IngredientBusinessModel entity)
        {
            var entityDb = Mapper.Map<Ingredient>(entity);
            _repository.Add(entityDb);
        }

        public void Remove(object id)
        {
            _repository.Delete<Ingredient>(id);
        }

        public void Update(IngredientBusinessModel entity)
        {
            var entityDb = Mapper.Map<Ingredient>(entity);
            _repository.Update(entityDb, entityDb.ID);
        }

        public IEnumerable<IngredientBusinessModel> GetEntities()
        {
            return _repository.GetEntities<Ingredient>().ToList().Select(Mapper.Map<IngredientBusinessModel>).ToList();
        }

        public IngredientBusinessModel GetById(int id)
        {
            return Mapper.Map<IngredientBusinessModel>(_repository.GetById<Ingredient>(id));
        }
    }
}
