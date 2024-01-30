namespace SelectListDemo.Models
{
	public class City
	{
		public int CityId { get; set; }
		public string Name { get; set; } = default!;

        public City(int CityId, string Name)
        {
            this.CityId = CityId;
            this.Name = Name;
        }
    }
}
