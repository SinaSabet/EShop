using EShop.Domain.Common;
using EShop.Domain.Entities.Orders;
using EShop.Domain.Entities.Products;

namespace EShop.Domain.Entities.OrderLines
{
    public class OrderLine : BaseEntity
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
