using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Register.Resources;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class BusinessServiceImpl: IBusinessService
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IUnitOfWork _unitOfWork;


    public BusinessServiceImpl(IBusinessRepository businessRepository, IUnitOfWork unitOfWork)
    {
        _businessRepository = businessRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _businessRepository.ListAsync();
    }

    public async Task<BusinessResponse> CreateAsync(Business business)
    {
        try
        {
            //Validations
            //if (business.Password != business.ConfirmPassword)
              //  return new BusinessResponse("Different passwords was received"); 
            //Actions
            await _businessRepository.AddAsync(business);
            await _unitOfWork.CompleteAsync();
            return new BusinessResponse(business);
        }
        catch (Exception e)
        {
            return new BusinessResponse($"Failed to register a business: {e.Message}");
        }
    }
    public async Task<BusinessResponse> GetAccount(string email)
    {
        try
        {
            var currentUser = await _businessRepository.FindByEmailAsync(email);
            return new BusinessResponse(currentUser);
        }
        catch (Exception e)
        {
            return new BusinessResponse($"Failed to find a current user business: {e.Message}");
        }
    }
    public async Task<BusinessResponse> GetAccountById(long id)
    {
        try
        {
            var currentUser = await _businessRepository.FindByIdAsync(id);
            return new BusinessResponse(currentUser);
        }
        catch (Exception e)
        {
            return new BusinessResponse($"Failed to find a current user business: {e.Message}");
        }
    }

    public async Task<BusinessResponse> UpdateAsync(long id, Business business)
    {
        var existingBusiness = await _businessRepository.FindByIdAsync(id);
        if (existingBusiness == null)
            return new BusinessResponse("Business already exists");
        existingBusiness.Address = business.Address;
        existingBusiness.Days = business.Days;
        existingBusiness.Description = business.Description;
        existingBusiness.Email = business.Email;
        existingBusiness.Img = business.Img;
        existingBusiness.Name = business.Name;
        existingBusiness.Phone = business.Phone;
        existingBusiness.Score = business.Score;
        existingBusiness.WebSite = business.WebSite;
        try
        {
             _businessRepository.Update(existingBusiness);
             await _unitOfWork.CompleteAsync();
             return new BusinessResponse(existingBusiness);
        }
        catch (Exception e)
        {
            return new BusinessResponse($"Failed to updating the business: {e.Message}");
        }
    }
}