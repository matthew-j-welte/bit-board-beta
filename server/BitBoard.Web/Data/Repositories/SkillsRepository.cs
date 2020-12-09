using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces.Repositories;
using API.Models.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SkillsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<SkillDto> AddAsync(SkillDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<SkillDto>> GetAllAsync()
        {
            return await _context.Skills
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public Task<SkillDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(SkillDto entity)
        {
            throw new System.NotImplementedException();
        }

        public SkillDto Update(SkillDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}