using Acredita.API.Data;
using Acredita.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ProjectsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task <IActionResult> GetAsync()
        {
            return Ok(await dataContext.Projects.ToListAsync());
        }
        [HttpPost]

            public async Task<IActionResult> PostAsync(Project project)
        {
            dataContext.Projects.Add(project);
            await dataContext.SaveChangesAsync();
            return Ok(project);
        }
    }
}
