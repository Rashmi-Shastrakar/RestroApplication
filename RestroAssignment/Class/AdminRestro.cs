using RestroAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestroAssignment.Class
{
    class AdminRestro
    {
        IRestro restro=null;
        public AdminRestro(IRestro restro)
        {
            this.restro = restro;
        }
        public void OptionsToAdmin()
        {
            int choice = ShowAdminMenu();
            switch (choice)
            {
                case 1:
                    restro.ShowAvailableTables(true);
                    break;

                case 2:
                    restro.ShowAvailableItems(true);
                    break;

                case 3:
                    restro.ShowCustomerVisited();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Option");
                    break;
            }
        }

        private int ShowAdminMenu()
        {
            Console.WriteLine("Welcome Admin");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("1. Show All table");
            Console.WriteLine("2.Show All Menu");
            Console.WriteLine("3.Show All Customer Details");
            Console.WriteLine("4.Exit");
            Console.Write("Enter your choice  : ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
