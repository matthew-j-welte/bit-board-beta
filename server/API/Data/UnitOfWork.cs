using API.Data.Repositories;
using API.Interfaces;
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

        public ISkillsRepository SkillsRepository => new SkillsRepository(_context, _mapper);

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}