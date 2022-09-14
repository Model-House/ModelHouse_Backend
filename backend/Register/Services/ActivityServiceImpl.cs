using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class ActivityServiceImpl: IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivityServiceImpl(IActivityRepository activityRepository, IUnitOfWork unitOfWork, IPortfolioRepository portfolioRepository)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
        _portfolioRepository = portfolioRepository;
    }

    public async Task<IEnumerable<Activity>> ListAsync()
    {
        return await _activityRepository.ListAsync();
    }

    public async Task<ActivityResponse> CreateAsync(Activity activity)
    {
        var portfolio = await _portfolioRepository.FindByIdAsync(activity.PortfolioId);
        if (portfolio == null)
            return new ActivityResponse($"Portfolio dasent Async.");

        try
        {
            //Actions
            await _activityRepository.AddAsync(activity);
            await _unitOfWork.CompleteAsync();
            return new ActivityResponse(activity);
        }
        catch (Exception e)
        {
            return new ActivityResponse($"Failed to register an activity: {e.Message}");
        }
    }

    public async Task<ActivityResponse> UpdateAsync(long id, Activity activity)
    {
        var existingActivity = await _activityRepository.FindByIdAsync(id);

        if (existingActivity == null)
            return new ActivityResponse("Activity not found.");
        
        var portfolio = await _portfolioRepository.FindByIdAsync(activity.PortfolioId);
        if (portfolio == null)
            return new ActivityResponse($"Portfolio dasent Async.");

        existingActivity.Description = activity.Description;
        existingActivity.Title = activity.Title;
        existingActivity.StartDate = activity.StartDate;
        existingActivity.FinishDate = activity.FinishDate;
        existingActivity.PortfolioId = activity.PortfolioId;
        try
        {
            _activityRepository.UpdateAsync(existingActivity);
            await _unitOfWork.CompleteAsync();
            
            return new ActivityResponse(existingActivity);
        }
        catch (Exception e)
        {
            return new ActivityResponse($"An error occurred while updating the Activity: {e.Message}");
        }
    }

    public async Task<ActivityResponse> DeleteAsync(long id)
    {
        var activity = await _activityRepository.FindByIdAsync(id);

        if (activity == null)
            return new ActivityResponse("Activity not found.");
        try
        {
            _activityRepository.DeleteAsync(activity);
            await _unitOfWork.CompleteAsync();

            return new ActivityResponse(activity);
        }
        catch (Exception e)
        {
            return new ActivityResponse($"An error occurred while deleting the Activity: {e.Message}");
        }
    }
}