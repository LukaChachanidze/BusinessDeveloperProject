using BusinessToDeveloper.Services.Projects;
using BusinessToDeveloper.Services.Projects.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessToDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects(string searchTerm)
        {
            var projects = await _projectService.SearchProjects(searchTerm);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await _projectService.GetProject(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> AddProject(ProjectDTO projectDto)
        {
            var project = await _projectService.AddProject(projectDto);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectDTO projectDto)
        {
            if (id != projectDto.Id)
            {
                return BadRequest();
            }

            var success = await _projectService.UpdateProjectAsync(projectDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{projectId}/assign/{developerId}")]
        public async Task<ActionResult<ProjectDTO>> AssignDeveloper(int projectId, int developerId)
        {
            var project = await _projectService.AssignDeveloperAsync(projectId, developerId);
            return Ok(project);
        }

        [HttpPut("{projectId}/assign/business/{businessId}")]
        public async Task<ActionResult<ProjectDTO>> AssignBusiness(int projectId, int businessId)
        {
            var project = await _projectService.AssignBusinessAsync(projectId, businessId);
            return Ok(project);
        }
    }
}
