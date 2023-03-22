using AutoMapper;
using arfan.Models;
using Microsoft.AspNetCore.Mvc;
using arfan.Models.Dto.Employee;
using arfan.Repository.IRepository;
using System.Net;

namespace arfan.Controllers
{
    [Route("api/EmployeeAPI")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class EmployeeAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEmployeeRepository _dbEmployee;
        private readonly IMapper _mapper;

        public EmployeeAPIController(IEmployeeRepository dbEmployee, IMapper mapper)
        {
            _dbEmployee = dbEmployee;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEmployee()
        {
            try
            {
                IEnumerable<Employee> employeeList = await _dbEmployee.GetAllAsync();
                _response.Result = _mapper.Map<List<EmployeeDTO>>(employeeList);
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

        [HttpGet("{id:int}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var employee = await _dbEmployee.GetAsync(u => u.Id == id);

                if (employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<EmployeeDTO>(employee);
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
        public async Task<ActionResult<APIResponse>> CreateEmployee([FromBody] EmployeeCreateDTO createDTO)
        {
            try
            {
                if (await _dbEmployee.GetAsync(u => u.Username.ToLower() == createDTO.Username.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "El empleado ingresado ya existe.");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Employee employee = _mapper.Map<Employee>(createDTO);
                await _dbEmployee.CreateAsync(employee);
                _response.Result = _mapper.Map<EmployeeDTO>(employee);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEmployee", new { id = employee.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var employee = await _dbEmployee.GetAsync(u => u.Id == id);

                if (employee == null)
                {
                    return NotFound();
                }

                await _dbEmployee.RemoveAsync(employee);
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

        [HttpPut("{id:int}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateEmployee(int id, [FromBody] EmployeeUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Employee employee = await _dbEmployee.GetAsync(u => u.Id == id);

                employee = _mapper.Map<EmployeeUpdateDTO, Employee>(updateDTO, employee);

                await _dbEmployee.UpdateAsync(employee);
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
