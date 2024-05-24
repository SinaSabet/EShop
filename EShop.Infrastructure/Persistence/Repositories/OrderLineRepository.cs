using EShop.Domain.Contract;
using EShop.Domain.Contract.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Persistence.Repositories
{
    public class OrderLineRepository(IAppDbContext appDbContext) : IOrderLineRepository
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

    

        public async Task<int> GetSoldProductCountByDateRange(DateTime startDate, DateTime endDate)
        {
           return await _appDbContext.OrderLines.Include(x=>x.Order)
                .AsNoTracking ()
           .Where(ol => ol.Order.Date >= startDate && ol.Order.Date <= endDate)
           .SumAsync(ol => ol.Quantity);
        }

        public async Task<decimal> GetTotalSalesByProductId(int productId)
        {
            DateTime endDate = DateTime.Now.Date; // تاریخ کنونی
            DateTime startDate = endDate.AddDays(-6); // هفت روز قبل

            return await _appDbContext.OrderLines.Include(x=>x.Order)
              .AsNoTracking()
              .Where(ol => ol.ProductId == productId && ol.Order.Date >= startDate && ol.Order.Date <= endDate)
              .SumAsync(ol => ol.Price);

           

        }

        
    }
}
