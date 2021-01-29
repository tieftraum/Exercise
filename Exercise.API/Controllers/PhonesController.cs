using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Domain.CRUD.Phone;
using Exercise.Domain.Interfaces;
using Exercise.Domain.Records;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.API.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PhonesController(IPhoneRepository phoneRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        // GET: api/phones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPhone>>> GetPhones()
        {
            var phones = await _phoneRepository.GetAllPhonesAsync();
            if (!phones.Any())
            {
                return NotFound("phone not found handling error text!");
            }

            var phonesToRead = _mapper.Map<IEnumerable<ReadPhone>>(phones);
            
            return Ok(phonesToRead);
        }

        // GET api/phones/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadPhone>> GetPhone([FromQuery] int id)
        {
            var phone = await _phoneRepository.GetPhoneByIdAsync(id);
            if (phone is null)
            {
                return NotFound("phone not found handling error text!");
            }

            var phoneToRead = _mapper.Map<ReadPhone>(phone);
            return phoneToRead; // encapsulate to OK(); still the same
        }
        
        // POST api/phones
        [HttpPost]
        public async Task<ActionResult<ReadPhone>> CreatePhone([FromBody] CreatePhone createPhone)
        {
            if (createPhone is null)
            {
                return BadRequest("phone is null handling error text!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("phone validation handling error text!");
            }
            var phoneToCreate = _mapper.Map<Phone>(createPhone);
            await _phoneRepository.AddPhoneAsync(phoneToCreate);
            var phoneToRead = _mapper.Map<ReadPhone>(phoneToCreate);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetPhone), new {modeName = phoneToCreate.ModelName}, phoneToRead);
            }
            return BadRequest("phone creating handling error text!");
        }
        
        // PUT api/phones/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhone(int id, UpdatePhone updatePhone)
        {
            var phone = await _phoneRepository.GetPhoneByIdAsync(id);
            if (phone is null)
            {
                return NotFound("phone not found handling error text!");
            }
            _mapper.Map(updatePhone, phone);
            _phoneRepository.UpdatePhone(phone);

            if (await _unitOfWork.SaveChangesAsync())
            {
                return NoContent();
            }
            
            return BadRequest("phone could not be updated handling error text!");
        }
        
        // DELETE api/phones/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            var phone = await _phoneRepository.GetPhoneByIdAsync(id);
            if (phone is null)
            {
                return NotFound("phone not found handling error text!");
            }
            
            _phoneRepository.DeletePhone(phone);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return Ok();
            }
            
            return BadRequest("photo removal error handling text!");
        }
    }
}