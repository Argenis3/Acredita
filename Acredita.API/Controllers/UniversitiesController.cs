using Acredita.API.Data;
using Acredita.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Controllers
{
    [ApiController]
    [Route("/api/universities")]
    public class UniversitiesController:ControllerBase
    {
        private readonly DataContext dataContext;
        public UniversitiesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        //public IActionResult Get()
        //{
          //  return Ok(dataContext.Universities.ToList());
        //}
        public async Task<IActionResult>GetAsync()
        {
            return Ok(await dataContext.Universities.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Universities.FirstOrDefaultAsync(x=>x.Id==id));
        }
        [HttpPost]
        
        public async Task<IActionResult> PostAsync(University university)
        {
            dataContext.Universities.Add(university);
            await dataContext.SaveChangesAsync();
            return Ok(university);
        }
        [HttpPut]
        public async Task<ActionResult> Put(University university)
        {
            dataContext.Universities.Update(university);
            await dataContext.SaveChangesAsync();
            return Ok(university);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Universities.Where(x=>x.Id == id).ExecuteDeleteAsync();
            if(afectedRows==0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
