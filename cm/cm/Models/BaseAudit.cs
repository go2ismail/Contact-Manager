using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class BaseAudit
    {
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        
        //application user
        public string CreateById { get; set; }
        public ApplicationUser CreateBy { get; set; }
    }
}
