using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Service.Model
{
    public enum NightDishesEnum
    {
        steak = 1,
        potato = 2,
        wine = 3,
        cake = 4
    }

    public class NightOrder : Order
    {
        public NightOrder()
        {
            Dishes = new List<int>();
        }

        public List<int> Dishes { get; set; }

        public override string Process()
        {
            List<NightDishesEnum> askedList = new List<NightDishesEnum>();

            foreach (var dish in Dishes.OrderBy(a => a))
            {
                NightDishesEnum currentOrder = (NightDishesEnum)dish;

                if ((currentOrder != NightDishesEnum.potato && askedList.Any(a => a.Equals(currentOrder))) || !Enum.IsDefined(typeof(NightDishesEnum), currentOrder))
                {
                    base.AddOrderError();
                    return base.Output;
                }

                if (!askedList.Contains(currentOrder))
                {
                    if (currentOrder.Equals(NightDishesEnum.potato))
                    {
                        int totalPotatoes = Dishes.Where(a => a.Equals((int)NightDishesEnum.potato)).Count();

                        if (totalPotatoes > 1)
                        {
                            base.AddOrderDish($"{currentOrder.ToString()}(x{totalPotatoes})");
                        }
                        else
                        {
                            base.AddOrderDish(currentOrder.ToString());
                        }
                        askedList.Add(currentOrder);
                    }
                    else
                    {
                        base.AddOrderDish(currentOrder.ToString());
                        askedList.Add(currentOrder);
                    }
                }
            }

            return base.Output;
        }
    }
}
