using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILearningResourceRepository LearningResourceRepository { get; }
        ILearningResourceSuggestionRepository LearningResourceSuggestionRepository { get; }
        ISkillsRepository SkillsRepository { get; }

        Task<bool> Commit();
        void Rollback();
    }
}