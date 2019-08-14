using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Models
{
    public class CustomerOrderModel
    {
        public CustomerOrderModel()
        {
            orderedItemsWithQuantity=new List<ItemsWithQuantityModel>();
        }
        public int OrderId { get; set; }
        public List<ItemsWithQuantityModel> orderedItemsWithQuantity { get; set; }

        //List<ItemModel> orederedItems = new List<ItemModel>();
    }

    public class ItemsWithQuantityModel
    {
        public ItemModel ItemModel { get; set; }
        public int Quantity { get; set; }
    }
}
