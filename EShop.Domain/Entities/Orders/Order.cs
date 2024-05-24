using EShop.Domain.Common;
using EShop.Domain.Entities.OrderLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Entities.Orders
{
    public class Order:BaseEntity
    {
        public string Number { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public long TotalPrice { get; set; }
        public DateTime Date { get; set; }

    }
}
