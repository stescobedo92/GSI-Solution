using AutoMapper;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Models.Queries;
using BugTracking.API.Resources;

namespace BugTracking.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveProjectResource, Project>();
            CreateMap<SaveBugResource, Bug>();
            CreateMap<UserQueryResource, UserQuery>();
            CreateMap<ProjectQueryResource, ProjectQuery>();
            CreateMap<BugQueryResource, BugQuery>();
        }
    }
}