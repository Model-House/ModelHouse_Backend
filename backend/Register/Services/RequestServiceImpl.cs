using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.Register.Services;

public class RequestServiceImpl: IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestServiceImpl(IRequestRepository requestRepository, IUnitOfWork unitOfWork, IClientRepository clientRepository)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _requestRepository.ListAsync();
    }

    public async Task<RequestResponse> CreateAsync(Request request)
    {
        Console.WriteLine(request.ClientId);
        var client = await _clientRepository.FindByIdAsync(request.ClientId);
        if (client == null)
            return new RequestResponse($"Client dasent Async.");

        try
        {
            await _requestRepository.AddAsync(request);
            await _unitOfWork.CompleteAsync();

            return new RequestResponse(request);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while saving the category: {e.Message}");
        }
    }
}