using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Service.Model
{
    public enum MorningDishesEnum
    {
        eggs = 1,
        toast = 2,
        coffee = 3
    }

    public class MorningOrder : Order
    {
        public MorningOrder()
        {
            Dishes = new List<int>();
        }

        public List<int> Dishes { get; set; }

        public override string Process()
        {
            List<MorningDishesEnum> askedList = new List<MorningDishesEnum>();

            foreach (var dish in Dishes.OrderBy(a => a))
            {
                MorningDishesEnum currentOrder = (MorningDishesEnum)dish;

                if (( currentOrder != MorningDishesEnum.coffee && askedList.Any(a => a.Equals(currentOrder))) || !Enum.IsDefined(typeof(MorningDishesEnum), currentOrder))
                {
                    base.AddOrderError();
                    return base.Output;
                }

                if (!askedList.Contains(currentOrder))
                {
                    if (currentOrder.Equals(MorningDishesEnum.coffee))
                    {
                        int totalCoffes = Dishes.Where(a => a.Equals((int)MorningDishesEnum.coffee)).Count();

                        if (totalCoffes > 1)
                        {
                            base.AddOrderDish($"{currentOrder.ToString()}(x{totalCoffes})");
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
