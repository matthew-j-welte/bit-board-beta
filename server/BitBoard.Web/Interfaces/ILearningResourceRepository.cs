using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Models.DTOs;

namespace API.Interfaces
{
    public interface ILearningResourceRepository
    {
        Task<IEnumerable<LearningResourceModel>> GetLearningResourceModelsAsync();
        Task<LearningResourceModel> GetLearningResourceModelByIdAsync(int learningResourceId, int userId);
        Task<IEnumerable<LearningResourceDto>> GetLearningResourcesAsync();
        Task<IEnumerable<LearningResourceDto>> GetTopViewedLearningResourcesAsync(int amount);
        Task<LearningResourceDto> GetLearningResourceByIdAsync(int learningResourceId);
        Task<PostDto> UpdateResourcePost(PostDto post, int userId);
        Task<PostDto> NewResourcePost(PostDto post);
        void InsertLearningResourceAsync(LearningResource learningResource);
        void DeletetLearningResource(LearningResource learningResource);
        void UpdateLearningResource(LearningResource learningResource);
    }
}