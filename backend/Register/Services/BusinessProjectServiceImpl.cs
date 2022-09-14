using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class BusinessProjectServiceImpl: IBusinessProjectService
{
    private readonly IBusinessProjectRepository _businessProjectRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBusinessRepository _businessRepository;

    public BusinessProjectServiceImpl(IBusinessProjectRepository businessProjectRepository, IUnitOfWork unitOfWork, IBusinessRepository businessRepository)
    {
        _businessProjectRepository = businessProjectRepository;
        _unitOfWork = unitOfWork;
        _businessRepository = businessRepository;
    }

    public async Task<IEnumerable<BusinessProject>> ListAsync()
    {
        return await _businessProjectRepository.ListAsync();
    }

    public async Task<BusinessProjectResponse> CreateAsync(BusinessProject businessProject)
    {
        var business = await _businessRepository.FindByIdAsync(businessProject.BusinessId);
        if (business == null)
            return new BusinessProjectResponse($"Business dasent Async.");

        try {
            await _businessProjectRepository.AddAsync(businessProject);
            await _unitOfWork.CompleteAsync();
            
            return new BusinessProjectResponse(businessProject);
        }
        catch (Exception e) {
            return new BusinessProjectResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<BusinessProjectResponse> DeleteAsync(int id)
    {
        var existingCategory = await _businessProjectRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new BusinessProjectResponse("BusinessProject not found.");
        try
        {
            _businessProjectRepository.DeleteAsync(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new BusinessProjectResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new BusinessProjectResponse($"An error occurred while deleting the business project: {e.Message}");
        }
    }

    public async Task<BusinessProjectResponse> GetBusinessProjectById(long id)
    {
        try
        {
            var account = await _businessProjectRepository.FindByIdAsync(id);
            return new BusinessProjectResponse(account);
        }
        catch(Exception e)
        {
            return new BusinessProjectResponse($"Failed to find a current user businessProject: {e.Message}");
        }
    }
}