using Acredita.API.Data;
using Acredita.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController:ControllerBase
    {
        private readonly DataContext dataContext;

        public CountriesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Countries.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            dataContext.Countries.Add(country);
            await dataContext.SaveChangesAsync();
            return Ok(country);
        }
    }
}
