namespace AutoDB.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Car> Cars { get; set; }
     
    }
}
