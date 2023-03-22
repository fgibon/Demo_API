/*
using AutoMapper;
using arfan.Models;
using Microsoft.AspNetCore.Mvc;
using arfan.Models.Dto.Reserve;
using arfan.Repository.IRepository;
using System.Net;

namespace arfan.Controllers
{
    [Route("api/ReserveAPI")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ReserveAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IReserveRepository _dbReserve;
        private readonly IMapper _mapper;

        public ReserveAPIController(IReserveRepository dbReserve, IMapper mapper)
        {
            _dbReserve = dbReserve;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetReserve()
        {
            try
            {
                IEnumerable<Reserve> reserveList = await _dbReserve.GetAllAsync();
                _response.Result = _mapper.Map<List<ReserveDTO>>(reserveList);
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

        [HttpGet("{id:int}", Name = "GetReserve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetReserve(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var reserve = await _dbReserve.GetAsync(u => u.Id == id);

                if (reserve == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ReserveDTO>(reserve);
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
        public async Task<ActionResult<APIResponse>> CreateReserve([FromBody] ReserveCreateDTO createDTO)
        {
            try
            {
                if (await _dbReserve.GetAsync(u => u.Id.ToLower() == createDTO.Id.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "El perfil ingresado ya existe.");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Models.Profile profile = _mapper.Map<Models.Profile>(createDTO);
                await _dbProfile.CreateAsync(profile);
                _response.Result = _mapper.Map<ProfileDTO>(profile);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetProfile", new { id = profile.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteProfile(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var profile = await _dbProfile.GetAsync(u => u.Id == id);

                if (profile == null)
                {
                    return NotFound();
                }

                await _dbProfile.RemoveAsync(profile);
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

        [HttpPut("{id:int}", Name = "UpdateProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateProfile(int id, [FromBody] ProfileUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Models.Profile profile = await _dbProfile.GetAsync(u => u.Id == id);

                profile = _mapper.Map<ProfileUpdateDTO, Models.Profile>(updateDTO, profile);

                await _dbProfile.UpdateAsync(profile);
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

*/