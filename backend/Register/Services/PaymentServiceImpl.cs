using backend.Register.Domain.Repositories;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Repositories;
using backend.RemodelKing.Domain.Services;
using backend.RemodelKing.Domain.Services.Communication;
using backend.Shared.Domain.Repositories;

namespace backend.RemodelKing.Services;

public class PaymentServiceImpl: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IBusinessRepository _businessRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentServiceImpl(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IBusinessRepository businessRepository)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
        _businessRepository = businessRepository;
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<PaymentResponse> CreateAsync(Payment payment)
    {
        var businessExists = await _businessRepository.FindByIdAsync(payment.BusinessId);
        if (businessExists == null)
            return new PaymentResponse("Business doesn't exist");
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(payment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"Error while creating payments: {e.Message}");
        }
    }
}