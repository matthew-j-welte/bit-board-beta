using System.Linq;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        private ModelBuilder _builder;

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LearningResource> LearningResources { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ErrorReport> ErrorReports { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CodeEditorConfiguration> CodeEditorConfigurations { get; set; }
        public DbSet<UserResourceState> UserResourceStates { get; set; }
        public DbSet<LearningResourceSuggestion> LearningResourceSuggestions { get; set; }
        public DbSet<UserPostRelationship> UserPostRelationships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            _builder = builder;
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                System.Console.WriteLine(entry);
                entry.State = EntityState.Detached;
            }
        }
    }
}