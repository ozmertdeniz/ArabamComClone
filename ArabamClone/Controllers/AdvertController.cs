using ArabamClone.Model;
using ArabamClone.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArabamClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertRepository advertRepository;
        public AdvertController(IAdvertRepository advertRepository)
        {
            this.advertRepository = advertRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All(int? categoryId, decimal? price, string? gear, string? fuel, int? page)
        {
            try
            {
                List<Advert> adverts = await this.advertRepository.GetAdverts(categoryId, price, gear, fuel, page);
                if (adverts != null)
                {
                    var response = new
                    {
                        total = adverts.Count,
                        adverts
                    };

                    return Ok(response);
                }

                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Advert advert = await this.advertRepository.GetById(id);
                if (advert != null)
                    return Ok(advert);
                else
                    return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("/Advert/Visit")]
        public async Task<IActionResult> Visit([FromBody] int advertId)
        {
            try
            {
                if (advertId != 0)
                {
                    string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

                    bool isInsert = await advertRepository.AddVisit(advertId, ipAddress);

                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
