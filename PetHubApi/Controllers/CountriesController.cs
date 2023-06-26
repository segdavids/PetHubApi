using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHubApi.Configurations;
using PetHubApi.Contracts;
using PetHubApi.Data;
using PetHubApi.Dto.Country;

namespace PetHubApi.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(IMapper mapper, ICountryRepository countryRepository)
    {
            this._mapper = mapper;
            this._countryRepository = countryRepository;
        }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {
        
            var countries = await _countryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetCountry(int id)
    {

       
       
            var country = await _countryRepository.GetDetails(id);
            if(country == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<CountryDto>(country);
            return Ok(record);
    }

    [HttpGet("{petid}/countryId/{countryid}")]
    public async Task<ActionResult> GetPetandCountry(int petid, int countryid)
    {
        List<string> petncount = new List<string>();
        //if(_context.Countries==null && _context.Pets==null)
        //{
        //    return NotFound();
        //}
       // var countryandpet = await _ _context.Pets.FindAsync(petid);
        var countryown = await _countryRepository.GetAsync(countryid);
        //petncount.Add(countryandpet);
        return Ok(countryandpet);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, UpdateCountryDto UpdateCountryDto)
    {
        if (id != UpdateCountryDto.id)
        {
            return BadRequest(); 
        }
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound("The country was not found");
            }
            _mapper.Map(UpdateCountryDto,country);
          //   _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _countryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createcountry)
    {
        var country = _mapper.Map<Country>(createcountry);
          
        //if (_context.Countries == null)
        //{
        //    return Problem("Entity set 'PetAPIDBContext.Countries'  is null.");
        //}
        await _countryRepository.AddAsync(country);
        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
            var country = _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await _countryRepository.DeleteAsync(id);// _context.Countries.FindAsync(id);
        //if (country == null)
        //{
        //    return NotFound();
        //}

        //_context.Countries.Remove(country);
        //await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> CountryExists(int id)
    {
       // return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
          var torfalse =  await _countryRepository.Exists(id);
        return torfalse;
    }
}
}
