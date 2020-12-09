using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Models.DTOs;
using BitBoard.Web.Interfaces.Base;

namespace API.Interfaces.Repositories
{
    public interface ILearningResourceRepository : IRepository<LearningResourceDto>
    {
        Task<IEnumerable<LearningResourceModel>> GetAllModelsAsync();
        Task<LearningResourceModel> GetModelAsync(int learningResourceId, int userId);
        Task<IEnumerable<LearningResourceDto>> GetTopViewedAsync(int amount);
        Task<PostDto> UpdatePostAsync(PostDto post, int userId);
        Task<PostDto> AddPostAsync(PostDto post);
    }
}