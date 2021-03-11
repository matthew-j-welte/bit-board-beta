using System.Collections.Generic;
using System.Threading.Tasks;
using BitBoard.Business.Views.Learning.Dtos;
using BitBoard.Business.Views.Learning.ViewModels;

namespace BitBoard.Business.Learning.Interfaces
{
    public interface ILearningService
    {
        Task<LearningResourceDto> GetResourceAsync(string id);
        Task<IEnumerable<LearningResourceDto>> GetAllResources();
        Task<IEnumerable<UserResourceStateDto>> GetUserResourceProgressions(string userId);
        Task<LearningResourceModel> GetResourceModelAsync(string learningResourceId, string userId);
        Task<IEnumerable<LearningResourceDto>> GetTopViewedResourcesAsync(int amount);
        Task<LearningResourceModel> UpsertResourceAsync(LearningResourceModel learningResource);
        Task<LearningResourceSuggestionDto> UpsertResourceSuggestionAsync(LearningResourceSuggestionDto resourceSuggestion);
        Task<IEnumerable<SkillDto>> GetAllSkills();
    }
}