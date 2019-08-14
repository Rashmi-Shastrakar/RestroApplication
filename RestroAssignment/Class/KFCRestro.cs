using RestroAssignment.Interface;
using RestroAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Class
{
    class KFCRestro : Restro
    {
        public KFCRestro()
        {          
            SetTables();
            SetItems();
        }
        
        public void SetTables()
        {
            Tables.Add(new TableModel { TableId = 1, IsAvailable = true });
            Tables.Add(new TableModel { TableId = 2, IsAvailable = true });
            Tables.Add(new TableModel { TableId = 3, IsAvailable = true });
            Tables.Add(new TableModel { TableId = 4, IsAvailable = true });
        }
        public void SetItems()
        {
            Items.Add(new ItemModel { ItemId = 1, ItemName = "Fried-Chicken", Price = 200, IsAvailable = true });
            Items.Add(new ItemModel { ItemId = 2, ItemName = "Non-burger", Price = 150, IsAvailable = true });
            Items.Add(new ItemModel { ItemId = 3, ItemName = "Crispy-Chicken", Price = 260, IsAvailable = true });
        }
    }
}
