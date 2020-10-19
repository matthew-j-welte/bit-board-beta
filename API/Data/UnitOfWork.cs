using API.Data.Repositories;
using API.Interfaces;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);
        public ILearningResourceRepository LearningResourceRepository => new LearningResourceRepository(_context);

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