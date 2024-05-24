using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Contract
{
    public interface IOrderLineRepository
    {

        Task<decimal> GetTotalSalesByProductId(int productId);
        Task<int> GetSoldProductCountByDateRange(DateTime startDate, DateTime endDate);

    }
}
