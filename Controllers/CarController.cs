using CarGallery.Models;
using CarGallery.Repository;
using CarGallery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarGallery.Controllers
{
    public class CarController : Controller
    {
        public CarGalleryDbContext Context { get; set; }
        public CarController(CarGalleryDbContext context)
        {
            this.Context = context;
        }
        public IActionResult List(string? brand)
        {
            List<Car> cars;

            if (string.IsNullOrEmpty(brand))
            {
                cars = this.Context.Cars.ToList();
                brand = "Todos os carros";
            }
            else
            {
                cars = this.Context.Cars.Where(c => c.Brand.Name == brand).ToList();
            }

            return View(new CarListViewModels()
            {
                BrandName = brand,
                Cars = cars
            });
        }
    }
}
