using LearningCenter.API.Profile.Domain.Models;

namespace LearningCenter.API.Profile.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByUserId(long id);
    Task<OrderResponse> CreateAsync(Order order);
    Task<OrderResponse> DeleteAsync(long id);
    Task<OrderResponse> UpdateAsync(long id, Order order);
    Task<OrderResponse> GetOrderById(long id);
}