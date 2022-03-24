using gateway.Core.IServices;
using gateway.Infrastructure.Entities.DTOs;
using gateway.Infrastructure.Utils;
using gateway.Web.API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gateway.Web.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {

        ILogger<UsersController> _logger;
        IHttpClientService _httpClientService;

        public ManagementController(ILogger<UsersController> logger, IHttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }


        [HttpGet]
        [Route("GetBarberShopDetails/{id}")]
        public async Task<IActionResult> GetBarberShopDetails(int id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Management", "GetBarberShopDetails",id.ToString());


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpPost]
        [Route("GetBookingDayLimit")]
        public async Task<IActionResult> GetBookingDayLimit([FromBody] BarberShopDTOs.GetBookingLimit dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Management", "GetBookingDayLimit", dto);


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpPost]
        [Route("CreateBarberShop")]
        public async Task<IActionResult> CreateBarberShop([FromBody] BarberShopDTOs.Create dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Management", "CreateBarberShop", dto);


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }


        [HttpPost]
        [Route("UpdateBarberShop")]
        public async Task<IActionResult> UpdateBarberShop([FromBody] BarberShopDTOs.Update dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Management", "UpdateBarberShop", dto);


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpGet]
        [Route("GetBarberShopWorkDays/{id}")]
        public async Task<IActionResult> GetBarberShopWorkDays(int id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Management", "GetBarberShopWorkDays", id.ToString());


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }

        }


        [HttpPost]
        [Route("UpdateBarberShopWorkDays")]
        public async Task<IActionResult> UpdateBarberShopWorkDays([FromBody] List<BarberShopWorkDaysDTOs.Update> dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Management", "UpdateBarberShopWorkDays", dto);


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }


        [HttpPost]
        [Route("CreateOwner")]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerDTOs.Create dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Management", "CreateOwner", dto);


                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response.Data);


                return BadRequest(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }



    }
}
