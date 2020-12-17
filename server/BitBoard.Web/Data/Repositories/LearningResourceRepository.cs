using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Enums;
using API.Interfaces.Repositories;
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

        public async Task<LearningResourceModel> GetModelAsync(int learningResourceId, int userId)
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

        public async Task<IEnumerable<LearningResourceModel>> GetAllModelsAsync()
        {
            return await _context
                .LearningResources
                .ProjectTo<LearningResourceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LearningResourceDto> GetAsync(int learningResourceId)
        {
            return await _context
                .LearningResources
                .Where(x => x.LearningResourceId == learningResourceId)
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<LearningResourceDto>> GetAllAsync()
        {
            return await _context
                .LearningResources
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LearningResourceDto> AddAsync(LearningResourceDto resource)
        {
            var resourceEntity = _mapper.Map<LearningResourceDto, LearningResource>(resource);
            await _context.AddAsync(resourceEntity);
            return _mapper.Map<LearningResource, LearningResourceDto>(resourceEntity);
        }

        public async Task RemoveAsync(LearningResourceDto resource)
        {
            if (await _context.LearningResources.AnyAsync(r => r.LearningResourceId == resource.LearningResourceId))
            {
                var resourceEntity = new LearningResource { LearningResourceId = resource.LearningResourceId };
                _context.LearningResources.Remove(resourceEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Cannot remove this record because it does not exist");
            }
        }

        public async Task UpdateAsync(LearningResourceDto resource)
        {
            var resourceEntity = _mapper.Map<LearningResourceDto, LearningResource>(resource);
            _context.LearningResources.Update(resourceEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LearningResourceDto>> GetTopViewedAsync(int amount)
        {
            return await _context
                .LearningResources
                .OrderByDescending(l => l.Viewers)
                .Take(amount)
                .ProjectTo<LearningResourceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PostDto> UpdatePostAsync(PostDto post, int userId)
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

            var userPostRelationship = await _context
            .UserPostRelationships
            .Where(x => x.UserId == userId && x.LearningResourceId == post.LearningResourceId && x.PostId == post.PostId)
            .SingleOrDefaultAsync();

            if (userPostRelationship == null)
            {
                var newRelationship = new UserPostRelationship
                {
                    LearningResourceId = post.LearningResourceId,
                    PostId = post.PostId,
                    UserId = userId,
                    UserPostAction = post.UserPostAction
                };
                await _context.UserPostRelationships.AddAsync(newRelationship);
            }
            else
            {
                userPostRelationship.UserPostAction = post.UserPostAction;
            }
            
            var postEntity = await _context.Posts.Where(x => x.PostId == post.PostId).SingleOrDefaultAsync();
            postEntity.Likes += likeDiff;
            postEntity.Reports += reportDiff;
            await _context.SaveChangesAsync();

            return _mapper.Map<Post, PostDto>(postEntity);
        }

        public async Task<PostDto> AddPostAsync(PostDto post)
        {
            var postEntity = _mapper.Map<PostDto, Post>(post);
            await _context.Posts.AddAsync(postEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Post, PostDto>(postEntity);
        }
    }
}