using Country.Models;
using Country.Models.DB;

namespace Country.Services
{
    public class CountryGlobeService
    {
        private readonly ApplicationContext _context;

        public CountryGlobeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CountryGloble> GetListItems()
        {
            var data = _context.GetCountryGlobles.ToList();
            return data;
        }

        public CountryGloble GetItemById(int id)
        {
            return _context.GetCountryGlobles.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateItems(CountryGloble countryGloble)
        {
            try
            {
                _context.GetCountryGlobles.Add(countryGloble);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool UpdateItems(CountryGloble countryGloble)
        {
            try
            {
                var ItemOld = _context.GetCountryGlobles.Where(x => x.Id == countryGloble.Id).FirstOrDefault();

                if (ItemOld != null)
                {
                    ItemOld.Name = countryGloble.Name;
                    ItemOld.Location = countryGloble.Location;
                    ItemOld.Pupolation = countryGloble.Pupolation;
                    ItemOld.Language = countryGloble.Language;

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch
            {
                throw new Exception("Game tidak ditemukan");
            }
        }

        public bool DeleteItems(int id)
        {
            try
            {
                var dataItem = _context.GetCountryGlobles.FirstOrDefault(x => x.Id == id);
                if (dataItem != null)
                {
                    _context.GetCountryGlobles.Remove(dataItem);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw new Exception("Game tidak ditemukan");
            }

        }
    }
}
