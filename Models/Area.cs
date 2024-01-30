namespace SelectListDemo.Models
{
	public class Area
	{
		public int AreaId { get; set; }
		public string Name { get; set; } = default!;
		public int CityId { get; set; }

		public Area(int AreaId, string Name, int CityId)
		{
			this.AreaId = AreaId;
			this.Name = Name;
			this.CityId = CityId;
		}
	}
}
