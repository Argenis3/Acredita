using Acredita.API.Data;
using Acredita.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Controllers
{
    [ApiController]
    [Route("/api/majors")]
    public class MajorsController: ControllerBase
    {
        private readonly DataContext dataContext;
        public MajorsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Majors.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Major major)
        {
            dataContext.Majors.Add(major);
            await dataContext.SaveChangesAsync();
            return Ok(major);
        }

    }
}
