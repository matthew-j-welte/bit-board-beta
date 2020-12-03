using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;

namespace API.Interfaces
{
    public interface ILearningResourceSuggestionRepository
    {
        Task<IEnumerable<LearningResourceSuggestionDto>> GetLearningResourceSuggestionsAsync();
        Task<LearningResourceSuggestionDto> GetLearningResourceSuggestionByIdAsync(int learningResourceId);
        Task InsertLearningResourceSuggestionAsync(LearningResourceSuggestionDto learningResource);
        void DeletetLearningSuggestionResourceAsync(LearningResourceSuggestionDto learningResource);
        void UpdateLearningResourceSuggestionAsync(LearningResourceSuggestionDto learningResource);
    }
}