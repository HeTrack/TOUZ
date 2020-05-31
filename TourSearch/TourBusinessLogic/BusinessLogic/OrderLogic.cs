using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourBusinessLogic.Enums;
using TourBusinessLogic.ViewModel;

namespace TourBusinessLogic.BusinessLogic
{
   public static class OrderLogic
    {
        public static IOrderedEnumerable<Tour> OrderBy(this IEnumerable<Tour> items, SearchOrder? order)
        {
            switch (order ?? SearchOrder.byName)
            {
                case SearchOrder.byName:
                    return items.OrderBy(item => item.Hotel.Name);
                case SearchOrder.byPrice:
                    return items.OrderBy(item => item.FullPrice);
                case SearchOrder.byPriceDesc:
                    return items.OrderByDescending(item => item.FullPrice);
                case SearchOrder.byDate:
                    return items.OrderBy(item => item.FromDate);
                case SearchOrder.byDateDesc:
                    return items.OrderByDescending(item => item.FromDate);
                default:
                    throw new ArgumentException($"Значение {order} не поддерживается(не реализовано)", "order");
            }
        }
    }
}