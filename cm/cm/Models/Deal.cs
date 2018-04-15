using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class Deal : BaseAudit
    {
        public Deal(ApplicationUser applicationUser)
        {
            this.CreateAt = DateTime.UtcNow;
            this.CreateBy = applicationUser;
        }

        public int DealId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Deal Name")]
        public string DealName { get; set; }


        //assosiation with company
        [Display(Name = "Associate With Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Associate With Company")]
        public virtual Company Company { get; set; }
        

        [Display(Name = "Status")]
        public StatusDeal StatusDeal { get; set; }

        [Display(Name = "Expected Closing Date")]
        public DateTime? ExpectedClosingDate { get; set; }

        [Display(Name = "Deal Owner")]
        public string DealOwnerId { get; set; }
        public ApplicationUser DealOwner { get; set; }

        [Display(Name = "Deal Value")]
        [Column(TypeName = "Money")]
        public decimal DealValue { get; set; } = 0m;

        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(200)]
        [Display(Name = "Tags")]
        public string Tag { get; set; }

        [Display(Name = "Won?")]
        public bool? IsWon { get; set; } = false;
        

    }
}
