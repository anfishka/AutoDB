namespace AutoDB.Models
{
    public class CarColor
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
