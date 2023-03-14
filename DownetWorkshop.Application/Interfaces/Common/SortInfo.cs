using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Application.Interfaces.Common
{
    public class SortInfo<T> where T : class
    {
        public SortInfo(bool? ascending, Expression<Func<T, object>> key)
        {
            Ascending = ascending;
            Key = key;
        }

        public bool? Ascending { get; set; }

        public Expression<Func<T, object>> Key { get; set; }
    }
}
