using API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private ModelBuilder _builder;

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            _builder = builder;

            BuildIdentityEntities();
            // BuildUserSkillEntities();
            // BuildLearningResourceEntities();

        }

        private void BuildIdentityEntities()
        {
            _builder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            _builder.Entity<Role>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }

        private void BuildUserSkillEntities()
        {
            _builder.Entity<UserSkill>()
                .HasKey(x => new { x.UserId, x.SkillId });

            _builder.Entity<UserSkill>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSkills)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            _builder.Entity<UserSkill>()
                .HasOne(x => x.Skill)
                .WithOne();
        }

        private void BuildLearningResourceEntities()
        {
            _builder.Entity<LearningResource>()
                .HasOne(x => x.Author)
                .WithMany(x => x.PublishedLearningResources)
                .HasForeignKey(x => x.AuthorUserId);
        }
    }
}