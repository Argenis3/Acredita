using Acredita.API.Data;
using Acredita.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Controllers
{
    public class CitiesController:ControllerBase
    {
        private readonly DataContext dataContext;
        public CitiesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Cities.Include(c=>c.Country).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(City city)
        {
            dataContext.Cities.Add(city);
            await dataContext.SaveChangesAsync();
            return Ok(city);
        }
    }
}
