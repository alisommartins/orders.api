using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Service.Interfaces
{
    public interface IOrderService
    {
        string ProcessOrder(string order);
    }
}
