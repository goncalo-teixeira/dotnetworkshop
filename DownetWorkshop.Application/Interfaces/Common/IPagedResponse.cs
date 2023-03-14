using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Application.Interfaces.Common
{
    public interface IPagedResponse<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
