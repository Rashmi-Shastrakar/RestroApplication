using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestroAssignment.Class;

namespace RestroAssignment.Interface
{
    public interface IRestro
    {
        void ShowAvailableTables(bool TableAvailable);
        void ShowAvailableItems(bool itemAvailable);
        void BookTable(int tableId);
        void OrderItem(int orderId, int itemid, int itemquantity);
        void ShowCustomerOrderedItems(int orderId);
        int GetCustomerBill(int orderId);
        void RegisterCustomer(Customer customer);
        void ShowCustomerVisited();
        void ReleseTable(int tableId);
    }
}
