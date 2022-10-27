using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Shared.Domain.Repositories;

namespace ModelHouse.Interest.Services;

public class AreaService: IAreaService
{
    private readonly IAreaRepository _areaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public AreaService(IAreaRepository areaRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _areaRepository = areaRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Area>> ListAsync()
    {
        return await _areaRepository.ListAsync();
    }
    public async Task<IEnumerable<Area>> ListByUserId(long id)
    {
        return await _areaRepository.ListByUserId(id);
    }
    public async Task<AreaResponse> SaveAsync(Area area)
    {
        var existingUser = await _userRepository.FindByIdAsync(area.UserId);
        if (existingUser == null)
            return new AreaResponse("Invalid user");
        Console.WriteLine("error antes de try");
        try
        {
            Console.WriteLine("error en el try");
            await _areaRepository.AddAsync(area);
            await _unitOfWork.CompleteAsync();

            return new AreaResponse(area);
        }
        catch (Exception e)
        {
            return new AreaResponse($"An error occurred while saving the area: {e.Message}");
        }
    }

    public async Task<AreaResponse> UpdateAsync(long id, Area area)
    {
        var existingArea = await _areaRepository.FindByIdAsync(id);
        if (existingArea == null)
            return new AreaResponse("Area not found");
        var existingUser = await _userRepository.FindByIdAsync(area.UserId);
        if (existingUser == null)
            return new AreaResponse("Invalid user");
        
        existingArea.Check = area.Check;
        try
        {
            _areaRepository.Update(existingArea);
            await _unitOfWork.CompleteAsync();

            return new AreaResponse(existingArea);
        }
        catch (Exception e)
        {
            return new AreaResponse($"An error occurred while saving the area: {e.Message}");
        }
    }
}