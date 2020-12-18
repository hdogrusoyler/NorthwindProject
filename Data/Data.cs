using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class Data
    {

    }

    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind");
        }
    }

    public class OrderDal
    {
        private DataContext dbContext = new DataContext(); 
        public Order Get(string id)
        {
            return dbContext.Orders.Include(i => i.Customer).Include(i => i.Employee).FirstOrDefault(i => i.CustomerID == id);
        }
        public List<Order> GetList()
        {
            return dbContext.Orders.Include(i => i.Customer).Include(i => i.Employee).ToList();
        }
        public int Add(Order order)
        {
            dbContext.Add(order);
            return dbContext.SaveChanges();
        }
        public int Update(Order order)
        {
            dbContext.Update(order);
            return dbContext.SaveChanges();
        }
        public int Delete(Order order)
        {
            dbContext.Remove(order);
            return dbContext.SaveChanges();
        }

        public List<Customer> GetCustomerList()
        {
            return dbContext.Customers.ToList();
        }

        public List<Employee> GetEmployeeList()
        {
            return dbContext.Employees.ToList();
        }
    }

}
