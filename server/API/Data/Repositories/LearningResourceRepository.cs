using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Enums;
using API.Interfaces;
using API.Models;
using API.Models.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class LearningResourceRepository : ILearningResourceRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LearningResourceRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeletetLearningResource(LearningResource learningResource)
        {
            _context.LearningResources.Remove(learningResource);
        }

        public async Task<IEnumerable<LearningResourceDto>> GetLearningResourcesAsync()
        {
            return await _context
                .LearningResources
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<LearningResourceDto>> GetTopViewedLearningResourcesAsync(int amount)
        {
            return await _context
                .LearningResources
                .OrderByDescending(l => l.Viewers)
                .Take(amount)
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LearningResourceDto> GetLearningResourceByIdAsync(int learningResourceId)
        {
            return await _context
                .LearningResources
                .Where(x => x.LearningResourceId == learningResourceId)
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<LearningResourceModel> GetLearningResourceModelByIdAsync(int learningResourceId, int userId)
        {
            var model = await _context
                .LearningResources
                .Where(x => x.LearningResourceId == learningResourceId)
                .ProjectTo<LearningResourceModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            var postActions = await _context
                .UserPostRelationships
                .Where(x => x.LearningResourceId == learningResourceId && x.UserId == userId)
                .ToDictionaryAsync(e => e.PostId, e => e.UserPostAction);

            foreach (var post in model.Posts)
            {
                post.UserPostAction = postActions.GetValueOrDefault(post.PostId);
            }

            var userResourceState = await _context.UserResourceStates
                .Where(x => x.UserId == userId && x.LearningResourceId == learningResourceId)
                .ProjectTo<UserResourceStateDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            model.UserResourceState = userResourceState;
            return model;
        }

        public async Task<IEnumerable<LearningResourceModel>> GetLearningResourceModelsAsync()
        {
            return await _context
                .LearningResources
                .ProjectTo<LearningResourceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async void InsertLearningResourceAsync(LearningResource learningResource)
        {
            await _context.LearningResources.AddAsync(learningResource);
        }

        public void UpdateLearningResource(LearningResource learningResource)
        {
            _context.LearningResources.Update(learningResource);
        }

        public async Task<PostDto> UpdateResourcePost(PostDto post, int userId)
        {
            int likeDiff;
            int reportDiff;

            if (post.PreviousUserPostAction == UserPostActionEnum.None)
            {
                likeDiff = post.UserPostAction == UserPostActionEnum.Liked ? 1 : 0;
                reportDiff = post.UserPostAction == UserPostActionEnum.Reported ? 1 : 0;
            }
            else if (post.PreviousUserPostAction == UserPostActionEnum.Liked)
            {
                likeDiff = -1;
                reportDiff = post.UserPostAction == UserPostActionEnum.Reported ? 1 : 0;
            }
            else
            {
                throw new System.InvalidOperationException(
                    "Should not be able to reverse post report - something went wrong."
                );
            }

            // Update UserPostRelationship 
            // Update likes/reports on Post table
            var userPostRelationship = await _context
            .UserPostRelationships
            .Where(x => x.UserId == userId && x.LearningResourceId == post.LearningResourceId && x.PostId == post.PostId)
            .SingleOrDefaultAsync();
            
            userPostRelationship.UserPostAction = post.UserPostAction;

            // _context.UserPostRelationships
            // .Where(x => x.UserId == userId && x.LearningResourceId == post.LearningResourceId && x.PostId == post.PostId)
            // .Update(y => new UserPostRelationship { UserPostAction=post.UserPostAction });

            var postEntity = await _context.Posts.Where(x=> x.PostId == post.PostId).SingleOrDefaultAsync();
            postEntity.Likes += likeDiff;
            postEntity.Reports += reportDiff;
            await _context.SaveChangesAsync();
            // .Where(x => x.PostId == post.PostId)
            // .Update(y => new Post { Likes=y.Likes + likeDiff, Reports=y.Reports + reportDiff });
            return _mapper.Map<Post, PostDto>(postEntity);
        }
    }
}