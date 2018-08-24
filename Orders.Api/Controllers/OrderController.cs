using Orders.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Orders.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController( IOrderService orderService )
        {
            _orderService = orderService;
        }

        /// <summary>
        /// get the menu and quantity
        /// </summary>
        /// <param name="order">input, must contain the dish type, entrée, side, drink and dessert, delimited by comma </param>
        /// <returns>string: returns the menu of period inputed</returns>
        public IHttpActionResult Get(string order)
        {
            try
            {
                string output = _orderService.ProcessOrder(order);
                return Ok(output);
            }
            catch
            {
                return InternalServerError(new Exception("something gone wrong!"));
            }
        }
    }
}