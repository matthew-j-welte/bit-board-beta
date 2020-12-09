using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;

namespace API.Interfaces
{
    public interface ISkillsRepository
    {
        Task<IEnumerable<SkillDto>> GetSkillsAsync();
    }
}