using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.Models;

namespace SOLIDapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBusinessManagement<ProductBusinessModel> _productBl;
        private readonly IBusinessManagement<StorageBusinessModel> _storageBl;
        private readonly IBusinessManagement<IngredientBusinessModel> _ingredientBl;
        private readonly IBusinessManagement<OrderItemBusinessModel> _orderItemBl;
        private readonly IBusinessManagement<OrderBusinessModel> _orderBl; 
         
        public ProductController(IBusinessManagement<ProductBusinessModel> productManagement, IBusinessManagement<StorageBusinessModel> storageManagement, 
            IBusinessManagement<IngredientBusinessModel> ingredientManagement, IBusinessManagement<OrderItemBusinessModel> orderItemManagement, IBusinessManagement<OrderBusinessModel> orderManagement)
        {
            _productBl = productManagement;
            _storageBl = storageManagement;
            _ingredientBl = ingredientManagement;
            _orderItemBl = orderItemManagement;
            _orderBl = orderManagement;
        }

        // GET: Product
        public ActionResult ProductIndex()
        {
            List<ProductViewModel> products = _productBl.GetEntities().Select(Mapper.Map<ProductViewModel>).ToList();
            return View("ProductIndex", products);
        }

        // GET: Product/Details/5
        public ActionResult ProductDetails(int id)
        {
            var product = Mapper.Map<ProductViewModel>(_productBl.GetById(id));
            return View(product);
        }

        // GET: Product/Create
        public ActionResult ProductCreate()
        {
            ProductViewModel product = new ProductViewModel();
            product.AvailableIngredients = _ingredientBl.GetEntities().Select(Mapper.Map<IngredientViewModel>).ToList();
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult ProductCreate(ProductViewModel firstModel, StorageViewModel secondModel)
        {
            try
            {
                var product = new ProductBusinessModel()
                {
                    Name = firstModel.Name,
                    Price = firstModel.Price,
                    StatusCode = firstModel.StatusCode
                };
                _productBl.Add(product);

                var storage = new StorageBusinessModel()
                {
                    ProductId = product.Id,
                    Quantity = secondModel.Quantity
                };
                _storageBl.Add(storage);

                return RedirectToAction("ProductIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Product/Edit/5
        public ActionResult ProductEdit(int id)
        {
            var product = Mapper.Map<ProductViewModel>(_productBl.GetById(id));
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult ProductEdit(int id, ProductViewModel model)
        {
            try
            {
                var product = Mapper.Map<ProductBusinessModel>(model);
                _productBl.Update(product);
                return RedirectToAction("ProductIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Product/Delete/5
        public ActionResult ProductDelete(int id)
        {
            try
            {
                _productBl.Remove(id);
                return RedirectToAction("ProductIndex");
            }
            catch
            {
                return View("Error");
            }
        }

        //public ActionResult ProductOrder(int id)
        //{
        //    try
        //    {
        //        StorageBusinessModel storage = _storageBl.GetById(id);
        //        if (storage.Quantity != 0)
        //        {
        //            OrderItemViewModel orderItem = new OrderItemViewModel()
        //            {
        //                ProductId = id,
        //                OrderId =
        //            };

        //            storage.Quantity--;
        //            _storageBl.Update(storage);
        //        }
        //        return View("ProductIndex");
        //    }
        //    catch
        //    {
        //        return View("Error");
        //    }
        //}
    }
}
