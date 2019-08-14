using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestroAssignment.Class;
using RestroAssignment.Interface;

namespace RestroAssignment
{
    class Program
    {
        IRestro Dominos = null;
        IRestro Kfc = null;

        Program(IRestro Dominos, IRestro Kfc)
        {
            this.Dominos = Dominos;
            this.Kfc = Kfc;
        }

        static void Main(string[] args)
        {
            Program program = new Program(new DominosRestro(), new KFCRestro());
            program.StartProgram();
            Console.ReadKey();
        }

        private void ChooseYourRole(IRestro restro)
        {
            while (true)
            {
                Console.WriteLine("\n 1. Customer \n 2. Admin \n 3. Change Restaurant");
                Console.Write("Select Option   : ");
                string innerchoice = Console.ReadLine();
                Console.WriteLine("------------------------------------");
                switch (innerchoice)
                {
                    case "1":
                        Customer customer = new Customer(Guid.NewGuid().GetHashCode(), restro);
                        restro.RegisterCustomer(customer);
                        customer.CustomerOrder();
                        break;

                    case "2":
                        AdminRestro admin = new AdminRestro(restro);
                        admin.OptionsToAdmin();
                        break;

                    case "3":
                        ChooseYourRestro();
                        break;

                    default:
                        Console.WriteLine("Enter Valid Option");
                        break;

                }
            }

        }
        private void ChooseYourRestro()
        {
            string choice = "";
            do
            {
                IRestro restro = null;
                Console.WriteLine("\n 1.Dominos \n 2.KFC");
                Console.Write("Choose Restro   : ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("************************Welcome to Dominos***********************");
                        restro = Dominos;
                        break;
                    case "2":
                        Console.WriteLine("************************Welcome to KFC***********************");
                        restro = Kfc;
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Option");
                        break;
                }
                if (restro != null)
                {
                    ChooseYourRole(restro);

                }

                Console.WriteLine("Do you want to Continue (y/n) ?");
                choice = Console.ReadLine();
            } while (choice.Equals("y",StringComparison.OrdinalIgnoreCase));
        }

        private void StartProgram()
        {
            while (true)
            {
                ChooseYourRestro();
            }
        }
    }
}
