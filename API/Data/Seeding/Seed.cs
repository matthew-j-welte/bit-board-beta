using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Seeding
{
    public class Seed
    {
        public static async Task SeedSkills(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var skillsData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Skills.json");
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

            var userData = await System.IO.File.ReadAllTextAsync("Data/Seeding/Users.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            
            if (users == null) throw new JsonException("Failed to deserialize");

            foreach (var user in users)
            {
                await context.Users.AddAsync(user);
            }

            await context.SaveChangesAsync();
        }
    }
}