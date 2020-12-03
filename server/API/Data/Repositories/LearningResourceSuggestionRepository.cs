using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Interfaces;
using API.Models.DTOs;
using AutoMapper;

namespace API.Data.Repositories
{
    public class LearningResourceSuggestionRepository : ILearningResourceSuggestionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LearningResourceSuggestionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void DeletetLearningSuggestionResourceAsync(LearningResourceSuggestionDto learningResource)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LearningResourceSuggestionDto> GetLearningResourceSuggestionByIdAsync(int learningResourceId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<LearningResourceSuggestionDto>> GetLearningResourceSuggestionsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertLearningResourceSuggestionAsync(LearningResourceSuggestionDto learningResource)
        {
            var resourceSuggestion = _mapper.Map<LearningResourceSuggestionDto, LearningResourceSuggestion>(learningResource);
            await _context.LearningResourceSuggestions.AddAsync(resourceSuggestion);
            await _context.SaveChangesAsync();
            
        }

        public void UpdateLearningResourceSuggestionAsync(LearningResourceSuggestionDto learningResource)
        {
            throw new System.NotImplementedException();
        }
    }
}