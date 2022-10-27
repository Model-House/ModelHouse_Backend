using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Repositories;
using ModelHouse.Profile.Domain.Services;
using ModelHouse.Profile.Domain.Services.Communication;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Shared.Domain.Repositories;

namespace ModelHouse.Profile.Services;

public class PostService: IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostService(IPostRepository postRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _postRepository.ListAsync();
    }

    public async Task<IEnumerable<Post>> ListByUserId(long id)
    {
        return await _postRepository.ListByUserId(id);
    }

    public async Task<PostResponse> CreateAsync(Post post)
    {
        var User = await _userRepository.FindByIdAsync(post.UserId);
        if (User == null)
            return new PostResponse("User is not exist");
        try
        {
            await _postRepository.AddAsync(post);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(post);
        }
        catch (Exception e)
        {
            return new PostResponse($"Failed to register a Project: {e.Message}");
        }
    }

    public async Task<PostResponse> DeleteAsync(long id)
    {
        var post_exist = await _postRepository.FindByIdAsync(id);
        if (post_exist == null)
            return new PostResponse("the Project is not existing");
        try
        {
            _postRepository.DeleteAsync(post_exist);
            await _unitOfWork.CompleteAsync();
            return new PostResponse(post_exist);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while deleting the Project: {e.Message}");
        }
    }

    public Task<PostResponse> UpdateAsync(long id, Post post)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Post>> GetPostByTitle(string title)
    {
        return await _postRepository.FindByTitleAsync(title);
    }
}