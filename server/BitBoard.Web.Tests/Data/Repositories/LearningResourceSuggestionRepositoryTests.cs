// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using API.Models.DTOs;
// using Microsoft.EntityFrameworkCore;
// using Xunit;

// namespace BitBoard.Web.Tests.Data.Repositories
// {
//     public class LearningResourceSuggestionRepositoryTests : BaseTestRepository
//     {
//         private LearningResourceSuggestionDto ValidResourceSuggestion()
//         {
//             return new LearningResourceSuggestionDto
//             {
//                 UserId = 1,
//                 Rationale = "Some Rationale",
//                 SourceUrl = "www.com",
//                 Skills = new List<SkillDto> { new SkillDto { SkillId = 1 }, new SkillDto { SkillId = 2 } }
//             };
//         }

//         [Fact]
//         public async Task AddAsync_ValidResourceSuggestion_Success()
//         {
//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetLearningResourceSuggestionRepository(ctx);
//                 var addedResource = await repo.AddAsync(ValidResourceSuggestion());

//                 await ctx.SaveChangesAsync();
//             }

//             using (var ctx = _ctx)
//             {
//                 // Arrange
//                 var repo = DataContextFactory.GetLearningResourceSuggestionRepository(ctx);
//                 var suggestion = await ctx.LearningResourceSuggestions.Where(r => r.Rationale == "Some Rationale").SingleOrDefaultAsync();

//                 Assert.NotNull(suggestion);

//                 var suggestionSkils = ctx.LearningResourceSuggestionSkills
//                     .Where(r => r.LearningResourceSuggestionId == suggestion.LearningResourceSuggestionId);

//                 Assert.Equal(2, suggestionSkils.Count());
//             }
//         }
//     }
// }