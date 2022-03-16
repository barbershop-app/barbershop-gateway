using gateway.Core.IServices;
using gateway.Infrastructure.Utils;
using gateway.Web.API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        ILogger<UsersController> _logger;
        IHttpClientService _httpClientService;

        public UsersController(ILogger<UsersController> logger, IHttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }

        [Authorize]
        [HttpGet]
        [Route("IsLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            return Ok("The user is logged in.");
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.USERS_MICROSERVICE_API, "Users", "GetById", id.ToString());
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
