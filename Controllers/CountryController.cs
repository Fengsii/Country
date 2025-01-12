using Country.Models.DB;
using Country.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Country.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryGlobeService _countryGlobeService;

        public CountryController(CountryGlobeService countryGlobeService)
        {
            _countryGlobeService = countryGlobeService;
        }


        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            var itemList = _countryGlobeService.GetListItems();
            return Ok(itemList);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _countryGlobeService.GetItemById(id);

            if (item == null)
            {
                return NotFound("Data Tidak Ditemukan");
            }

            return Ok(item);
        }

        //POST api/<ItemsController>
        [HttpPost]
        public IActionResult Post(CountryGloble countryGloble)
        {
            try
            {
                var dataItem = _countryGlobeService.CreateItems(countryGloble);
                if (dataItem)
                {
                    return Ok("Insert Item Success");
                }

                return BadRequest("Insert Item Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }


        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(CountryGloble countryGloble)
        {
            try
            {
                var dataup = _countryGlobeService.UpdateItems(countryGloble);
                if (dataup)
                {
                    return Ok("Data Berhasil Diupdate");
                }
                return BadRequest("Update data gagal");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _countryGlobeService.DeleteItems(id);
                if (data)
                {
                    return Ok("Data Berhasil Dihapus");
                }

                return NotFound("Data Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message.ToString());
                return BadRequest($"Terjadi Kesalahan : {ex.Message}");
            }
        }
    }
}
