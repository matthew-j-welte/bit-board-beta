using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Models.DTOs;
using AutoMapper;
using BitBoard.Web.Interfaces.Base;
using BitBoard.Web.Interfaces.Services;

namespace BitBoard.Web.Services
{
    public class UserService : IUserService
    {
        IBaseRepository<User> userRepository;
        IBaseRepository<Post> postRepository;
        IBaseRepository<Comment> commentRepository;
        IBaseRepository<LearningResource> resourceRepository;
        IMapper mapper;

        public UserService(IBaseRepository<User> userRepository, IBaseRepository<Post> postRepository, IBaseRepository<Comment> commentRepository, IBaseRepository<LearningResource> resourceRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
            this.resourceRepository = resourceRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return mapper.Map<IEnumerable<UserDto>>(await userRepository.GetAllAsync());
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            return mapper.Map<UserDto>(await userRepository.GetAsync(id));
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<UserDto>(users.Where(x => x.UserName == username).SingleOrDefault());
        }

        public async Task<UserModel> GetUserModelAsync(string userId)
        {
            var model = mapper.Map<UserModel>(await userRepository.GetAsync(userId));
            var postIds = model.Posts.Select(x => x.PostId);
            var posts = new List<PostDto>();
            foreach (var postId in postIds)
            {
                posts.Add(mapper.Map<PostDto>(await postRepository.GetAsync(postId)));
            }
            model.Posts = posts;

            var commentIds = model.Comments.Select(x => x.CommentId);
            var comments = new List<PostCommentDto>();
            foreach (var commentId in commentIds)
            {
                var comment = mapper.Map<PostCommentDto>(await commentRepository.GetAsync(commentId));
                comment.Post = mapper.Map<PostDto>(await postRepository.GetAsync(comment.Post.PostId));
                comments.Add(comment);
            }
            model.Comments = comments;

            return model;
        }

        public async Task<UserModel> UpsertUserAsync(UserModel user)
        {
            return mapper.Map<UserModel>(await userRepository.UpsertAsync(mapper.Map<User>(user)));
        }
    }
}