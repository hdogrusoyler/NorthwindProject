using System;

namespace EntityLayer
{
    public class Entity
    {
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ShipName { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
