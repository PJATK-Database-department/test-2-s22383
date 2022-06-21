using System.Collections.Generic;
using System.Threading.Tasks;
using Test2.Dto;

namespace Test2.Service
{
    public interface IOrderService
    {
        Task AddProductToOrder(int idOrder, List<ProductWithCommentDto> products);
        
    }
}