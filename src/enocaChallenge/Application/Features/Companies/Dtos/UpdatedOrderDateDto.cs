using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Dtos
{
    public class UpdatedOrderDateDto
    {
        public int Id { get; set; }
        public DateTime OrderAllowStart { get; set; }
        public DateTime OrderPermitEnd { get; set; }
    }
}
