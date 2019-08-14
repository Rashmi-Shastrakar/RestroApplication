using RestroAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Class
{
    public class DominosRestro : Restro
    {
        public DominosRestro()
        {
            
            SetTables();
            SetItems();
        }
        
        public void SetTables()
        {
            Tables.Add(new TableModel { TableId = 1, IsAvailable = true });
            Tables.Add(new TableModel { TableId = 2, IsAvailable = true });
            Tables.Add(new TableModel { TableId = 3, IsAvailable = true });
        }
        public void SetItems()
        {
            Items.Add(new ItemModel { ItemId = 1, ItemName = "veg_pizza", Price = 100, IsAvailable = true });
            Items.Add(new ItemModel { ItemId = 2, ItemName = "burger_pizza", Price = 150, IsAvailable = true });
            Items.Add(new ItemModel { ItemId = 3, ItemName = "Non-Veg_pizza", Price = 200, IsAvailable = true });
            Items.Add(new ItemModel { ItemId = 4, ItemName = "Cheese_pizza", Price = 200, IsAvailable = true });
        }
        

    }
}
