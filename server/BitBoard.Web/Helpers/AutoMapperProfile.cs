using API.Data.Entities;
using API.Models;
using API.Models.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<LearningResource, LearningResourceDto>().ReverseMap();
            CreateMap<LearningResource, LearningResourceModel>().ReverseMap();
            CreateMap<LearningResourceDto, LearningResourceModel>().ReverseMap();
            CreateMap<LearningResourceSuggestion, LearningResourceSuggestionDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<CodeEditorConfiguration, CodeEditorConfigurationDto>().ReverseMap();


            CreateMap<UserSkill, UserSkillDto>().ReverseMap();
            CreateMap<Comment, PostCommentDto>()
                .ForMember(x => x.Post, options => options.MapFrom(x => new PostDto { PostId = x.ParentPost.PostId, Title = x.ParentPost.Title }))
                .ReverseMap();
            CreateMap<UserResourceState, UserResourceStateDto>().ReverseMap();
            CreateMap<User, UserResourceStateDto>().ReverseMap();
            CreateMap<UserEditorConfiguration, CodeEditorConfiguration>().ReverseMap();
            CreateMap<UserPost, PostDto>().ReverseMap();
            CreateMap<UserComment, PostCommentDto>().ReverseMap();
            CreateMap<UserLearningResource, LearningResource>().ReverseMap();
            CreateMap<PostLearningResource, LearningResourceDto>().ReverseMap();
            CreateMap<PostLearningResource, PostLearningResourceDto>().ReverseMap();
            CreateMap<LearningResource, PostLearningResourceDto>().ReverseMap();
        }
    }
}