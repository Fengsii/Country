using Country.Models;
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


        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customerList = _countryGlobeService.GetListItems();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    Statusdesc = "Sukses",
                    Data = customerList
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var customerList = _countryGlobeService.GetListItems();
                var response = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _countryGlobeService.GetItemById(id);
            if (customer == null)
            {
                return NotFound(); // Mengembalikan status 404 jika pelanggan tidak ditemukan
            }
            return Ok(customer); // Mengembalikan data pelanggan
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CountryGloble countryGloble)
        {
            try
            {
                var InsertCustomer = _countryGlobeService.CreateItems(countryGloble);
                if (InsertCustomer)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        Statusdesc = "Insert Customer Success",
                        Data = null
                    };

                    return Ok(responseSuccess);
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    Statusdesc = "Insert Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(CountryGloble countryGloble)
        {
            try
            {
                var dataUpdate = _countryGlobeService.UpdateItems(countryGloble);
                if (dataUpdate)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        Statusdesc = "Update Customer Success",
                        Data = null
                    };

                    return Ok(responseSuccess);
                    //return Ok("Data Berhasil Diupdate");
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    Statusdesc = "Update Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);

            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _countryGlobeService.DeleteItems(id);
                if (data)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        Statusdesc = "Delete Customer Success",
                        Data = null
                    };

                    return Ok(responseSuccess);
                    //return Ok("Data Berhasil Dihapus");
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    Statusdesc = "Delete Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    Statusdesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }
        }


    }
}
