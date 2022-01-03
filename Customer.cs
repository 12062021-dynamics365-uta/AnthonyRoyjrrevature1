using System;
namespace P0_Anthony
{
    public class Customer
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }

        public Customer() { }

        public Customer(string userName, string password)
        {
            this.username = userName;
            this.password = password;
        }

        public Customer(int customerId, string firstName, string lastName, string userName, string eMail, string password)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = userName;
            this.eMail = eMail;
            this.password = password;
        }

        public Customer(string firstName, string lastName, string userName, string eMail, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = userName;
            this.eMail = eMail;
            this.password = password;
        }

    }
}
