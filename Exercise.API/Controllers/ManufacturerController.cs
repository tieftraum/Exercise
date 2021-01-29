using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Domain.CRUD.Manufacturer;
using Exercise.Domain.Interfaces;
using Exercise.Domain.Records;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.API.Controllers
{
    [Route("api/manufacturer")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManufacturerController(IManufacturerRepository manufacturerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        // GET: api/manufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadManufacturer>>> GetManufacturers()
        {
            var manufacturers = await _manufacturerRepository.GetAllManufacturersAsync();
            if (!manufacturers.Any())
            {
                return NotFound("manufacturers not found handling error text!");
            }

            var manufacturersToRead = _mapper.Map<IEnumerable<ReadManufacturer>>(manufacturers);
            
            return Ok(manufacturersToRead);
        }

        // GET api/manufacturer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadManufacturer>> GetManufacturer(int id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            if (manufacturer is null)
            {
                return NotFound("manufacturer not found handling error text!");
            }

            var manufacturerToRead = _mapper.Map<ReadManufacturer>(manufacturer);
            return manufacturerToRead;
        }
        
        // POST api/manufacturer
        [HttpPost]
        public async Task<ActionResult<ReadManufacturer>> CreateManufacturer([FromBody] CreateManufacturer createManufacturer)
        {
            if (createManufacturer is null)
            {
                return BadRequest("manufacturer is null handling error text!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("manufacturer validation handling error text!");
            }
            var manufacturerToCreate = _mapper.Map<Manufacturer>(createManufacturer);
            await _manufacturerRepository.AddManufacturerAsync(manufacturerToCreate);
            var manufacturerToRead = _mapper.Map<ReadManufacturer>(manufacturerToCreate);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetManufacturer), new {id = manufacturerToCreate.Id},
                    manufacturerToRead);
            }
            return BadRequest("manufacturer creating handling error text!");
        }
        
        // PUT api/manufacturer/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateManufacturer(int id, UpdateManufacturer updateManufacturer)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            if (manufacturer is null)
            {
                return NotFound("manufacturer not found handling error text!");
            }
            _mapper.Map(updateManufacturer, manufacturer);
            _manufacturerRepository.UpdateManufacturer(manufacturer);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return NoContent();
            }
            
            return BadRequest("manufacturer could not be updated handling error text!");
        }
        
        // DELETE api/manufacturer/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            if (manufacturer is null)
            {
                return NotFound("manufacturer not found handling error text!");
            }
            
            _manufacturerRepository.DeleteManufacturer(manufacturer);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return Ok();
            }
            
            return BadRequest("manufacturer removal error handling text!");
        }
    }
}