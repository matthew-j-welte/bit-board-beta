// using System.Threading.Tasks;
// using Xunit;
// using Microsoft.EntityFrameworkCore;
// using API.Models.DTOs;
// using API.Data.Entities;
// using System;
// using System.Linq;

// namespace BitBoard.Web.Tests.Data.Repositories
// {
//     public class UserRepositoryTests : BaseTestRepository
//     {
//         private UserDto ValidUserDto()
//         {
//             var g = Guid.NewGuid().ToString();
//             return new UserDto()
//             {
//                 UserName = "mw" + g,
//                 Password = "P" + g,
//                 FirstName = "M" + g,
//                 LastName = "W" + g
//             };
//         }

//         private User ValidUser()
//         {
//             var g = Guid.NewGuid().ToString();
//             return new User()
//             {
//                 UserName = "mw" + g,
//                 Password = "P" + g,
//                 FirstName = "M" + g,
//                 LastName = "W" + g
//             };
//         }

//         [Fact]
//         public async Task GetUserModelAsync_ValidUser_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var sampleUser = await ctx.Users.Where(u => u.UserId == 1).SingleAsync();

//                 // Act
//                 var userModel = await repo.GetUserModelAsync(sampleUser.UserName);

//                 // Assert
//                 // Assert.NotEmpty(userModel.CodeEditorConfigurations);
//                 Assert.NotNull(userModel.Comments);
//                 Assert.NotNull(userModel.LearningResources);
//                 Assert.NotNull(userModel.Posts);

//                 // Users should have user skills on registration
//                 Assert.NotEmpty(userModel.UserSkills);
//             }
//         }

//         [Fact]
//         public async Task AddAsync_ValidUser_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var user = ValidUserDto();
//                 await repo.AddAsync(user);

//                 // Act
//                 await ctx.SaveChangesAsync();
//                 var createdUser = await ctx.Users.Where(u => u.UserName == user.UserName).SingleOrDefaultAsync();

//                 // Assert
//                 Assert.NotNull(createdUser);
//                 Assert.NotNull(createdUser.UserId);
//             }
//         }

//         [Fact]
//         public async Task GetAsync_ValidUserByUsername_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(_ctx);
//                 var user = ValidUserDto();
//                 await repo.AddAsync(user);

//                 // Act
//                 await ctx.SaveChangesAsync();
//                 var createdUser = await repo.GetAsync(user.UserName);

//                 // Assert
//                 Assert.NotNull(createdUser);
//                 Assert.NotNull(createdUser.UserId);
//             }
//         }

//         [Fact]
//         public async Task GetAsync_NonExistentUsername_ThrowError()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var user = ValidUser();
//                 ctx.Users.Add(user);
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 Task invalidUserReq() => repo.GetAsync(user.UserName + "WRONG");

//                 // Assert
//                 await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
//             }

//         }

//         [Fact]
//         public async Task GetAsync_ValidUserById_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 // Arrange
//                 var user = ValidUser();
//                 ctx.Users.Add(user);
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 var userDto = await repo.GetAsync(user.UserId);

//                 // Assert
//                 Assert.Equal(user.UserName, userDto.UserName);
//                 Assert.Equal(user.Password, userDto.Password);
//                 Assert.Equal(user.FirstName, userDto.FirstName);
//                 Assert.Equal(user.LastName, userDto.LastName);
//             }
//         }

//         [Fact]
//         public async Task GetAsync_NonExistentId_ThrowError()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 // Arrange
//                 var user = ValidUser();
//                 ctx.Users.Add(user);
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 Task invalidUserReq() => repo.GetAsync(user.UserId + 1);

//                 // Assert
//                 await Assert.ThrowsAsync<InvalidOperationException>(invalidUserReq);
//             }
//         }

//         [Fact]
//         public async Task GetAllAsync_ValidUsers_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 // Arrange
//                 var user1 = ValidUser();
//                 var user2 = ValidUser();
//                 await ctx.Users.AddRangeAsync(new User[] { user1, user2 });
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 var userDtos = await repo.GetAllAsync();

//                 // Assert
//                 foreach (var userDto in userDtos)
//                 {
//                     if (userDto.UserId == user1.UserId)
//                     {
//                         Assert.Equal(user1.UserName, userDto.UserName);
//                         Assert.Equal(user1.Password, userDto.Password);
//                         Assert.Equal(user1.FirstName, userDto.FirstName);
//                         Assert.Equal(user1.LastName, userDto.LastName);
//                     }
//                     else if (userDto.UserId == user2.UserId)
//                     {
//                         Assert.Equal(user2.UserName, userDto.UserName);
//                         Assert.Equal(user2.Password, userDto.Password);
//                         Assert.Equal(user2.FirstName, userDto.FirstName);
//                         Assert.Equal(user2.LastName, userDto.LastName);
//                     }
//                 }
//             }
//         }

//         [Fact]
//         public async Task Remove_ExistingUser_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var originalCount = await ctx.Users.CountAsync();
//                 await repo.RemoveAsync(new UserDto { UserId = 1 });

//                 // Act
//                 var count = await ctx.Users.CountAsync();

//                 // Assert
//                 Assert.Equal(originalCount - 1, count);
//             }
//         }

//         [Fact]
//         public async Task Remove_NonExistentUser_ThrowError()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 // Arrange
//                 var user = ValidUserDto();
//                 var fakeUser = ValidUserDto();
//                 await repo.AddAsync(user);
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 Task invalidRemoveReq() => repo.RemoveAsync(fakeUser);

//                 // Assert
//                 await Assert.ThrowsAsync<InvalidOperationException>(invalidRemoveReq);
//             }
//         }

//         [Fact]
//         public async Task Update_ExistingUser_SuccessAsync()
//         {
//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var user = new UserDto
//                 {
//                     UserId = 1,
//                     UserName = "NewUser",
//                     FirstName = "New",
//                     LastName = "User"
//                 };
//                 await repo.UpdateAsync(user);
//             }

//             using (var ctx = _ctx)
//             {
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var updatedUser = await ctx.Users.Where(u => u.UserId == 1).SingleOrDefaultAsync();
//                 Assert.Equal("NewUser", updatedUser.UserName);
//                 Assert.Equal("New", updatedUser.FirstName);
//                 Assert.Equal("User", updatedUser.LastName);
//             }
//         }

//         [Fact]
//         public async Task Update_NonExistentUser_ThrowError()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var user = ValidUserDto();
//                 var fakeUser = ValidUserDto();
//                 await repo.AddAsync(user);
//                 await ctx.SaveChangesAsync();

//                 // Act
//                 Task invalidUpdateReq() => repo.UpdateAsync(fakeUser);

//                 // Assert
//                 await Assert.ThrowsAsync<InvalidOperationException>(invalidUpdateReq);
//             }
//         }

//         [Fact]
//         public async Task GetResourceStateAsync_UserWithResourceState_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var userState = await ctx.UserResourceStates.FirstAsync();
//                 var realUser = await ctx.Users.Where(u => u.UserId == userState.UserId).SingleAsync();
//                 var realResource = await ctx.LearningResources.Where(r => r.LearningResourceId == userState.LearningResourceId).SingleAsync();

//                 // Act
//                 var userResourceProgression = await repo.GetResourceStateAsync(userState.UserId, userState.LearningResourceId);

//                 // Assert
//                 Assert.Equal(userState.ProgressPercent, userResourceProgression.ProgressPercent);
//                 Assert.Equal(realUser.UserId, userResourceProgression.User.UserId);
//                 Assert.Equal(realUser.UserName, userResourceProgression.User.UserName);
//                 Assert.Equal(realResource.LearningResourceId, userResourceProgression.LearningResource.LearningResourceId);
//                 Assert.Equal(realResource.Title, userResourceProgression.LearningResource.Title);
//             }
//         }

//         [Fact]
//         public async Task GetProgressionAsync_UserWithoutResourceProgression_ReturnNull()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var userState = await ctx.UserResourceStates.FirstAsync();

//                 // Act
//                 var nullState = await repo.GetResourceStateAsync(userState.UserId, -1);

//                 // Assert
//                 Assert.Null(nullState);
//             }
//         }

//         [Fact]
//         public async Task GetProgressionAsync_ResourceProgressionWithoutUser_ReturnNull()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var userState = await ctx.UserResourceStates.FirstAsync();

//                 // Act
//                 var nullState = await repo.GetResourceStateAsync(-1, userState.LearningResourceId);

//                 // Assert
//                 Assert.Null(nullState);
//             }
//         }

//         [Fact]
//         public async Task GetAllResourceStatesAsync_UserWithResourceStates_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);
//                 var userState = await ctx.UserResourceStates.FirstAsync();
//                 var userStates = await ctx.UserResourceStates
//                     .Where(u => u.UserId == userState.UserId)
//                     .OrderBy(u => u.LearningResourceId)
//                     .ToListAsync();

//                 var realUser = await ctx.Users
//                     .Where(u => u.UserId == userState.UserId)
//                     .SingleAsync();

//                 // Act
//                 var userResourceProgressions = await repo.GetAllResourceStatesAsync(userState.UserId);
//                 userResourceProgressions = userResourceProgressions.OrderBy(s => s.LearningResource.LearningResourceId).ToList();

//                 var truthAndActual = userStates.Zip(userResourceProgressions, (t, a) => new { Truth = t, Actual = a });

//                 // Assert
//                 foreach (var state in truthAndActual)
//                 {
//                     var realResource = await ctx.LearningResources.Where(r => r.LearningResourceId == state.Actual.LearningResource.LearningResourceId).SingleOrDefaultAsync();
//                     Assert.Equal(state.Truth.ProgressPercent, state.Actual.ProgressPercent);
//                     Assert.Equal(realUser.UserId, state.Actual.User.UserId);
//                     Assert.Equal(realUser.UserName, state.Actual.User.UserName);
//                     Assert.NotNull(realResource);
//                     Assert.Equal(realResource.LearningResourceId, state.Actual.LearningResource.LearningResourceId);
//                     Assert.Equal(realResource.Title, state.Actual.LearningResource.Title);
//                 }
//             }
//         }

//         [Fact]
//         public async Task GetAllResourceStatesAsync_UserWithoutResourceStates_EmptyList()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetUserRepository(ctx);

//                 // Act
//                 var states = await repo.GetAllResourceStatesAsync(-1);

//                 // Assert
//                 Assert.Empty(states);
//             }
//         }
//     }
// }