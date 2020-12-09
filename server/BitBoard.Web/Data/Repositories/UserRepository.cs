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
using BitBoard.Web.Interfaces.Base;

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

        public void DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<CodeEditorConfigurationDto>> GetCodeEditorConfigurationsAsync()
        {
            return await _context.CodeEditorConfigurations
                .ProjectTo<CodeEditorConfigurationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
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

        public async Task<UserDto> GetAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
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
            return _mapper.Map<User, UserDto>(user);
        }

        public void Remove(UserDto entity)
        {
            throw new System.NotImplementedException();
        }

        public UserDto Update(UserDto user)
        {
            var userEntity = _mapper.Map<UserDto, User>(user);
            _context.Users.Update(userEntity);
            return _mapper.Map<User, UserDto>(userEntity);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }
    }
}