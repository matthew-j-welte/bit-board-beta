using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Models.DTOs;
using AutoMapper;
using BitBoard.Web.Interfaces.Base;
using BitBoard.Web.Interfaces.Services;

namespace BitBoard.Business.Learning.Services
{
    public class LearningService : ILearningService
    {
        IBaseRepository<User> userRepository;
        IBaseRepository<LearningResource> resourceRepository;
        IBaseRepository<LearningResourceSuggestion> resourceSuggestionRepository;
        IBaseRepository<Skill> skillRepository;
        IMapper mapper;

        public LearningService(
            IBaseRepository<User> userRepository,
            IBaseRepository<LearningResource> resourceRepository,
            IBaseRepository<LearningResourceSuggestion> resourceSuggestionRepository,
            IBaseRepository<Skill> skillRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.resourceRepository = resourceRepository;
            this.resourceSuggestionRepository = resourceSuggestionRepository;
            this.skillRepository = skillRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LearningResourceDto>> GetAllResources()
        {
            return mapper.Map<IEnumerable<LearningResourceDto>>(await resourceRepository.GetAllAsync());
        }

        public async Task<LearningResourceDto> GetResourceAsync(string id)
        {
            return mapper.Map<LearningResourceDto>(await resourceRepository.GetAsync(id));
        }

        public async Task<LearningResourceModel> GetResourceModelAsync(string learningResourceId, string userId)
        {
            var model = mapper.Map<LearningResourceModel>(await resourceRepository.GetAsync(learningResourceId));
            // Populate the rest of the models data
            // Maybe this should go in user ? or should user be renamed to dashboard or something
            return model;
        }

        public async Task<IEnumerable<UserResourceStateDto>> GetUserResourceProgressions(string userId)
        {
            var user = await userRepository.GetAsync(userId);
            var resourceIds = user.UserResourceProgressions.Select(x => x.LearningResourceId);
            var resources = mapper.Map<IEnumerable<LearningResourceDto>>(await resourceRepository.GetMultipleAsync(resourceIds));
            return resources.Select(x => new UserResourceStateDto
            {
                LearningResource = x,
                User = mapper.Map<UserDto>(user),
                ProgressPercent = user.UserResourceProgressions.Where(y => y.LearningResourceId == x.LearningResourceId).Select(y => y.ProgressPercent).Single()
            });
        }

        public async Task<IEnumerable<LearningResourceDto>> GetTopViewedResourcesAsync(int amount)
        {
            return (await GetAllResources()).OrderByDescending(x => x.Viewers).Take(amount);
        }

        public async Task<LearningResourceModel> UpsertResourceAsync(LearningResourceModel learningResource)
        {
            return mapper.Map<LearningResourceModel>(await resourceRepository.UpsertAsync(mapper.Map<LearningResource>(learningResource)));
        }

        public async Task<LearningResourceSuggestionDto> UpsertResourceSuggestionAsync(LearningResourceSuggestionDto resourceSuggestion)
        {
            return mapper.Map<LearningResourceSuggestionDto>(await resourceSuggestionRepository.UpsertAsync(mapper.Map<LearningResourceSuggestion>(resourceSuggestion)));
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            return mapper.Map<IEnumerable<SkillDto>>(await skillRepository.GetAllAsync());
        }
    }
}