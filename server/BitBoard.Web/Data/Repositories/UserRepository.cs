using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models.DTOs;
using API.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System;

namespace API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUserModelAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllModelsAsync()
        {
            return await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDto> GetAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _context.Users
                .Where(u => u.UserId == id)
                .SingleAsync();
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDto> AddAsync(UserDto userRegistration)
        {
            var user = _mapper.Map<UserDto, User>(userRegistration);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RemoveAsync(UserDto user)
        {
            if (await _context.Users.AnyAsync(u => u.UserId == user.UserId || u.UserName == user.UserName))
            {
                var userEntity = new User { UserId = user.UserId, UserName = user.UserName };
                _context.Users.Remove(userEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Cannot remove this record because it does not exist");
            }

        }

        public async Task UpdateAsync(UserDto user)
        {
            var exists = await _context.Users.AnyAsync(u => u.UserId == user.UserId || u.UserName == user.UserName);
            if (exists)
            {
                var userEntity = _mapper.Map<UserDto, User>(user);
                _context.Users.Update(userEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Cannot update this record because it does not exist");
            }
        }

        public Task<IEnumerable<CodeEditorConfigurationDto>> GetCodeEditorConfigurationsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResourceStateDto> GetProgressionAsync(int userId, int learningResourceId)
        {
            return await _context.UserResourceStates
                .Where(x => x.UserId == userId && x.LearningResourceId == learningResourceId)
                .ProjectTo<UserResourceStateDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserResourceStateDto>> GetProgressionsAsync(int id)
        {
            return await _context.UserResourceStates
                .Where(x => x.UserId == id)
                .ProjectTo<UserResourceStateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}