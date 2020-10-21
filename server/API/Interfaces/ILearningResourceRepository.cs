using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Interfaces
{
    public interface ILearningResourceRepository
    {
         Task<IEnumerable<LearningResourceModel>> GetLearningResourcesAsync();
         Task<LearningResourceModel> GetLearningResourceByIdAsync(int learningResourceId);
         void InsertLearningResourceAsync(LearningResource learningResource);
         void DeletetLearningResource(LearningResource learningResource);
         void UpdateLearningResource(LearningResource learningResource);
    }
}