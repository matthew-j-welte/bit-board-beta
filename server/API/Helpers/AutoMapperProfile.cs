using System.Collections.Generic;
using System.Linq;
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
            CreateMap<User, UserDto>();
            CreateMap<User, UserModel>();
            CreateMap<User, LoginDto>();
            CreateMap<LearningResourceSkill, SkillDto>();
            CreateMap<LearningResource, LearningResourceDto>().ForMember(
                    dest => dest.Skills,
                    opt => opt.MapFrom(src => src.LearningResourceSkills.Select(y => y.Skill)));
            CreateMap<LearningResource, LearningResourceModel>()
                .ForMember(
                    dest => dest.Skills,
                    opt => opt.MapFrom(src => src.LearningResourceSkills.Select(y => y.Skill)));
            CreateMap<LearningResourceSuggestion, LearningResourceSuggestionDto>().ForMember(
                    dest => dest.Skills,
                    opt => opt.MapFrom(src => src.LearningResourceSuggestionSkills.Select(y => y.Skill)));
            CreateMap<LearningResourceSuggestionDto, LearningResourceSuggestion>().ForMember(
                    dest => dest.LearningResourceSuggestionSkills,
                    opt => opt.MapFrom(src => src.Skills.Select(y => new LearningResourceSuggestionSkill {SkillId=y.SkillId})));
            CreateMap<Skill, SkillDto>();
            CreateMap<UserSkill, UserSkillDto>();
            CreateMap<CodeEditorConfiguration, CodeEditorConfigurationDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Comment, PostCommentDto>();
            CreateMap<UserResourceState, UserResourceStateDto>();
            CreateMap<User, UserResourceStateDto>();
            CreateMap<RegistrationDto, User>();
        }
    }
}