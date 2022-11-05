using System.Collections.Generic;

namespace CarGallery.Models
{
    public class Brand
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Car> Cars { get; set; }

    }
}
