using AutoMapper;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Models.Queries;
using BugTracking.API.Resources;

namespace BugTracking.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
      public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<Bug, BugResource>();

            CreateMap<QueryResult<User>, QueryResultResource<UserResource>>();
            CreateMap<QueryResult<Project>, QueryResultResource<ProjectResource>>();
            CreateMap<QueryResult<Bug>, QueryResultResource<BugResource>>();
        }  
    }
}