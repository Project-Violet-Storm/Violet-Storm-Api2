using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using violet.storm.Domain.Catalog;

namespace violet.storm.Domain.Orders {
    public class Order {
        public int id {get; set;}
        public List<OrderItem> Items {get; set;}
        public DateTime CreatedDate {get; set;}
        public decimal TotalPrice => Items.Sum(i =>i.Price);
    }

    public class OrderItem
    {
        public int Id {get; set;}
        public Item Item {get; set; }
        public int Quantity {get; set; }
        public decimal Price => Item.Price * Quantity;
    }
}