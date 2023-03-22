using AutoMapper;
using arfan.Models;
using Microsoft.AspNetCore.Mvc;
using arfan.Models.Dto.Service;
using arfan.Repository.IRepository;
using System.Net;

namespace arfan.Controllers
{
    [Route("api/ServiceAPI")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ServiceAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IServiceRepository _dbService;
        private readonly IMapper _mapper;

        public ServiceAPIController(IServiceRepository dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetService()
        {
            try
            {
                IEnumerable<Service> serviceList = await _dbService.GetAllAsync();
                _response.Result = _mapper.Map<List<ServiceDTO>>(serviceList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetService(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var service = await _dbService.GetAsync(u => u.Id == id);

                if (service == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ServiceDTO>(service);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateService([FromBody] ServiceCreateDTO createDTO)
        {
            try
            {
                if (await _dbService.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "El servicio ingresado ya existe.");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Service service = _mapper.Map<Service>(createDTO);
                await _dbService.CreateAsync(service);
                _response.Result = _mapper.Map<ServiceDTO>(service);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetService", new { id = service.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteService(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var service = await _dbService.GetAsync(u => u.Id == id);

                if (service == null)
                {
                    return NotFound();
                }

                await _dbService.RemoveAsync(service);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateService(int id, [FromBody] ServiceUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Service service = await _dbService.GetAsync(u => u.Id == id);

                service = _mapper.Map<ServiceUpdateDTO, Service>(updateDTO, service);

                await _dbService.UpdateAsync(service);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}