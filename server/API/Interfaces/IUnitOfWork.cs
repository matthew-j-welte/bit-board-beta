namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILearningResourceRepository LearningResourceRepository { get; }
        ISkillsRepository SkillsRepository { get; }

        bool Commit();
        void Rollback();
    }
}