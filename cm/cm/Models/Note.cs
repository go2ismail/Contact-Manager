using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class Note : BaseAudit
    {
        public Note()
        {

        }

        public Note(ApplicationUser applicationUser)
        {
            this.CreateAt = DateTime.UtcNow;
            this.CreateBy = applicationUser;
        }

        public int NoteId { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Notes")]
        public string NoteName { get; set; }

        //association with company
        [Display(Name = "Associate With Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Associate With Company")]
        public Company Company { get; set; }
        
        
    }
}
