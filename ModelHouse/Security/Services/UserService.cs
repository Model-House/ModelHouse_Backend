using AutoMapper;
using ModelHouse.Security.Authorization.Handlers.Interfaces;
using ModelHouse.Security.Domain.Models;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Security.Domain.Services;
using ModelHouse.Security.Domain.Services.Communication;
using ModelHouse.Security.Exceptions;
using ModelHouse.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;
namespace ModelHouse.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;


    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.Username}, {user.Email}, {user.PasswordHash}");
        
        // Validate 
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }
        
        Console.WriteLine("Authentication successful. About to generate token");
        // Authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.Email}, {response.Username}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        // Validate if Username is already taken
        if (_userRepository.ExistsByEmail(request.Email))
            throw new AppException($"Email is already taken");
        
        // Map Request to User Object
        var user = _mapper.Map<User>(request);
        
        // Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Save User
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An Error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        var userWithUsername = await _userRepository.FindByEmailAsync(request.Email);

        // Validate if user is changing username and it is already taken
        if (userWithUsername != null && user.Id != userWithUsername.Id)
            throw new AppException($"Username '{request.Username}' is already taken");
        
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Map Request to User Object
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
        
    }
    
    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }
    
    // Helper Methods
    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}