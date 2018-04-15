using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class Todo : BaseAudit
    {
        public Todo(ApplicationUser applicationUser)
        {
            this.CreateAt = DateTime.UtcNow;
            this.CreateBy = applicationUser;
        }

        public int TodoId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Todo Name")]
        public string TodoName { get; set; }

        [Display(Name = "Complete the Todo before")]
        public DateTime? TodoCompleteDate { get; set; }

        [Display(Name = "Priority")]
        public StatusPriority StatusPriority { get; set; }

        [StringLength(200)]
        [Display(Name = "Tags")]
        public string Tag { get; set; }

        //association with company
        [Display(Name = "Associate With Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Associate With Company")]
        public Company Company { get; set; }
        
        
    }
}
