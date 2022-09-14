using AutoMapper;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Services;
using backend.RemodelKing.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.RemodelKing.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PaymentsController: ControllerBase
{
    private readonly IPaymentService _businessService;
    private readonly IMapper _mapper;

    public PaymentsController(IPaymentService businessService, IMapper mapper)
    {
        _businessService = businessService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<PaymentResource>> GetAllAsync()
    {
        
        var businesses = await _businessService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(businesses);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

        var result = await _businessService.CreateAsync(payment);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);
        return Ok(paymentResource);
    }
}