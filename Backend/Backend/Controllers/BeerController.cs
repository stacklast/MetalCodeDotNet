using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        private IValidator<BeerInsertDto> _beerInsertDtoValidator;
        private IValidator<BeerUpdateDto> _beerUpdateDtoValidator;
        private IBeerService _beerService;

        public BeerController(StoreContext context,
            IValidator<BeerInsertDto> beerInsertDtoValidator,
            IValidator<BeerUpdateDto> beerUpdateDtoValidator,
            IBeerService beerService)
        {
            _context = context;
            _beerInsertDtoValidator = beerInsertDtoValidator;
            _beerUpdateDtoValidator = beerUpdateDtoValidator;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
            await _beerService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beerDto = await _beerService.GetById(id);

            return beerDto == null ? NotFound() : Ok(beerDto);
        }

        [HttpPost]
         public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
         {
            var validationResult = await _beerInsertDtoValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beerDto = await _beerService.Add(beerInsertDto);

            return CreatedAtAction(
                nameof(GetById),  
                new { id = beerDto.Id }, 
                beerDto
            );
         }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var validationResult = await _beerUpdateDtoValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beerDto = await _beerService.Update(id, beerUpdateDto);

            return beerDto == null ? NotFound() : Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID,
            };

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok(beerDto);
        }

    }
}
