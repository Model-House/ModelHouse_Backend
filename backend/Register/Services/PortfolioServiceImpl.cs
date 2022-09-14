using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class PortfolioServiceImpl: IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;
    public readonly IBusinessRepository _BusinessRepository;
    private readonly IUnitOfWork _unitOfWork;


    public PortfolioServiceImpl(IPortfolioRepository portfolioRepository, IUnitOfWork unitOfWork, IBusinessRepository businessRepository)
    {
        _portfolioRepository = portfolioRepository;
        _unitOfWork = unitOfWork;
        _BusinessRepository = businessRepository;
    }

    public async Task<IEnumerable<Portfolio>> ListAsync()
    {
        return await _portfolioRepository.ListAsync();
    }

    public async Task<PortfolioResponse> CreateAsync(Portfolio portfolio)
    {
        var business = await _BusinessRepository.FindByIdAsync(portfolio.BusinessId);
        if (business == null)
            return new PortfolioResponse($"Business dasent Async.");
        try
        {
            //Actions
            await _portfolioRepository.AddAsync(portfolio);
            await _unitOfWork.CompleteAsync();
            return new PortfolioResponse(portfolio);
        }
        catch (Exception e)
        {
            return new PortfolioResponse($"Failed to register a portfolio: {e.Message}");
        }
    }
    public async Task<PortfolioResponse> DeleteAsync(long id)
    {
        var existingCategory = await _portfolioRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new PortfolioResponse("BusinessProject not found.");
        try
        {
            _portfolioRepository.DeleteAsync(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new PortfolioResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new PortfolioResponse($"An error occurred while deleting the portfolio: {e.Message}");
        }
    }
    public async Task<PortfolioResponse> GetPortfolioById(long id)
    {
        try
        {
            var account = await _portfolioRepository.FindByIdAsync(id);
            return new PortfolioResponse(account);
        }
        catch(Exception e)
        {
            return new PortfolioResponse($"Failed to find a current user Portfolio: {e.Message}");
        }
    }
}