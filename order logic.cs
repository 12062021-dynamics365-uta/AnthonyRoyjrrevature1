using System;
using System.Collections.Generic;

namespace P0_Anthony
{
    public class order_logic
    {
        List<Customer> customers;       //ALL CUSTOMERS
        List<Order> orders;             //ALL ORDERS
        List<Order> currentOrder = new List<Order>();
        List<Product> products;         //ALL PRODUCTS
        private Customer currentCustomer;
        DbConnection database = new DbConnection();
        Mapper mapper = new Mapper();

        //CONSTRUCTOR
        public order_logic()
        {
            customers = new List<Customer>();
            orders = new List<Order>();
            products = new List<Product>();
        }

        public order_logic(string userName, string userPW)
        {
            this.customers = new List<Customer>();
            Customer customers = new Customer(userName, userPW);
        }

        public List<Customer> GetAllPlayers()
        {
            List<Customer> customers = new List<Customer>();
            customers = this.database.GetAllCustomers();
            return customers;
        }

        public void Login(string userName, string password)
        {

            Customer c = customers.Where(c => c.username == userName && c.password == password).FirstOrDefault();
            c = this.currentCustomer;

            //if (c == null)
            //{
            //    Console.WriteLine("This user is not registered.\nWould you like to register?");
            //    Console.WriteLine("type register to begin registration");
            //    string register = Console.ReadLine();

            //    if (register.ToUpper() == "REGISTER")
            //    {
            //        int customerId = 12;
            //        Console.WriteLine("Please enter your first name");
            //        string firstName = Console.ReadLine();
            //        Console.WriteLine("Please enter your last name");
            //        string lastName = Console.ReadLine();
            //        Console.WriteLine("What is your email address?");
            //        string email = Console.ReadLine();
            //        Register(userName, password);
            //        database.AddCustomer(customerId, firstName, lastName, userName, email, password);
            //        Console.WriteLine($"Welcome, {firstName}! You are logged in as {userName}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Incorrect selection, please try again.");
            //    }
            //}
        } //REFACTOR THIS

        //public void Register(string userName, string password)
        //{
        //    Customer cust = new Customer(userName, password);
        //    this.currentCustomer = cust;
        //    customers.Add(cust);
        //}

        public void SelectStoreLocation(string storeSelection, bool locValSelect, int validLocation)
        {

            if (!locValSelect || validLocation < 1 || validLocation > 4)
            {
                Console.WriteLine("That is not a valid choice. Please choose again");
            }
            else
            {
                Console.WriteLine($"You Chose: " + (Locations)validLocation + ". If that the correct store? Yes or No");
            };
        }


        public void DisplayProducts()
        {
            database.ViewProducts();
        }

        public void EvaluateProductSelection(int validProduct)
        {

            if (validProduct >= 1 && validProduct <= 15)
            {
                orders = database.ProductToOrder(validProduct);

                Console.Clear();
                foreach (var item in orders)
                {
                    Console.WriteLine($"{item.productId}:{item.productName}\t{item.description}\t\t - {item.price}");
                    currentOrder.Add(item);
                }
            }
            else if (validProduct > 15)
            {
                Console.WriteLine("Invalid Selection");

            }
            LeaveProductSelection();

        }

        internal void LeaveProductSelection()
        {
            Console.WriteLine("Would you like to continue to order?");
            string orderMore = Console.ReadLine();

            if (orderMore.ToUpper() == "YES")
            {
                string productSelecting;
                bool productValSelect = false;
                int validProduct;
                DisplayProducts();
                Console.WriteLine("Please type the number of the product you want to select your product and press ENTER.");
                productSelecting = Console.ReadLine();
                productValSelect = Int32.TryParse(productSelecting, out validProduct);
                EvaluateProductSelection(validProduct);
            }
            else if (orderMore.ToUpper() == "NO")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }

        }

        internal void ViewCurrentCart()
        {
            int prod = 0;
            foreach (var product in currentOrder)
            {
                Console.WriteLine($"{prod++}:\t{product.productName}:\t {product.description}\t - ${product.price}");
            }
        }

        internal double CartTotal()
        {
            double totalCost;
            return totalCost = Math.Round(currentOrder.Sum(p => p.price), 2);
        }

        internal void RemoveItemFromCart()
        {
            bool productValSelect = false;
            int productsel;
            Console.Clear();
            Console.WriteLine("Select an item to remove:");
            ViewCurrentCart();
            string itemToRemove = Console.ReadLine();
            productValSelect = Int32.TryParse(itemToRemove, out productsel);

            if (productsel >= 0 && productsel <= currentOrder.Count - 1)
            {
                int prod = 0;
                currentOrder.RemoveAt(prod);
                Console.Clear();
                foreach (var product in currentOrder)
                {
                    Console.WriteLine($"{prod++}:\t{product.productName}:\t {product.description}\t - ${product.price}");
                }
            }
            else
            {
                Console.WriteLine("invalid selection");
                RemoveItemFromCart();
            }
            return;
        }

        internal void ProceedOrCancel()
        {
            bool readyToBuy = false;
            do
            {
                Console.WriteLine("Proceed to PURCHASE or CANCEL your order?");
                string purchaseOrCancel = Console.ReadLine();
                if (purchaseOrCancel.ToUpper() == "PURCHASE")
                {
                    Console.WriteLine("Thank You For Your Purchase!");
                    OrderToDatabase();
                    readyToBuy = !readyToBuy;
                }
                else if (purchaseOrCancel.ToUpper() == "CANCEL")
                {
                    foreach (var item in currentOrder)
                    {
                        currentOrder.Remove(item);
                    }
                    readyToBuy = !readyToBuy;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again");
                }
            } while (!readyToBuy);
        }

        internal void OrderToDatabase()
        {
            foreach (var prod in currentOrder)
            {
                int productId = prod.productId;
                string productName = prod.productName;
                string productDesc = prod.description;
                double price = prod.price;
                double total = this.CartTotal();
                database.OrderToDatabase(productId, productName, productDesc, price, total);
            }
        }

        internal void GetPastPurchases()
        {
            Console.WriteLine("Please enter your receipt total below:");
            string pastTotal = Console.ReadLine();
            double totalPast = Convert.ToDouble(pastTotal);
            database.GetPastPurchases(totalPast);
        }
}
