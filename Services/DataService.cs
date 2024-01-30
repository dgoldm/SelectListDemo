using SelectListDemo.Models;

namespace SelectListDemo.Services
{
	public class DataService
	{
        private List<City> cities;
        private List<Area> areas; 

        public DataService()
        {
            cities = new List<City> {
                new City(1, "ירושלים"),
                new City(2, "בני ברק")
            };

            areas = new List<Area> {
                new Area(1, "מרכז", 1),
                new Area(2, "צפון", 1),
                new Area(3, "דרום", 1),
                new Area(4, "מזרח", 1),
                new Area(5, "מערב", 2),
                new Area(6, "מזרח", 2)
            };
        }

		public List<City> GetCities() => cities;
		
        public List<Area> GetAreas(int CityId) => areas.Where(a => a.CityId == CityId).ToList();
    }
}
