using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Common
{
    public abstract class EntityBase
    {
        public DateTime Created_Date { get; set; }
    }
}
