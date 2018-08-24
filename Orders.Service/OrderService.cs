using Orders.Service.Interfaces;
using Orders.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Service
{
    public class OrderService : IOrderService
    {
        public string ProcessOrder(string order)
        {
            if(string.IsNullOrEmpty(order))
            {
                return "error";
            }

            List<string> splitedOrder = order.Trim()
                                             .ToUpper()
                                             .Split(',')
                                             .Where(w => !string.IsNullOrEmpty(w))
                                             .ToList();

            if(splitedOrder.Count() <= 1)
            {
                return "error";
            }

            if(IsInvalidInput(splitedOrder.Skip(1).ToList()))
            {
                return "error";
            }
           
            string periodOrder = splitedOrder.FirstOrDefault();

            if (periodOrder.Equals("MORNING"))
            {
                MorningOrder morningOrder = new MorningOrder();

                foreach (var item in splitedOrder.Where(w => w != periodOrder))
                {
                    morningOrder.Dishes.Add(Convert.ToInt32(item));
                }

               return morningOrder.Process();
            }
            else if(periodOrder.Equals("NIGHT"))
            {
                NightOrder nightOrder = new NightOrder();

                foreach (var item in splitedOrder.Where(w => w != periodOrder))
                {
                    nightOrder.Dishes.Add(Convert.ToInt32(item));
                }

                return nightOrder.Process();
            }

            return "error";
        }

        private bool IsInvalidInput(List<string> input)
        {
           return  input.Select(s =>
                  {
                      int i;
                      return Int32.TryParse(s, out i) ? i : -1;
                  }).ToList().Any(a => a.Equals(-1));
        }
    }
}
