using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Context;
using Test2.Dto;
using Test2.Models;

namespace Test2.Service.Impl
{
    public class ClientService: IClientService
    {
        private readonly S22383DbContext _context;

        public ClientService(S22383DbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientDto>> FindAll()
        {
            return _context.Client.Select(c => new ClientDto()
            {
                IdClient = c.IdClient,
                Orders = _context.ClientOrder
                    .Where(o => o.Client.IdClient == c.IdClient)
                    .Select(o => new OrderDto()
                    {
                        Products = _context
                            .ConfectioneryClientOrder
                            .Where(pr => pr.IdClientOrder == o.IdClientOrder)
                            .Select(pr => new ConfectioneryOrderDto()
                            {
                                Amount = pr.Amount,
                                Name = _context.Confectionery.First(c => c.IdConfectionery == pr.IdConfectionery).Name,
                                Price = _context.Confectionery.First(c => c.IdConfectionery == pr.IdConfectionery).PricePerOne
                            }).ToList(),
                        TotalAmount = _context
                            .ConfectioneryClientOrder
                            .Where(pr => pr.IdClientOrder == o.IdClientOrder)
                            .Select(pr => pr.Amount)
                            .Sum()
                    }).ToList()
            }).ToList();
        }
    }
}