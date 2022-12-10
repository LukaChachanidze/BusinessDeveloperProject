using BusinessToDeveloper.Core.Entities;
using BusinessToDeveloper.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BusinessToDeveloper.Services.Projects.Dto;

namespace BusinessToDeveloper.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectDTO>> SearchProjects(string searchTerm)
        {
            var projects = await _unitOfWork.GetRepository<Project>()
                .GetAllAsync();

            if (searchTerm != null)
            {
                projects = projects.Where(p => p.Name.Contains(searchTerm)).ToList();
            }

            return projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                BusinessId = p.BusinessId,
                BusinessName = p.Business.Name,
                DeveloperId = p.DeveloperId,
                DeveloperName = p.Developer.Name
            });
        }

        public async Task<ProjectDTO> GetProject(int id)
        {
            var project = await _unitOfWork.GetRepository<Project>().GetByIdAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                BusinessId = project.BusinessId,
                BusinessName = project.Business.Name,
                DeveloperId = project.DeveloperId,
                DeveloperName = project.Developer.Name
            };
        }

        public async Task<ProjectDTO> AddProject(ProjectDTO projectDto)
        {
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                BusinessId = projectDto.BusinessId,
                DeveloperId = projectDto.DeveloperId
            };

            await _unitOfWork.GetRepository<Project>().AddAsync(project);
            await _unitOfWork.SaveChangesAsync();

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                BusinessId = project.BusinessId,
                BusinessName = project.Business.Name,
                DeveloperId = project.DeveloperId,
                DeveloperName = project.Developer.Name
            };
        }


        public async Task<bool> UpdateProjectAsync(ProjectDTO projectDto)
        {
            var project = await _unitOfWork.GetRepository<Project>().GetByIdAsync(projectDto.Id);
            if (project == null)
            {
                return false;
            }

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<int> DeleteProjectAsync(int id)
        {
            var project = await _unitOfWork.GetRepository<Project>().GetByIdAsync(id);
            if (project == null)
            {
                return 0;
            }

            await _unitOfWork.GetRepository<Project>().DeleteAsync(project);
            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ProjectDTO> AssignDeveloperAsync(int projectId, int developerId)
        {
            var project = await _unitOfWork.GetRepository<Project>().GetByIdAsync(projectId);
            var developer = await _unitOfWork.GetRepository<Developer>().GetByIdAsync(developerId);

            if (project == null || developer == null)
            {
                throw new ArgumentException("Invalid project or developer ID.");
            }

            project.DeveloperId = developer.Id;
            await _unitOfWork.SaveChangesAsync();

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                BusinessId = project.BusinessId,
                DeveloperId = project.DeveloperId,
                BusinessName = project.Business.Name,
                DeveloperName = project.Developer.Name
            };
        }

        public async Task<ProjectDTO> AssignBusinessAsync(int projectId, int businessId)
        {
            var project = await _unitOfWork.GetRepository<Project>().GetByIdAsync(projectId);
            var business = await _unitOfWork.GetRepository<Business>().GetByIdAsync(businessId);

            if (project == null || business == null)
            {
                throw new ArgumentException("Invalid project or business ID.");
            }

            project.BusinessId = business.Id;
            await _unitOfWork.SaveChangesAsync();

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                BusinessId = project.BusinessId,
                DeveloperId = project.DeveloperId,
                BusinessName = project.Business.Name,
                DeveloperName = project.Developer.Name
            };
        }
        // AssignDeveloperAsync AssignBusinessAsync
    }
}
