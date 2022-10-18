using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Entities
{
    public class StockEntity : EntityBase
    {
        [Key]
        public int Stock_Id { get; set; }
        public int Company_Code { get; set; }
        public decimal Stock_Price { get; set; }
    }
}
