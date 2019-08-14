using RestroAssignment.Events;
using RestroAssignment.Interface;
using RestroAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Class
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TableId { get; set; }

        public int Bill { get; set; }

        Dictionary<int, string> Optionsmenu = new Dictionary<int, string>();

        IRestro Restro = null;
        RestroEvents RestroEvents = null;

        public Customer(int id, IRestro restro)
        {
            CustomerId = id;
            this.Restro = restro;
            RestroEvents = new RestroEvents();
        }

        public void CustomerOrder()
        {

            SetCustomerName();
            SelectTables();
            SelectItems();
            ShowOrderedItems();
            ShowBills();
            
        }
        private void SetCustomerName()
        {
            Console.WriteLine("Enter Customer Name :");
            CustomerName = Console.ReadLine();
        }
        private void SelectTables()
        {
            Restro.ShowAvailableTables(true);
            Console.WriteLine("Select Table :");
            TableId = Convert.ToInt32(Console.ReadLine());
            Restro.BookTable(TableId);
        }
        private void SelectItems()
        {           
            string choice = "";
            do
            {
                Restro.ShowAvailableItems(true);
                Console.WriteLine("Select Items :");
                int selectItem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Quantity :");
                int itemQuantity2 = Convert.ToInt32(Console.ReadLine());

                Restro.OrderItem(CustomerId, selectItem, itemQuantity2);

                Console.WriteLine("Do you want to order something (Y/N)  ? : ");
                choice = Console.ReadLine();

            } while (choice.Equals("y", StringComparison.OrdinalIgnoreCase));
        }
        private void ShowOrderedItems()
        {
            Restro.ShowCustomerOrderedItems(CustomerId);
        }
        private void ShowBills()
        {
            Console.WriteLine();
            Console.WriteLine("********************************************************");
            Console.WriteLine("*\t\t Your Bill                           *");
            Console.WriteLine("********************************************************");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\t Id :{CustomerId}     \t\tName  :{CustomerName} ");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\t TableId  :{TableId} \t\tOrderId  :{CustomerId}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\t\t Your Order Details");
            Bill = Restro.GetCustomerBill(CustomerId);
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"\t\t Total Bill \t\t     :   {Bill}");
            Console.WriteLine("-------------------------------------------------------------");

            string message = RestroEvents.SendMessage(CustomerName);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-----------------------------------------------------------");

        }
    }
}
