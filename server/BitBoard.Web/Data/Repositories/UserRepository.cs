using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using API.Models;

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

        public void DeletetUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<CodeEditorConfigurationDto>> GetCodeEditorConfigurationsAsync()
        {
            return await _context.CodeEditorConfigurations
                .ProjectTo<CodeEditorConfigurationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserResourceStateDto> GetLearningResourceProgressionAsync(int userId, int learningResourceId)
        {
            return await _context.UserResourceStates
                .Where(x => x.UserId == userId && x.LearningResourceId == learningResourceId)
                .ProjectTo<UserResourceStateDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserResourceStateDto>> GetLearningResourceProgressionsAsync(int id)
        {
            return await _context.UserResourceStates
                .Where(x => x.UserId == id)
                .ProjectTo<UserResourceStateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleAsync();
        }

        public async Task<UserModel> GetUserModelByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserModelsAsync()
        {
            return await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDto> InsertUserAsync(RegistrationDto userRegistration)
        {
            var user = _mapper.Map<RegistrationDto, User>(userRegistration);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return await GetUserByUsernameAsync(userRegistration.UserName);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}