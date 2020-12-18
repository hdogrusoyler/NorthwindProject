using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private OrderManager orderManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            orderManager = new OrderManager();
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            CustomEntity entity = new CustomEntity();
            entity.Orders = orderManager.GetAll();
            entity.Customers = orderManager.GetCustomerAll();
            entity.Employees = orderManager.GetEmployeeAll();
            return View(entity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class OrderController : Controller
    {
        private OrderManager orderManager;

        public OrderController()
        {
            orderManager = new OrderManager();
        }

        public JsonResult GetOrder(int id)
        {
            return Json(orderManager.GetById(id.ToString())); //JsonRequestBehavior.AllowGet
        }

        public JsonResult GetOrderList()
        {
            return Json(orderManager.GetAll().OrderByDescending(i => i.OrderID));
        }

        public IActionResult AddOrder(Order order)
        {
            return Json(orderManager.Add(order));
        }

        public JsonResult UpdateOrder(Order order)
        {
            return Json(orderManager.Update(order));
        }

        public JsonResult DeleteOrder(int orderID)
        {
            return Json(orderManager.Delete(new Order() { OrderID = orderID }));
        }

        public JsonResult GetCustomerList()
        {
            return Json(orderManager.GetCustomerAll());
        }

        public JsonResult GetEmployeeList()
        {
            return Json(orderManager.GetEmployeeAll());
        }
    }

}
