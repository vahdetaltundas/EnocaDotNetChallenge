using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Dtos
{
    public class CreatedOrderDto
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
