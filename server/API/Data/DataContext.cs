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
                
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            _builder = builder;
        }
    }
}