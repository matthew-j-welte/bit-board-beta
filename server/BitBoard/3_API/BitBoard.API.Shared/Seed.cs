using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BitBoard.Domain.Learning.Models;
using BitBoard.Domain.Shared.Enums;
using BitBoard.Domain.Shared.Models;
using BitBoard.Domain.Shared.Repositories;

namespace BitBoard.API.Shared
{
    public class Seed
    {
        private List<User> users;
        private List<LearningResource> resources;
        private List<Post> posts;
        private List<Comment> comments;
        private List<Skill> skills;
        private const string RANDOM_800X600 = "https://source.unsplash.com/random/800x600";

        public Seed()
        {
            users = new List<User>();
            resources = new List<LearningResource>();
            posts = new List<Post>();
            comments = new List<Comment>();
            var currentDir = Directory.GetCurrentDirectory();
            var skillFile = Path.Combine(currentDir, "Static", "Skill.json");
            var json = System.IO.File.ReadAllText(skillFile);
            skills = System.Text.Json.JsonSerializer.Deserialize<List<Skill>>(json);
        }

        public async Task ClearData()
        {
            var userRepo = new BaseRepository<User>();
            var resourceRepo = new BaseRepository<LearningResource>();
            var postRepo = new BaseRepository<Post>();
            var commentRepo = new BaseRepository<Comment>();
            var skillRepo = new BaseRepository<Skill>();

            await userRepo.Clear();
            await resourceRepo.Clear();
            await postRepo.Clear();
            await commentRepo.Clear();
            await skillRepo.Clear();
        }

        public async Task GenerateRandomDataAsync()
        {
            for (int i = 0; i < GetModelCount("User"); i++)
            {
                users.Add(RandomUser());
            }
            for (int i = 0; i < GetModelCount("LearningResource"); i++)
            {
                resources.Add(RandomResource());
            }
            for (int i = 0; i < GetModelCount("Post"); i++)
            {
                posts.Add(RandomPost());
            }
            for (int i = 0; i < GetModelCount("Comment"); i++)
            {
                comments.Add(RandomComment());
            }

            var userRepo = new BaseRepository<User>();
            var resourceRepo = new BaseRepository<LearningResource>();
            var postRepo = new BaseRepository<Post>();
            var commentRepo = new BaseRepository<Comment>();
            var skillRepo = new BaseRepository<Skill>();

            foreach (var skill in skills)
            {
                await skillRepo.UpsertAsync(skill);
            }
            foreach (var comment in comments)
            {
                await commentRepo.UpsertAsync(FillCommentDependencies(comment));
            }
            foreach (var post in posts)
            {
                await postRepo.UpsertAsync(FillPostDependencies(post));
            }
            foreach (var resource in resources)
            {
                await resourceRepo.UpsertAsync(FillResourceDependencies(resource));
            }
            foreach (var user in users)
            {
                await userRepo.UpsertAsync(FillUserDependencies(user));
            }
        }

        private int RandomInt(int a, int b)
        {
            return new Random().Next(a, b);
        }

        private T RandomElement<T>(List<T> list)
        {
            return list[RandomInt(0, list.Count)];
        }

        private User RandomUser()
        {
            return new User
            {
                FirstName = LoremNET.Lorem.Words(1, true),
                LastName = LoremNET.Lorem.Words(1, true),
                Password = LoremNET.Lorem.Words(4),
                UserName = LoremNET.Lorem.Words(1, false),
                ImageUrl = "https://randomuser.me/api/portraits/men/" + RandomInt(1, 100) + ".jpg",
                YearsExperience = RandomInt(0, 50)
            };
        }

        private LearningResource RandomResource()
        {
            return new LearningResource
            {
                Title = LoremNET.Lorem.Words(1, 4),
                Description = LoremNET.Lorem.Paragraph(10, RandomInt(2, 6)),
                Viewers = RandomInt(1, 1000),
                Placeholder = RANDOM_800X600,
                ImageUrl = RANDOM_800X600,
                Type = new string[] { "Video", "Book", "Article" }[RandomInt(0, 3)]
            };
        }

        private Comment RandomComment()
        {
            return new Comment
            {
                Content = LoremNET.Lorem.Paragraph(10, RandomInt(1, 5))
            };
        }

        private Post RandomPost()
        {
            return new Post
            {
                Title = LoremNET.Lorem.Words(3, 5),
                Content = LoremNET.Lorem.Paragraph(10, 17, RandomInt(4, 7))
            };
        }

        private User FillUserDependencies(User user)
        {
            var userSkills = new List<UserSkill>();
            var skillCount = RandomInt(2, 7);
            for (int i = 0; i < skillCount; i++)
            {
                var skill = RandomElement<Skill>(skills);
                while (userSkills.Where(x => x.SkillId == skill.SkillId).Any())
                {
                    skill = RandomElement<Skill>(skills);
                }
                userSkills.Add(new UserSkill
                {
                    Level = RandomInt(1, 100),
                    ProgressPercent = RandomInt(1, 100),
                    SkillId = skill.SkillId,
                    Name = skill.Name
                });
            }
            user.UserSkills = userSkills;

            var resourceStates = new List<UserResourceProgression>();
            var resourceStateCount = RandomInt(2, 15);
            for (int i = 0; i < resourceStateCount; i++)
            {
                var resource = RandomElement<LearningResource>(resources);
                while (resourceStates.Where(x => x.LearningResourceId == resource.LearningResourceId).Any())
                {
                    resource = RandomElement<LearningResource>(resources);
                }
                resourceStates.Add(new UserResourceProgression
                {
                    LearningResourceId = resource.LearningResourceId,
                    LearningResourceName = resource.Title,
                    ProgressPercent = RandomInt(1, 100)
                });
            }
            user.UserResourceProgressions = resourceStates;

            var postRelationships = new List<UserPostRelationship>();
            var postRelationshipCount = RandomInt(5, 40);
            for (int i = 0; i < postRelationshipCount; i++)
            {
                var post = RandomElement<Post>(posts);
                while (postRelationships.Where(x => x.Post.PostId == post.PostId).Any())
                {
                    post = RandomElement<Post>(posts);
                }
                postRelationships.Add(new UserPostRelationship
                {
                    UserPostAction = new UserPostActionEnum[] { UserPostActionEnum.Authored, UserPostActionEnum.Liked, UserPostActionEnum.None, UserPostActionEnum.Reported }[RandomInt(0, 4)],
                    Post = new UserPost { PostId = post.PostId, Title = post.Title }
                });
            }
            user.UserPostRelationships = postRelationships;

            var authoredResources = new List<UserLearningResource>();
            var authoredResourceCount = RandomInt(1, 4);
            for (int i = 0; i < authoredResourceCount; i++)
            {
                var resource = RandomElement<LearningResource>(resources);
                while (authoredResources.Where(x => x.LearningResourceId == resource.LearningResourceId).Any())
                {
                    resource = RandomElement<LearningResource>(resources);
                }
                authoredResources.Add(new UserLearningResource
                {
                    LearningResourceId = resource.LearningResourceId,
                    LearningResourceName = resource.Title
                });
            }
            user.AuthoredResources = authoredResources;

            var authoredPosts = new List<UserPost>();
            var authoredPostCount = RandomInt(1, 8);
            for (int i = 0; i < authoredPostCount; i++)
            {
                var post = RandomElement<Post>(posts);
                while (authoredPosts.Where(x => x.PostId == post.PostId).Any())
                {
                    post = RandomElement<Post>(posts);
                }
                authoredPosts.Add(new UserPost
                {
                    PostId = post.PostId,
                    Title = post.Title
                });
            }
            user.Posts = authoredPosts;

            var authoredComments = new List<UserComment>();
            var authoredCommentCount = RandomInt(1, 10);
            for (int i = 0; i < authoredCommentCount; i++)
            {
                var comment = RandomElement<Comment>(comments);
                while (authoredComments.Where(x => x.CommentId == comment.CommentId).Any())
                {
                    comment = RandomElement<Comment>(comments);
                }
                authoredComments.Add(new UserComment
                {
                    CommentId = comment.CommentId,
                    PostId = comment.ParentPost.PostId,
                    PostTitle = comment.ParentPost.Title
                });
            }
            user.Comments = authoredComments;

            return user;
        }

        private LearningResource FillResourceDependencies(LearningResource resource)
        {
            var author = RandomElement<User>(users);
            resource.Author = new LearningResourceUser { UserId = author.UserId, Username = author.UserName };

            var resourcePosts = new List<Post>();
            var resourcePostCount = RandomInt(2, 5);
            for (int i = 0; i < resourcePostCount; i++)
            {
                var post = RandomElement<Post>(posts);
                while (resourcePosts.Where(x => x.PostId == post.PostId).Any())
                {
                    post = RandomElement<Post>(posts);
                }
                resourcePosts.Add(post);
            }
            resource.Posts = resourcePosts;

            var resourceSkills = new List<Skill>();
            var skillCount = RandomInt(1, 4);
            for (int i = 0; i < skillCount; i++)
            {
                var skill = RandomElement<Skill>(skills);
                while (resourceSkills.Where(x => x.SkillId == skill.SkillId).Any())
                {
                    skill = RandomElement<Skill>(skills);
                }
                resourceSkills.Add(skill);
            }
            resource.Skills = resourceSkills;
            return resource;
        }

        private Post FillPostDependencies(Post post)
        {
            var author = RandomElement<User>(users);
            post.User = new PostUser { UserId = author.UserId, Username = author.UserName };

            var resource = RandomElement<LearningResource>(resources);
            post.LearningResource = new PostLearningResource { LearningResourceId = resource.LearningResourceId, Title = resource.Title };

            var postComments = new List<PostComment>();
            var postCommentCount = RandomInt(1, 5);
            for (int i = 0; i < postCommentCount; i++)
            {
                var comment = RandomElement<Comment>(comments);
                while (postComments.Where(x => x.CommentId == comment.CommentId).Any())
                {
                    comment = RandomElement<Comment>(comments);
                }
                postComments.Add(new PostComment
                {
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    UserId = comment.Author.UserId,
                    Username = comment.Author.Username
                });
            }
            post.Comments = postComments;
            return post;
        }

        private Comment FillCommentDependencies(Comment comment)
        {
            var author = RandomElement<User>(users);
            comment.Author = new CommentUser { UserId = author.UserId, Username = author.UserName };

            var post = RandomElement<Post>(posts);
            comment.ParentPost = new CommentPost { PostId = post.PostId, Title = post.Title };
            return comment;
        }

        private int? GetModelCount(string ModelName)
        {
            return ParseSeedConfig().Where(x => x.Model == ModelName).Select(x => x.Count).First();
        }

        private List<QueryConfig> ParseSeedConfig()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var configFile = Path.Combine(currentDir, "Data", "Seeding", "Configuration.json");
            var json = System.IO.File.ReadAllText(configFile);
            return System.Text.Json.JsonSerializer.Deserialize<List<QueryConfig>>(json);
        }
    }

    public class QueryConfig
    {
        public string Model { get; set; }
        public int? Count { get; set; }
    }
}