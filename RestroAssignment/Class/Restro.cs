using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using RestroAssignment.Interface;
using RestroAssignment.Models;

namespace RestroAssignment.Class
{
    public class Restro : IRestro
    {
        public int RestroId { get; set; }
        public List<TableModel> Tables = new List<TableModel>();
        public List<ItemModel> Items = new List<ItemModel>();
        public Dictionary<int, string> optionList = new Dictionary<int, string>();
        public List<CustomerOrderModel> customerOrderModelsList = new List<CustomerOrderModel>();
        public List<Customer> customersList = new List<Customer>();
        public List<ItemsWithQuantityModel> customerOrderedItemsWithQuantityRestro = new List<ItemsWithQuantityModel>();
        
        public void ShowAvailableTables(bool isTableAvailable)
        {
            Console.WriteLine("Available Tables   :");
            Console.WriteLine("--------------------------------");
            ConsoleTable table = new ConsoleTable("TableId", "Availability");
            List<TableModel> sortedItems = Tables.Where(x => x.IsAvailable == isTableAvailable).ToList<TableModel>();
            foreach (var tablesdata in sortedItems)
            {
                table.AddRow(tablesdata.TableId, tablesdata.IsAvailable);
            }
            table.Write(Format.Alternative);


        }
        public void ShowAvailableItems(bool isItemAvailable)
        {
            Console.WriteLine();
            Console.WriteLine("Available Items   :");
            Console.WriteLine("--------------------------------");
            ConsoleTable table = new ConsoleTable("ItemId", "ItemName", "Price", "Availability");


            List<ItemModel> sortedItems = Items.Where(x => x.IsAvailable == isItemAvailable).ToList<ItemModel>();
            foreach (var itemsdata in sortedItems)
            {
                table.AddRow(itemsdata.ItemId, itemsdata.ItemName, itemsdata.Price, itemsdata.IsAvailable);
            }
            table.Write(Format.Alternative);

        }


        public void BookTable(int tableId)
        {
            TableModel selectedTable = Tables.Where(x => x.TableId == tableId).FirstOrDefault();
            if (selectedTable != null && selectedTable.IsAvailable)
            {
                selectedTable.IsAvailable = false;
                Console.WriteLine($"Table with Tableid {selectedTable.TableId} is Booked for You.");
            }
            else
                Console.WriteLine("Sorry, Table is already Booked. ");

        }
        public void OrderItem(int orderId, int itemid, int itemquantity)
        {
            ItemModel selecteditem = Items.Where(x => x.ItemId == itemid && x.IsAvailable).FirstOrDefault();

            if (selecteditem == null)
            {
                Console.WriteLine("Wrong ItemId ,Please Select Valid ItemId");
            }
            else
            {
                ItemsWithQuantityModel itemsWithQuantity = new ItemsWithQuantityModel();
                itemsWithQuantity.ItemModel = selecteditem;
                itemsWithQuantity.Quantity = itemquantity;
                CustomerOrderModel customerOrder = new CustomerOrderModel();
                customerOrder.OrderId = orderId;
                customerOrder.orderedItemsWithQuantity.Add(itemsWithQuantity);
                //customerOrderedItemsWithQuantityRestro.Add(itemsWithQuantity);
                //customerOrder.orderedItemsWithQuantity = customerOrderedItemsWithQuantityRestro; //initalize 

                CustomerOrderModel existingOrder = customerOrderModelsList.Where(x => x.OrderId == orderId).FirstOrDefault();
                if (existingOrder == null)
                {
                    customerOrderModelsList.Add(customerOrder);
                }
                else
                {
                    existingOrder.orderedItemsWithQuantity.Add(itemsWithQuantity);
                }
            }
        }
        public void ShowCustomerOrderedItems(int orderId)
        {
            Console.WriteLine();
            CustomerOrderModel customerOrder = customerOrderModelsList.Where(x => x.OrderId == orderId).FirstOrDefault();
            Console.WriteLine("Your Order Details are :");
            Console.WriteLine("-------------------------------------------------------------");
            ConsoleTable table = new ConsoleTable("ItemId", "ItemName", "Price", "Quantity");

            foreach (var items in customerOrder.orderedItemsWithQuantity)
            {
                table.AddRow(items.ItemModel.ItemId,items.ItemModel.ItemName,items.ItemModel.Price,items.Quantity);
            }
            table.Write(Format.Alternative);

        }
        public int GetCustomerBill(int orderId)
        {
            CustomerOrderModel customerOrder = customerOrderModelsList.Where(x => x.OrderId == orderId).FirstOrDefault();
            var bill = 0;
            ConsoleTable table = new ConsoleTable("ItemId", "ItemName", "Price", "Quantity", "Amount");
           foreach (var items in customerOrder.orderedItemsWithQuantity)
            {
                bill += items.ItemModel.Price * items.Quantity;
                table.AddRow(items.ItemModel.ItemId, items.ItemModel.ItemName, items.ItemModel.Price, items.Quantity, items.ItemModel.Price* items.Quantity);
            }
            table.Write(Format.Alternative);
            return bill;
        }

        public void RegisterCustomer(Customer customer)
        {
            customersList.Add(customer);
        }
        public void ShowCustomerVisited()
        {
            Console.WriteLine("Details of Customer Visited");
            Console.WriteLine("-------------------------------------------------");
            ConsoleTable table = new ConsoleTable("CustomerId", "CustomerName", "TableId", "Bill");
            foreach (var customerDetails in customersList)
            {
                table.AddRow(customerDetails.CustomerId, customerDetails.CustomerName, customerDetails.TableId, customerDetails.Bill);
            }
            table.Write(Format.Alternative);
        }

        public void ReleseTable(int tableId)
        {
            Tables.Where(table => table.TableId == tableId).FirstOrDefault().IsAvailable = true;
        }
    }
}
