using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class CustomEntity
    {
        public CustomEntity()
        {
            Orders = new List<Order>();
            Customers = new List<Customer>();
            Employees = new List<Employee>();
        }
        public List<Order> Orders { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
