using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services.Communication;
using backend.Security.Authorization.Handlers.Interfaces;
using backend.Security.Domain.Models;
using backend.Security.Domain.Repositories;
using backend.Security.Domain.Services;
using backend.Security.Domain.Services.Communication;
using backend.Security.Exceptions;
using backend.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;
namespace backend.Security.Services;

public class UserService : IUserService
{
    private readonly IBusinessProfileRepository _userRepository;
    private readonly IClientProfileRepository _clientProfileRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;


    public UserService(IBusinessProfileRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper, IClientProfileRepository clientProfileRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
        _clientProfileRepository = clientProfileRepository;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        //Console.WriteLine($"User: {user.Id}, {user.FirstName}, {user.LastName}, {user.Username}, {user.PasswordHash}");
        
        // Validate 
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        { 
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }
        
        Console.WriteLine("Authentication successful. About to generate token");
        // Authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        //Console.WriteLine($"Response: {response.Id}, {response.FirstName}, {response.LastName}, {response.Username}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }
    
    public async Task<Business> GetByIdAsync(long id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        // Validate if Username is already taken
        if (_userRepository.ExistsByEmail(request.Email)) 
            throw new AppException($"Email: '{request.Email}' is already taken");
        
        // Map Request to User Object
        var user = _mapper.Map<Business>(request);
        
        // Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Save User
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<RegisterResponse>(user);
            return response;
        }
        catch (Exception e)
        {
            throw new AppException($"An Error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(long id, UpdateRequest request)
    {
        var user = GetById(id);
        //var userWithUsername = await _userRepository.FindByUsernameAsync(request.Username);

        // Validate if user is changing username and it is already taken
        //if (userWithUsername != null && user.Id != userWithUsername.Id)
           // throw new AppException($"Username '{request.Username}' is already taken");
        
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
    
    public async Task DeleteAsync(long id)
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
    private Business GetById(long id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
    
    
    
    
    
    // CLIENTS
    
    
    
    
    
    public async Task<AuthenticateResponse> AuthenticateClient(AuthenticateRequest request)
    {
        var user = await _clientProfileRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        //Console.WriteLine($"User: {user.Id}, {user.FirstName}, {user.LastName}, {user.Username}, {user.PasswordHash}");
        
        // Validate 
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        { 
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }
        
        Console.WriteLine("Authentication successful. About to generate token");
        // Authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        //Console.WriteLine($"Response: {response.Id}, {response.FirstName}, {response.LastName}, {response.Username}");
        response.Token = _jwtHandler.GenerateTokenClient(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<Client>> ListAsyncClient()
    {
        return await _clientProfileRepository.ListAsync();
    }
    
    public async Task<Client> GetByIdAsyncClient(long id)
    {
        var user = await _clientProfileRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<RegisterClientResponse> RegisterAsyncClient(RegisterClientRequest request)
    {
        // Validate if Username is already taken
        if (_clientProfileRepository.ExistsByEmail(request.Email)) 
            throw new AppException($"Email: '{request.Email}' is already taken");
        
        // Map Request to User Object
        var user = _mapper.Map<Client>(request);
        
        // Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Save User
        try
        {
            await _clientProfileRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<RegisterClientResponse>(user);
            return response;
        }
        catch (Exception e)
        {
            throw new AppException($"An Error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsyncClient(long id, UpdateRequest request)
    {
        var user = getByIdClient(id);
        //var userWithUsername = await _userRepository.FindByUsernameAsync(request.Username);

        // Validate if user is changing username and it is already taken
        //if (userWithUsername != null && user.Id != userWithUsername.Id)
           // throw new AppException($"Username '{request.Username}' is already taken");
        
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Map Request to User Object
        _mapper.Map(request, user);
        try
        {
            _clientProfileRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
        
    }
    
    public async Task DeleteAsyncClient(long id)
    {
        var user = getByIdClient(id);
        try
        {
            _clientProfileRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }
    
    // Helper Methods
    private Client getByIdClient(long id)
    {
        var user = _clientProfileRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}