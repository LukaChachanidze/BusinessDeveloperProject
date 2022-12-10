using BusinessToDeveloper.Services.Projects.Dto;

namespace BusinessToDeveloper.Services.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> SearchProjects(string searchTerm);
        Task<ProjectDTO> GetProject(int id);
        Task<ProjectDTO> AddProject(ProjectDTO projectDto);
        Task<bool> UpdateProjectAsync(ProjectDTO projectDto);
        Task<int> DeleteProjectAsync(int id);
        Task<ProjectDTO> AssignDeveloperAsync(int projectId, int developerId);
        Task<ProjectDTO> AssignBusinessAsync(int projectId, int businessId);
    }
}
