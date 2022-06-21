using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test2.Context;
using Test2.Dto;
using Test2.Exception;
using Test2.Models;

namespace Test2.Service.Impl
{
    public class OrderService : IOrderService
    {
        private readonly S22383DbContext _context;

        public OrderService(S22383DbContext context)
        {
            _context = context;
        }

        public async Task AddProductToOrder(int idOrder, List<ProductWithCommentDto> products)
        {
            if (products.Count == 0)
            {
                throw new BadRequestException("List of Product is empty.");
            }

            var order = await _context.ClientOrder.FirstAsync(o => o.IdClientOrder == idOrder);
            
            if (order == null)
            {
                throw new NotFoundException("Order doesn't exist.");
            }
            
            if (order.CompletionDate != null)
            {
                throw new BadRequestException("Order is completed.");
            }

            
            var productsFromDb = new List<Confectionery>();
            foreach (var product in products)
            {
                var temp = await _context.Confectionery.FirstAsync(c => c.IdConfectionery == product.IdConfectionery);
                if (temp == null)
                {
                    throw new BadRequestException($"Product with id: {product.IdConfectionery} doesn't exist.");
                }

                productsFromDb.Add(temp);
            }

            var confectioneries = products.Select(p => new ConfectioneryClientOrder()
            {
                Amount = p.Amount,
                ClientOrder = order,
                Confectionery = productsFromDb.Find(c => c.IdConfectionery == p.IdConfectionery),
                Comments = p.Comments,
                IdClientOrder = idOrder,
                IdConfectionery = p.IdConfectionery
            });

            foreach (var confectioneryClientOrder in confectioneries)
            {
                await _context.ConfectioneryClientOrder.AddAsync(confectioneryClientOrder);
            }
            
            
            await _context.SaveChangesAsync();
        }
    }
}