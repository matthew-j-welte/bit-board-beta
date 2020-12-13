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

namespace BitBoard.Web.Tests.Data.Repositories
{
    public static class DataContextFactory
    {
        public static DataContext GetDataContext()
        {
            var connection = new SqliteConnection("Data source=unit-testing.db");

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
        public DatabaseFixture()
        {
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
        }

        public void Dispose()
        {
            Console.WriteLine("Delete the db file!!!");
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
        private readonly UserRepository _repository;
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepositoryTests()
        {
        }

        private async Task PreSeedDbAsync()
        {
            var dataQuery = new DataQuery();
            await dataQuery.GenerateDataAsync();

            await Seed.SeedSkills(_dbContext);
            await Seed.SeedUsers(_dbContext);
            await Seed.SeedLearningResources(_dbContext);
            await Seed.SeedUserProgressions(_dbContext);
            await Seed.SeedPosts(_dbContext);
            await Seed.SeedComments(_dbContext);
        }

        private UserDto ValidUserDto(string suffix = "")
        {
            return new UserDto()
            {
                UserName = "mwelte" + suffix,
                Password = "Password" + suffix,
                FirstName = "Matt" + suffix,
                LastName = "Welte" + suffix
            };
        }

        private User ValidUser(string suffix = "")
        {
            return new User()
            {
                UserName = "mwelte" + suffix,
                Password = "Password" + suffix,
                FirstName = "Matt" + suffix,
                LastName = "Welte" + suffix
            };
        }

        [Fact]
        public async Task AddAsync_ValidUser_Success()
        {
            // Arrange
            var user = ValidUserDto();
            await _repository.AddAsync(user);
            
            // Act
            await _dbContext.SaveChangesAsync();
            var createdUser = await _dbContext.Users.Where(u => u.UserName == user.UserName).SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(createdUser);
            Assert.NotNull(createdUser.UserId);
        }

        [Fact]
        public async Task GetAsync_ValidUserByUsername_Success()
        {
            // Arrange
            var user = ValidUserDto();
            await _repository.AddAsync(user);
            
            // Act
            await _dbContext.SaveChangesAsync();
            var createdUser = await _repository.GetAsync(user.UserName);

            // Assert
            Assert.NotNull(createdUser);
            Assert.NotNull(createdUser.UserId);
        }

        [Fact]
        public async Task GetAsync_NonExistentUsername_ThrowError()
        {
            // Arrange
            var user = ValidUser();
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Act
            Task invalidUserReq() => _repository.GetAsync(user.UserName + "WRONG");

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
        }

        [Fact]
        public async Task GetAsync_ValidUserById_Success()
        {
            // Arrange
            var user = ValidUser();
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Act
            var userDto = await _repository.GetAsync(user.UserId);

            // Assert
            Assert.Equal(user.UserName, userDto.UserName);
            Assert.Equal(user.Password, userDto.Password);
            Assert.Equal(user.FirstName, userDto.FirstName);
            Assert.Equal(user.LastName, userDto.LastName);
        }

        [Fact]
        public async Task GetAsync_NonExistentId_ThrowError()
        {
            // Arrange
            var user = ValidUser();
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Act
            Task invalidUserReq() => _repository.GetAsync(user.UserId + 1);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
        }

        [Fact]
        public async Task GetAllAsync_ValidUsers_Success()
        {
            // Arrange
            var user1 = ValidUser("1");
            var user2 = ValidUser("2");
            await _dbContext.Users.AddRangeAsync(new User[] { user1, user2 });
            await _dbContext.SaveChangesAsync();

            // Act
            var userDtos = await _repository.GetAllAsync();

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

        [Fact]
        public async Task Remove_ExistingUser_Success()
        {
            // Arrange
            using (var ctx = DataContextFactory.GetDataContext())
            {
                await PreSeedDbAsync();
            }
            
            // var originalCount = await _dbContext.Users.AsNoTracking().CountAsync();
            using (var ctx = DataContextFactory.GetDataContext())
            {
                var repository = DataContextFactory.GetUserRepository(ctx);
                await repository.RemoveAsync(new UserDto { UserId=1 });
            }

            // Act
            // var count = await _dbContext.Users.CountAsync();

            // Assert
            // Assert.Equal(originalCount - 1, count);
        }

        [Fact]
        public async Task Remove_NonExistentUser_ThrowError()
        {
            // Arrange
            var user = ValidUserDto();
            var fakeUser = ValidUserDto("FAKE");
            await _repository.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            // Act
            Task invalidRemoveReq() => _repository.RemoveAsync(fakeUser);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(invalidRemoveReq);
        }

        [Fact]
        public void Update_ExistingUser_Success()
        {
            // TODO: Need to figure out a clean solution to updating
        }

        [Fact]
        public async Task Update_NonExistentUser_ThrowError()
        {
            // Arrange
            var user = ValidUserDto();
            var fakeUser = ValidUserDto("FAKE");
            await _repository.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            // Act
            Task invalidUpdateReq() => _repository.UpdateAsync(fakeUser);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(invalidUpdateReq);
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