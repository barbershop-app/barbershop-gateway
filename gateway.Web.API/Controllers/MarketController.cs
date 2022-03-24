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
    public class MarketController : ControllerBase
    {

        ILogger<UsersController> _logger;
        IHttpClientService _httpClientService;

        public MarketController(ILogger<UsersController> logger, IHttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }


        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {

            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Categories", "GetAllCategories");


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
        [Route("GetCategoryById/{Id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Categories", "GetCategoryById",id.ToString());


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
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTOs.Create dto)
        {

            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Categories", "GetCategoryById", dto);


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
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTOs.Update dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Categories", "UpdateCategory", dto);


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
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var response = await _httpClientService.Delete(Constants.MARKET_MICROSERVICE_API, "Categories", "DeleteCategory", id.ToString());


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
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Products", "GetAllProducts");


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
        [Route("GetAllProductsByCategoryId/{id}")]
        public async Task<IActionResult> GetAllProductsByCategoryId(int id)
        {
            try
            {
                var response = await _httpClientService.Get(Constants.MARKET_MICROSERVICE_API, "Products", "GetAllProductsByCategoryId", id.ToString());


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
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTOs.Create dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Products", "CreateProduct", dto);


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
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTOs.Update dto)
        {
            try
            {
                var response = await _httpClientService.Post(Constants.MARKET_MICROSERVICE_API, "Products", "UpdateProduct", dto);


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
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var response = await _httpClientService.Delete(Constants.MARKET_MICROSERVICE_API, "Products", "DeleteProduct", id.ToString());


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
