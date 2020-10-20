namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILearningResourceRepository LearningResourceRepository { get; }

        bool Commit();
        void Rollback();
    }
}