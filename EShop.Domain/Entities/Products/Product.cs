using EShop.Domain.Common;
using EShop.Domain.Entities.OrderLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }


        public Product(string title,int price)
        {
            Title=title;
            Price=price;
        }
    }
}
