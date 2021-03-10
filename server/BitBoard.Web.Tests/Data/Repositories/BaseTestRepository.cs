// using System.Threading.Tasks;
// using Xunit;
// using AutoMapper;
// using API.Helpers;
// using Microsoft.EntityFrameworkCore;
// using API.Data;
// using Microsoft.Data.Sqlite;
// using API.Data.Repositories;
// using API.Models.DTOs;
// using API.Data.Entities;
// using System;
// using API.Data.Seeding;
// using System.Linq;
// using System.IO;

// namespace BitBoard.Web.Tests.Data.Repositories
// {
//     public static class DataContextFactory
//     {
//         public static DataContext GetDataContext()
//         {
//             var connection = new SqliteConnection("Data source=unit-testing.db");
//             connection.Open();
//             var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
//             .UseSqlite(connection)
//             .EnableSensitiveDataLogging()
//             .EnableDetailedErrors()
//             .Options;

//             return new DataContext(dbContextOptions);
//         }

//         public static IMapper GetMapper()
//         {
//             var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
//             return config.CreateMapper();
//         }

//         public static UserRepository GetUserRepository(DataContext ctx)
//         {
//             var mapper = GetMapper();
//             return new UserRepository(ctx, mapper);
//         }

//         public static LearningResourceRepository GetLearningResourceRepository(DataContext ctx)
//         {
//             var mapper = GetMapper();
//             return new LearningResourceRepository(ctx, mapper);
//         }

//         public static LearningResourceSuggestionRepository GetLearningResourceSuggestionRepository(DataContext ctx)
//         {
//             var mapper = GetMapper();
//             return new LearningResourceSuggestionRepository(ctx, mapper);
//         }
//     }

//     public class DatabaseFixture : IDisposable
//     {
//         private readonly string _testDb = Path.Join(Directory.GetCurrentDirectory(), "unit-testing.db");
//         public DatabaseFixture()
//         {
//             if (File.Exists(_testDb))
//             {
//                 File.Delete(_testDb);
//             }

//             var ctx = DataContextFactory.GetDataContext();
//             ctx.Database.Migrate();

//             var dataQuery = new DataQuery();
//             dataQuery.GenerateDataAsync().Wait();

//             Seed.SeedSkills(ctx).Wait();
//             Seed.SeedUsers(ctx).Wait();
//             Seed.SeedLearningResources(ctx).Wait();
//             Seed.SeedUserProgressions(ctx).Wait();
//             Seed.SeedPosts(ctx).Wait();
//             Seed.SeedComments(ctx).Wait();
//         }

//         public void Dispose()
//         {
//             var testDb = Path.Join(Directory.GetCurrentDirectory(), "unit-testing.db");
//             File.Delete(testDb);
//         }
//     }

//     [CollectionDefinition("Database collection")]
//     public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
//     { }

//     [Collection("Database collection")]
//     public class BaseTestRepository
//     {
//         protected DataContext _ctx
//         {
//             get
//             {
//                 return DataContextFactory.GetDataContext();
//             }
//         }
//     }
// }