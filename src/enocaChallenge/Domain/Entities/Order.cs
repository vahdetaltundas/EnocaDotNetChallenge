using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order:Entity
    {

        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Company? Company { get; set; }

        public virtual Product? Product { get; set; }
    }
}
