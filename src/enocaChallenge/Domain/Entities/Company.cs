using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company:Entity
    {
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime OrderAllowStart { get; set; }
        public DateTime OrderPermitEnd { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}
