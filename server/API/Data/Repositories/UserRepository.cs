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

        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async void InsertUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}