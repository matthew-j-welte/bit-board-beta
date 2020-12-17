using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Enums;
using API.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BitBoard.Web.Tests.Data.Repositories
{
    public class LearningResourceRepositoryTests : BaseTestRepository
    {
        private LearningResourceDto ValidResourceDto()
        {
            var g = Guid.NewGuid().ToString();

            List<Skill> sampleSkills;
            using (var ctx = _ctx)
            {
                sampleSkills = ctx.Skills.OrderByDescending(s => s.SkillId).Take(3).ToList();
            }

            var dtoSkills = new List<SkillDto>();
            foreach (var skill in sampleSkills)
            {
                dtoSkills.Add(new SkillDto
                {
                    SkillId = skill.SkillId
                });
            }

            return new LearningResourceDto()
            {
                Title = "mw" + g,
                Description = "P" + g,
                ImageUrl = "M" + g,
                Viewers = 10,
                Skills = dtoSkills,
                UserId = 1
            };
        }

        private LearningResource ValidResource()
        {
            var g = Guid.NewGuid().ToString();
            return new LearningResource()
            {
                Title = "mw" + g,
                Description = "P" + g,
                ImageUrl = "M" + g,
                Viewers = 10
            };
        }

        private async Task<LearningResource> ExistingResource()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                return await ctx.LearningResources.Take(1).SingleAsync();
            }
        }

        [Fact]
        public async Task GetUserModelAsync_ValidUser_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resourceState = await ctx.UserResourceStates.FirstAsync();
                var postRelationship = await ctx.UserPostRelationships
                    .Where(u => u.LearningResourceId == resourceState.LearningResourceId)
                    .FirstAsync();

                var sampleResource = await ctx.LearningResources
                    .Where(lr => lr.LearningResourceId == postRelationship.LearningResourceId)
                    .FirstAsync();

                // Act
                var resourceModel = await repo.GetModelAsync(sampleResource.LearningResourceId, resourceState.UserId);

                // Assert
                Assert.NotNull(resourceModel.Posts);
                foreach (var post in resourceModel.Posts)
                {
                    Assert.NotNull(post.UserPostAction);
                }
                Assert.NotNull(resourceModel.Skills);
                Assert.NotNull(resourceModel.Description);
                Assert.NotNull(resourceModel.ImageUrl);
                Assert.NotNull(resourceModel.Title);
                Assert.NotNull(resourceModel.Type);
                Assert.NotNull(resourceModel.UserResourceState);
                Assert.NotEqual(0, resourceModel.Viewers);
            }
        }

        [Fact]
        public async Task GetAllModelsAsync_AllModels_Exist()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var models = await repo.GetAllModelsAsync();

                Assert.NotEmpty(models);
            }
        }

        [Fact]
        public async Task GetAsync_ValidResource_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resource = await repo.GetAsync(30);

                Assert.NotNull(resource);
                Assert.NotEqual(0, resource.Viewers);
                Assert.NotNull(resource.Description);
                Assert.NotNull(resource.ImageUrl);
                Assert.NotNull(resource.Title);
                Assert.NotNull(resource.Type);
            }
        }

        [Fact]
        public async Task GetAsync_NonExistentResource_Null()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resource = await repo.GetAsync(-1);

                Assert.Null(resource);
            }
        }

        [Fact]
        public async Task GetAllAsync_ValidResources_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resources = await repo.GetAllAsync();

                foreach (var resource in resources)
                {
                    Assert.NotEqual(0, resource.Viewers);
                    Assert.NotNull(resource.Description);
                    Assert.NotNull(resource.ImageUrl);
                    Assert.NotNull(resource.Title);
                    Assert.NotNull(resource.Type);
                }
            }
        }

        [Fact]
        public async Task AddAsync_ValidResource_Success()
        {
            string addedResourceTitle;

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var addedResource = await repo.AddAsync(ValidResourceDto());

                await ctx.SaveChangesAsync();

                addedResourceTitle = addedResource.Title;
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resource = await ctx.LearningResources
                    .Where(r => r.Title == addedResourceTitle)
                    .SingleAsync();


                var resourceSkills = await (ctx.LearningResourceSkills
                    .Where(r => r.LearningResourceId == resource.LearningResourceId)
                    .ToListAsync());

                foreach (var skill in resourceSkills)
                {
                    Assert.NotEqual(0, skill.LearningResourceId);
                    Assert.NotEqual(0, skill.SkillId);
                }
            }
        }

        [Fact]
        public async Task RemoveAsync_ExistingResource_Success()
        {
            int sampleResourceId;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var sampleResource = await ExistingResource();
                sampleResourceId = sampleResource.LearningResourceId;
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var originalCount = await ctx.LearningResources.CountAsync();
                await repo.RemoveAsync(new LearningResourceDto { LearningResourceId = sampleResourceId });

                // Act
                var count = await ctx.LearningResources.CountAsync();
                var resourceSkillRecords = await ctx.LearningResourceSkills.Where(s => s.LearningResourceId == sampleResourceId).ToListAsync();

                // Assert
                Assert.Equal(originalCount - 1, count);
                Assert.Empty(resourceSkillRecords);
            }
        }

        [Fact]
        public async Task RemoveAsync_NonExistentResource_ThrowError()
        {
            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                Task invalidRemoveReq() => repo.RemoveAsync(new LearningResourceDto { LearningResourceId = -1 });

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidRemoveReq);
            }
        }

        [Fact]
        public async Task UpdateAsync_ExistingResource_Success()
        {
            LearningResource sampleResource;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                sampleResource = await ExistingResource();
                var mapper = DataContextFactory.GetMapper();
                var dto = mapper.Map<LearningResource, LearningResourceDto>(sampleResource);
                dto.Title = "NewTitle";
                dto.Description = "NewDesc";
                dto.Viewers = 10;
                await repo.UpdateAsync(dto);
            }

            using (var ctx = _ctx)
            {
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var updatedResource = await ctx.LearningResources
                    .Where(r => r.LearningResourceId == sampleResource.LearningResourceId)
                    .SingleAsync();

                Assert.Equal("NewTitle", updatedResource.Title);
                Assert.Equal("NewDesc", updatedResource.Description);
                Assert.Equal(10, updatedResource.Viewers);
            }
        }

        [Fact]
        public async Task GetTopViewedAsync_ExistingResources_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resources = (await repo.GetTopViewedAsync(5)).ToList();
                var allResources = await ctx.LearningResources.ToListAsync();
                allResources = allResources.OrderByDescending(r => r.Viewers).ToList();
                var isDescending = true;
                for (var i = 0; i < resources.Count; i++)
                {
                    var actualResource = resources[i];
                    var expectedResource = allResources[i];
                    if (actualResource.Viewers != expectedResource.Viewers)
                    {
                        isDescending = false;
                        break;
                    }
                }

                Assert.True(isDescending);
            }
        }

        [Fact]
        public async Task GetTopViewedAsync_NotEnoughResources_GivesFullList()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var resourceCount = await ctx.LearningResources.CountAsync();
                var resources = await repo.GetTopViewedAsync(resourceCount + 10);
                Assert.Equal(resourceCount, resources.Count());
            }
        }

        [Fact]
        public async Task UpdatePostAsync_NoneToLike_Success()
        {
            int userPostRelationshipId;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.UserPostAction == UserPostActionEnum.None).FirstAsync();
                userPostRelationshipId = postRelationship.Id;
                var post = await ctx.Posts.Where(p => p.PostId == postRelationship.PostId).SingleAsync();
                var mapper = DataContextFactory.GetMapper();
                var postDto = mapper.Map<Post, PostDto>(post);
                postDto.PreviousUserPostAction = UserPostActionEnum.None;
                postDto.UserPostAction = UserPostActionEnum.Liked;
                await repo.UpdatePostAsync(postDto, postRelationship.UserId);
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.Id == userPostRelationshipId).FirstAsync();
                
                Assert.Equal(UserPostActionEnum.Liked, postRelationship.UserPostAction);
            }
        }

        [Fact]
        public async Task UpdatePostAsync_NoneToReport_Success()
        {
            int userPostRelationshipId;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.UserPostAction == UserPostActionEnum.None).FirstAsync();
                userPostRelationshipId = postRelationship.Id;
                var post = await ctx.Posts.Where(p => p.PostId == postRelationship.PostId).SingleAsync();
                var mapper = DataContextFactory.GetMapper();
                var postDto = mapper.Map<Post, PostDto>(post);
                postDto.PreviousUserPostAction = UserPostActionEnum.None;
                postDto.UserPostAction = UserPostActionEnum.Reported;
                await repo.UpdatePostAsync(postDto, postRelationship.UserId);
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.Id == userPostRelationshipId).FirstAsync();
                
                Assert.Equal(UserPostActionEnum.Reported, postRelationship.UserPostAction);
            }
        }

        [Fact]
        public async Task UpdatePostAsync_LikeToReport_Success()
        {
            int userPostRelationshipId;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.UserPostAction == UserPostActionEnum.Liked).FirstAsync();
                userPostRelationshipId = postRelationship.Id;
                var post = await ctx.Posts.Where(p => p.PostId == postRelationship.PostId).SingleAsync();
                var mapper = DataContextFactory.GetMapper();
                var postDto = mapper.Map<Post, PostDto>(post);
                postDto.PreviousUserPostAction = UserPostActionEnum.Liked;
                postDto.UserPostAction = UserPostActionEnum.Reported;
                await repo.UpdatePostAsync(postDto, postRelationship.UserId);
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.Id == userPostRelationshipId).FirstAsync();
                
                Assert.Equal(UserPostActionEnum.Reported, postRelationship.UserPostAction);
            }
        }

        [Fact]
        public async Task UpdatePostAsync_AuthoredToLike_ThrowsError()
        {
            int userPostRelationshipId;
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var postRelationship = await ctx.UserPostRelationships.Where(r => r.UserPostAction == UserPostActionEnum.Authored).FirstAsync();
                userPostRelationshipId = postRelationship.Id;
                var post = await ctx.Posts.Where(p => p.PostId == postRelationship.PostId).SingleAsync();
                var mapper = DataContextFactory.GetMapper();
                var postDto = mapper.Map<Post, PostDto>(post);
                postDto.PreviousUserPostAction = UserPostActionEnum.Authored;
                postDto.UserPostAction = UserPostActionEnum.Liked;
                Task invalidPostUpdate() => repo.UpdatePostAsync(postDto, postRelationship.UserId);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(invalidPostUpdate);
            }
        }

        [Fact]
        public async Task UpdatePostAsync_NonExistentUserPostRelationship_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var samplePost = await ctx.Posts.Take(1).FirstAsync();
                var post = new Post
                {
                    LearningResourceId = samplePost.LearningResourceId,
                    Content = "New Content",
                    UserId = samplePost.UserId,
                };
                await ctx.Posts.AddAsync(post);
                await ctx.SaveChangesAsync();
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                
                var post = await ctx.Posts.Where(p => p.Content == "New Content").SingleAsync();
                var postDto = new PostDto
                {
                    LearningResourceId = post.LearningResourceId,
                    PostId = post.PostId,
                    UserId = post.UserId,
                    PreviousUserPostAction = UserPostActionEnum.None,
                    UserPostAction = UserPostActionEnum.Liked
                };

                await repo.UpdatePostAsync(postDto, post.UserId);
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                
                var post = await ctx.Posts.Where(p => p.Content == "New Content").SingleAsync();
                var postId = post.PostId;

                var relationship = ctx.UserPostRelationships.Where(p => p.PostId == postId).SingleOrDefaultAsync();
                
                Assert.NotNull(relationship);
            }
        }

        [Fact]
        public async Task AddPostAsync_ValidPost_Success()
        {
            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                var samplePost = await ctx.Posts.Take(1).FirstAsync();
                var post = new PostDto
                {
                    LearningResourceId = samplePost.LearningResourceId,
                    Content = "New Post",
                    UserId = samplePost.UserId,
                    Likes = 100
                };
                await repo.AddPostAsync(post);
                await ctx.SaveChangesAsync();
            }

            using (var ctx = _ctx)
            {
                // Arrange
                var repo = DataContextFactory.GetLearningResourceRepository(ctx);
                
                var post = await ctx.Posts.Where(p => p.Content == "New Post").SingleAsync();
                
                Assert.Equal(100, post.Likes);
                Assert.Equal("New Post", post.Content);
                Assert.NotEqual(0, post.UserId);
                Assert.NotEqual(0, post.PostId);
                Assert.NotEqual(0, post.LearningResourceId);
            }
        }
    }
}
