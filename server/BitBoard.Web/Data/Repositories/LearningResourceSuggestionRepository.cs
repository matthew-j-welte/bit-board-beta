using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Interfaces.Repositories;
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

        public Task RemoveAsync(LearningResourceSuggestionDto resource)
        {
            throw new System.NotImplementedException();
        }

        public Task<LearningResourceSuggestionDto> GetAsync(int learningResourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<LearningResourceSuggestionDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<LearningResourceSuggestionDto> AddAsync(LearningResourceSuggestionDto learningResource)
        {
            var resourceSuggestion = _mapper.Map<LearningResourceSuggestionDto, LearningResourceSuggestion>(learningResource);
            await _context.LearningResourceSuggestions.AddAsync(resourceSuggestion);
            return _mapper.Map<LearningResourceSuggestion, LearningResourceSuggestionDto>(resourceSuggestion);
            
        }

        public async Task UpdateAsync(LearningResourceSuggestionDto learningResource)
        {
            throw new System.NotImplementedException();
        }
    }
}