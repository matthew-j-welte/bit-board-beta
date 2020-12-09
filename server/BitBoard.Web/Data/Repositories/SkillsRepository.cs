using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
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

        public async Task<IEnumerable<SkillDto>> GetSkillsAsync()
        {
            return await _context.Skills
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}