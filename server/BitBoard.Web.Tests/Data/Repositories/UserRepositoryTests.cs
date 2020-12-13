using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Microsoft.Data.Sqlite;
using API.Data.Repositories;
using API.Models.DTOs;
using API.Data.Entities;
using System;
using API.Data.Seeding;
using System.Linq;
using System.IO;

namespace BitBoard.Web.Tests.Data.Repositories
{
    public static class DataContextFactory
    {
        public static DataContext GetDataContext()
        {
            var connection = new SqliteConnection("Data source=unit-testing.db");
            connection.Open();
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite(connection)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options;

            return new DataContext(dbContextOptions);
        }

        public static UserRepository GetUserRepository(DataContext ctx)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            return new UserRepository(ctx, mapper);
        }
    }

    public class DatabaseFixture : IDisposable
    {
        private readonly string _testDb = Path.Join(Directory.GetCurrentDirectory(), "unit-testing.db");
        public DatabaseFixture()
        {
            if (File.Exists(_testDb))
            {
                File.Delete(_testDb);
            }

            var ctx = DataContextFactory.GetDataContext();
            ctx.Database.Migrate();

            var dataQuery = new DataQuery();
            dataQuery.GenerateDataAsync().Wait();

            Console.WriteLine("Seeding Data!!");

            Seed.SeedSkills(ctx).Wait();
            Seed.SeedUsers(ctx).Wait();
            Seed.SeedLearningResources(ctx).Wait();
            Seed.SeedUserProgressions(ctx).Wait();
            Seed.SeedPosts(ctx).Wait();
            Seed.SeedComments(ctx).Wait();
            Console.WriteLine("Finished Seeding Data");
        }

        public void Dispose()
        {
            Console.WriteLine("Delete the db file!!!");
            Console.WriteLine(Directory.GetCurrentDirectory());
            var testDb = Path.Join(Directory.GetCurrentDirectory(), "unit-testing.db");
            File.Delete(testDb);
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Database collection")]
    public class UserRepositoryTests
    {
        private DataContext _ctx
        {
            get
            {
                return DataContextFactory.GetDataContext();
            }
        }

        private UserDto ValidUserDto()
        {
            var g = Guid.NewGuid().ToString();
            return new UserDto()
            {
                UserName = "mw" + g,
                Password = "P" + g,
                FirstName = "M" + g,
                LastName = "W" + g
            };
        }

        private User ValidUser()
        {
            var g = Guid.NewGuid().ToString();
            return new User()
            {
                UserName = "mw" + g,
                Password = "P" + g,
                FirstName = "M" + g,
                LastName = "W" + g
            };
        }

        [Fact]
        public async Task AddAsync_ValidUser_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetUserRepository(ctx);
                var user = ValidUserDto();
                await repo.AddAsync(user);

                // Act
                await ctx.SaveChangesAsync();
                var createdUser = await ctx.Users.Where(u => u.UserName == user.UserName).SingleOrDefaultAsync();

                // Assert
                Assert.NotNull(createdUser);
                Assert.NotNull(createdUser.UserId);
            }
        }

        [Fact]
        public async Task GetAsync_ValidUserByUsername_Success()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(_ctx);
                var user = ValidUserDto();
                await repo.AddAsync(user);

                // Act
                await ctx.SaveChangesAsync();
                var createdUser = await repo.GetAsync(user.UserName);

                // Assert
                Assert.NotNull(createdUser);
                Assert.NotNull(createdUser.UserId);
            }
        }

        [Fact]
        public async Task GetAsync_NonExistentUsername_ThrowError()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetUserRepository(ctx);
                var user = ValidUser();
                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();

                // Act
                Task invalidUserReq() => repo.GetAsync(user.UserName + "WRONG");

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
            }

        }

        [Fact]
        public async Task GetAsync_ValidUserById_Success()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                // Arrange
                var user = ValidUser();
                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();

                // Act
                var userDto = await repo.GetAsync(user.UserId);

                // Assert
                Assert.Equal(user.UserName, userDto.UserName);
                Assert.Equal(user.Password, userDto.Password);
                Assert.Equal(user.FirstName, userDto.FirstName);
                Assert.Equal(user.LastName, userDto.LastName);
            }
        }

        [Fact]
        public async Task GetAsync_NonExistentId_ThrowError()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                // Arrange
                var user = ValidUser();
                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();

                // Act
                Task invalidUserReq() => repo.GetAsync(user.UserId + 1);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
            }
        }

        [Fact]
        public async Task GetAllAsync_ValidUsers_Success()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                // Arrange
                var user1 = ValidUser();
                var user2 = ValidUser();
                await ctx.Users.AddRangeAsync(new User[] { user1, user2 });
                await ctx.SaveChangesAsync();

                // Act
                var userDtos = await repo.GetAllAsync();

                // Assert
                foreach (var userDto in userDtos)
                {
                    if (userDto.UserId == user1.UserId)
                    {
                        Assert.Equal(user1.UserName, userDto.UserName);
                        Assert.Equal(user1.Password, userDto.Password);
                        Assert.Equal(user1.FirstName, userDto.FirstName);
                        Assert.Equal(user1.LastName, userDto.LastName);
                    }
                    else if (userDto.UserId == user2.UserId)
                    {
                        Assert.Equal(user2.UserName, userDto.UserName);
                        Assert.Equal(user2.Password, userDto.Password);
                        Assert.Equal(user2.FirstName, userDto.FirstName);
                        Assert.Equal(user2.LastName, userDto.LastName);
                    }
                }
            }
        }

        [Fact]
        public async Task Remove_ExistingUser_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetUserRepository(ctx);
                var originalCount = await ctx.Users.CountAsync();
                await repo.RemoveAsync(new UserDto { UserId = 1 });

                // Act
                var count = await ctx.Users.CountAsync();

                // Assert
                Assert.Equal(originalCount - 1, count);
            }
        }

        [Fact]
        public async Task Remove_NonExistentUser_ThrowError()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                // Arrange
                var user = ValidUserDto();
                var fakeUser = ValidUserDto();
                await repo.AddAsync(user);
                await ctx.SaveChangesAsync();

                // Act
                Task invalidRemoveReq() => repo.RemoveAsync(fakeUser);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidRemoveReq);
            }
        }

        [Fact]
        public async Task Update_ExistingUser_SuccessAsync()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                var user = new UserDto 
                { 
                    UserId = 1, 
                    UserName = "NewUser", 
                    FirstName = "New", 
                    LastName = "User" 
                };
                await repo.UpdateAsync(user);
            }
            
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetUserRepository(ctx);
                var updatedUser = await ctx.Users.Where(u => u.UserId == 1).SingleOrDefaultAsync();
                Assert.Equal("NewUser", updatedUser.UserName);
                Assert.Equal("New", updatedUser.FirstName);
                Assert.Equal("User", updatedUser.LastName);
            }
        }

        [Fact]
        public async Task Update_NonExistentUser_ThrowError()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetUserRepository(ctx);
                var user = ValidUserDto();
                var fakeUser = ValidUserDto();
                await repo.AddAsync(user);
                await ctx.SaveChangesAsync();

                // Act
                Task invalidUpdateReq() => repo.UpdateAsync(fakeUser);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidUpdateReq);
            }
        }

        [Fact]
        public async Task GetProgressionAsync_UserWithProgressions_Success()
        {
            // // Arrange
            // var user = ValidUser();


            // var userSkill = new UserSkill();
            // userSkill.Level = 5;
            // userSkill.ProgressPercent = 40;
            // userSkill.SkillId = 1;
            // userSkill.UserId = 1;

            // var userResourceState = new UserResourceState();
            // userResourceState.LearningResourceId = 1;
            // userResourceState.ProgressPercent = 40;
            // userResourceState.UserId = 1;

            // user.UserSkills = new List<UserSkill>() { userSkill };
            // user.UserResourceStates = new List<UserResourceState>() { userResourceState };

            // _dbContext.Users.Add(user);
            // await _dbContext.SaveChangesAsync();

            // // Act
            // var userProgression = await _repository.GetProgressionAsync(user.UserId, userResourceState.LearningResourceId);

            // // Assert
            // Assert.Equal(40, userProgression.ProgressPercent);
            // Assert.Equal(user.UserName, userProgression.User.UserName);
        }
    }
}