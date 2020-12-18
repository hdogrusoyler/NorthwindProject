using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Business
    {
    }

    public class OrderManager
    {
        private OrderDal orderDal;
        public OrderManager()
        {
            orderDal = new OrderDal();
        }

        public Order GetById(string orderId)
        {
            return orderDal.Get(orderId);
        }

        public List<Order> GetAll()
        {
            return orderDal.GetList();
        }

        public int Add(Order order)
        {
            return orderDal.Add(order);
        }

        public int Update(Order order)
        {
            return orderDal.Update(order);
        }

        public int Delete(Order order)
        {
            return orderDal.Delete(order);
        }

        public List<Customer> GetCustomerAll()
        {
            return orderDal.GetCustomerList();
        }

        public List<Employee> GetEmployeeAll()
        {
            return orderDal.GetEmployeeList();
        }
    }

}
