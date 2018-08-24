using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Service;
using Orders.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Test
{
    [TestClass]
    public class Order
    {
        private OrderService _orderService;

        [TestMethod]
        public void TestNightOrderFullMenu()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("night, 1, 2, 3, 4");
            Assert.AreEqual("steak, potato, wine, cake", output);
        }

        [TestMethod]
        public void TestNightOrderManyPotatoes()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("night, 1, 2, 2, 4");
            Assert.AreEqual("steak, potato(x2), cake", output);
        }

        [TestMethod]
        public void TestNightOrderInvalidMenu()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("night, 1, 2, 3, 5");
            Assert.AreEqual("steak, potato, wine, error", output);
        }

        [TestMethod]
        public void TestMorningOrderFullMenu()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("morning, 1, 2, 3");
            Assert.AreEqual("eggs, toast, coffee", output);
        }

        [TestMethod]
        public void TestMorningOrderManyCoffees()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("morning, 1, 2, 3, 3, 3");
            Assert.AreEqual("eggs, toast, coffee(x3)", output);
        }

        [TestMethod]
        public void TestMorningOrderInvalidMenu()
        {
            _orderService = new OrderService();

            string output = _orderService.ProcessOrder("morning, 1, 2, 3, 4");
            Assert.AreEqual("eggs, toast, coffee, error", output);
        }

    }
}
