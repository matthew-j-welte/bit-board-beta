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
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            BuildIdentityEntities(builder);
            BuildUserSkillEntities(builder);

        }

        private void BuildIdentityEntities(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }

        private void BuildUserSkillEntities(ModelBuilder builder)
        {
            builder.Entity<UserSkill>()
                .HasKey(x => new { x.UserId, x.SkillId });

            builder.Entity<UserSkill>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSkills)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserSkill>()
                .HasOne(x => x.Skill)
                .WithOne();
        }
    }
}