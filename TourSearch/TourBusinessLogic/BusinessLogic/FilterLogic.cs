using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TourBusinessLogic.BusinessLogic
{
   public class FilterLogic<T>
    {
        public FilterLogic(Func<T, bool> f)
        {
            this.f = f;
        }
        readonly Func<T, bool> f;

        public bool IsSatisfiedBy(T item) => f(item);

        public static FilterLogic<T> operator |(FilterLogic<T> spec1, FilterLogic<T> spec2)
            => spec1 == null ? spec2 : spec2 == null ? spec1 : new FilterLogic<T>(item => spec1.IsSatisfiedBy(item) || spec2.IsSatisfiedBy(item));
        public static FilterLogic<T> operator &(FilterLogic<T> spec1, FilterLogic<T> spec2)
            => spec1 == null ? spec2 : spec2 == null ? spec1 : new FilterLogic<T>(item => spec1.IsSatisfiedBy(item) && spec2.IsSatisfiedBy(item));
        public static FilterLogic<T> operator !(FilterLogic<T> spec)
            => spec == null ? None : new FilterLogic<T>(item => !spec.IsSatisfiedBy(item));

        public static FilterLogic<T> All = new FilterLogic<T>(item => true);
        public static FilterLogic<T> None = new FilterLogic<T>(item => false);
    }

    public static class FilterFilterLogicHlp
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> items, FilterLogic<T> specification)
            => specification != null ? items.Where(item => specification.IsSatisfiedBy(item)) : items;
    }

}