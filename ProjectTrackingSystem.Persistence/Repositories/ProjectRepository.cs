using Core.Base.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Domain.Entities;
using ProjectTrackingSystem.Persistence.Context;

namespace ProjectTrackingSystem.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectTrackingSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
