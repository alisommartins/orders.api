using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Service
{
    public abstract class Order
    {
        public string Output { get; set; }

        public void AddOrderError()
        {
            Output = string.IsNullOrEmpty(Output) ? "error" : string.Join(", ", Output, "error");
        }

        public void AddOrderDish(string dish)
        {
            Output = string.IsNullOrEmpty(Output) ? dish : string.Join(", ", Output, dish);
        }

        public abstract string Process();
    }
}
