using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Seeding
{
    public class Seed
    {
        public static async Task SeedSkills(DataContext context)
        {
            if (await context.Skills.AnyAsync()) return;

            // TODO: Update this to pull from the config file
            var skillsData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/Skills.json");
            var skills = JsonSerializer.Deserialize<List<Skill>>(skillsData);
            
            if (skills == null) throw new JsonException("Failed to deserialize");

            foreach (var skill in skills)
            {
                await context.Skills.AddAsync(skill);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/Users.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            
            if (users == null) throw new JsonException("Failed to deserialize");

            foreach (var user in users)
            {
                await context.Users.AddAsync(user);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedUserProgressions(DataContext context)
        {
            if (await context.UserResourceStates.AnyAsync()) return;

            var userProgressionData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/UserResourceStates.json");
            var userProgressions = JsonSerializer.Deserialize<List<UserResourceState>>(userProgressionData);
            
            if (userProgressions == null) throw new JsonException("Failed to deserialize");

            foreach (var userProgress in userProgressions)
            {
                await context.UserResourceStates.AddAsync(userProgress);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedComments(DataContext context)
        {
            if (await context.Comments.AnyAsync()) return;

            var commentData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/Comments.json");
            var comments = JsonSerializer.Deserialize<List<Comment>>(commentData);
            
            if (comments == null) throw new JsonException("Failed to deserialize");

            foreach (var comment in comments)
            {
                await context.Comments.AddAsync(comment);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedPosts(DataContext context)
        {
            if (await context.Posts.AnyAsync()) return;

            var postData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/Posts.json");
            var posts = JsonSerializer.Deserialize<List<Post>>(postData);
            
            if (posts == null) throw new JsonException("Failed to deserialize");

            foreach (var post in posts)
            {
                await context.Posts.AddAsync(post);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedLearningResources(DataContext context)
        {
            if (await context.LearningResources.AnyAsync()) return;

            var learningResourceData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Generated/LearningResources.json");
            var learningResources = JsonSerializer.Deserialize<List<LearningResource>>(learningResourceData);
            
            if (learningResources == null) throw new JsonException("Failed to deserialize");

            foreach (var learningResource in learningResources)
            {
                await context.LearningResources.AddAsync(learningResource);
            }

            await context.SaveChangesAsync();
        }
    }
}