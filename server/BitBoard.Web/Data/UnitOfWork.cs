using System.Threading.Tasks;
using API.Data.Repositories;
using API.Interfaces;
using API.Interfaces.Repositories;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);
        public ILearningResourceRepository LearningResourceRepository => new LearningResourceRepository(_context, _mapper);
        public ILearningResourceSuggestionRepository LearningResourceSuggestionRepository => new LearningResourceSuggestionRepository(_context, _mapper);
        public ISkillsRepository SkillsRepository => new SkillsRepository(_context, _mapper);

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}