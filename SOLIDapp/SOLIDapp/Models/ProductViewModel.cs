using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SOLIDapp.BusinessLayer.BusinessModels;

namespace SOLIDapp.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StatusCode { get; set; }
        public int Quantity { get; set; }
        public List<IngredientViewModel> AvailableIngredients { get; set; }
    }
}
