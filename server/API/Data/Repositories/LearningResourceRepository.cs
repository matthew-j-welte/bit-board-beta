using System.Collections.Generic;
using System.Linq;
using API.Interfaces;
using API.Models.Entities;

namespace API.Data.Repositories
{
    public class LearningResourceRepository : ILearningResourceRepository
    {
        private readonly DataContext _context;

        public LearningResourceRepository(DataContext context)
        {
            _context = context;
        }

        public void DeletetLearningResource(LearningResource learningResource)
        {
            
        }

        public LearningResource GetLearningResourceById(int learningResourceId)
        {
            return _context.LearningResources.Find(learningResourceId);
        }

        public IEnumerable<LearningResource> GetLearningResources()
        {
            return _context.LearningResources.ToList();
        }

        public void InsertLearningResource(LearningResource learningResource)
        {
            
        }

        public void UpdateLearningResource(LearningResource learningResource)
        {
            
        }
    }
}