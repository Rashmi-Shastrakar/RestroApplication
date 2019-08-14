using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Models
{
    public  class ItemModel
    {
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
