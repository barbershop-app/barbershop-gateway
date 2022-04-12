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
    public class AppointmentsController : ControllerBase
    {
        ILogger<UsersController> _logger;
        IHttpClientService _httpClientService;

        public AppointmentsController(ILogger<UsersController> logger, IHttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }



        [HttpGet]
        [Route("GetBookedAppointment/{Id}")]
        public async Task<IActionResult> GetBookedAppointments(Guid Id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", $"GetBookedAppointment/{Id}");


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
        [Route("GetTodayAppointments")]
        public async Task<IActionResult> GetTodayAppointments()
        {
            try
            {
                var response = await _httpClientService.Get(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", $"GetTodayAppointments");


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
        [Route("AvailableSlots")]
        public async Task<IActionResult> AvailableSlots([FromBody] AppointmentDTOs.AvailableSlots dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", "AvailableSlots", dto);


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
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AppointmentDTOs.Create dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", "Create",dto);


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
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] AppointmentDTOs.Update dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", "Update", dto);


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
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _httpClientService.Delete(Constants.APPOINTMENTS_MICROSERVICE_API, "Appointments", "Delete", id.ToString());


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
