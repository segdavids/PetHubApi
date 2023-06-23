using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHubApi.Configurations;
using PetHubApi.Data;
using PetHubApi.Dto.Country;

namespace PetHubApi.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly PetAPIDBContext _context;
        private readonly IMapper _mapper;

        public CountriesController(PetAPIDBContext context, IMapper mapper)
    {
            _context = context;
            this._mapper = mapper;
        }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {
        
        if (_context.Countries == null)
        {
            return NotFound();
        }
        var countries = await _context.Countries.ToListAsync();
        var records = _mapper.Map<List<GetCountryDto>>(countries);

        return Ok(records);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetCountry(int id)
    {

        if (_context.Countries == null)
        {
            return NotFound("No Table with name Country");
        }
        var country = await _context.Countries.Include(c=>c.Breeds)
                .FirstOrDefaultAsync(c=>c.Id==id);
       
        if (country == null)
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
        if(_context.Countries==null && _context.Pets==null)
        {
            return NotFound();
        }
        var countryandpet = await _context.Pets.FindAsync(petid);
        var countryown = await _context.Countries.FindAsync(countryid);
        //petncount.Add(countryandpet);
        return Ok(countryandpet);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, Country country)
    {
        if (id != country.Id)
        {
            return BadRequest();
        }

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(id))
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
          
        if (_context.Countries == null)
        {
            return Problem("Entity set 'PetAPIDBContext.Countries'  is null.");
        }
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        if (_context.Countries == null)
        {
            return NotFound();
        }
        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CountryExists(int id)
    {
        return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
}
