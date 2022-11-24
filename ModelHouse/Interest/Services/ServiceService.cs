using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Interest.Domain.Services.Communication;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Shared.Domain.Repositories;

namespace LearningCenter.API.Interest.Services;

public class ServiceService: IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Service>> ListAsync()
    {
        return await _serviceRepository.ListAsync();
    }

    public async Task<IEnumerable<Service>> ListByUserId(long id)
    {
        return await _serviceRepository.ListByUserId(id);
    }

    public async Task<ServiceResponse> SaveAsync(Service service)
    {
        var existingUser = await _userRepository.FindByIdAsync(service.UserId);
        if (existingUser == null)
            return new ServiceResponse("Invalid user");
        try
        {
            await _serviceRepository.AddAsync(service);
            await _unitOfWork.CompleteAsync();

            return new ServiceResponse(service);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while saving the service: {e.Message}");
        }
    }

    public async Task<ServiceResponse> UpdateAsync(int id, Service service)
    {
        var existingArea = await _serviceRepository.FindByIdAsync(id);
        if (existingArea == null)
            return new ServiceResponse("Service not found");
        var existingUser = await _userRepository.FindByIdAsync(service.UserId);
        if (existingUser == null)
            return new ServiceResponse("Invalid user");
        existingArea.Check = service.Check;
        try
        {
            _serviceRepository.Update(existingArea);
            await _unitOfWork.CompleteAsync();

            return new ServiceResponse(existingArea);
        }
        catch (Exception e)
        {
            return new ServiceResponse($"An error occurred while saving the service: {e.Message}");
        }
    }
}