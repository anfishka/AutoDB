using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace AutoDB.Models
{
    public class Car
    {
            public int CarId { get; set; }
            public string VIN { get; set; } 
            public string LicensePlate { get; set; }
            public int BrandId { get; set; }
            public int ModelId { get; set; }
            public int ColorId { get; set; }
            public int EngineCapacity { get; set; }
            public int Year { get; set; }

          
            public Brand Brand { get; set; }
            public Model Model { get; set; }
            public CarColor Color { get; set; }
           
        }
}
