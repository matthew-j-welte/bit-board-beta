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
        Task<LearningResourceModel> GetLearningResourceModelByIdAsync(int learningResourceId);
        Task<IEnumerable<LearningResourceDto>> GetLearningResourcesAsync();
        Task<LearningResourceDto> GetLearningResourceByIdAsync(int learningResourceId);
        void InsertLearningResourceAsync(LearningResource learningResource);
        void DeletetLearningResource(LearningResource learningResource);
        void UpdateLearningResource(LearningResource learningResource);
    }
}