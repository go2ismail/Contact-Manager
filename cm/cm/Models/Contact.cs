using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class Contact : BaseAudit
    {
        public Contact()
        {

        }

        public Contact(ApplicationUser applicationUser)
        {
            this.CreateAt = DateTime.UtcNow;
            this.CreateBy = applicationUser;
        }

        public int ContactId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [StringLength(20)]
        [Display(Name = "Title")]
        public string Title { get; set; }



        //link to company
        [Display(Name = "Associate With Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Associate With Company")]
        public virtual Company Company { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [StringLength(200)]
        [Display(Name = "Tags")]
        public string Tag { get; set; }

        //contact info
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [StringLength(20)]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [StringLength(20)]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [StringLength(20)]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        //address
        [StringLength(100)]
        [Display(Name = "Mailing Street")]
        public string MailingStreet { get; set; }
        [StringLength(50)]
        [Display(Name = "Mailing City")]
        public string MailingCity { get; set; }
        [StringLength(100)]
        [Display(Name = "Mailing State")]
        public string MailingState { get; set; }
        [StringLength(100)]
        [Display(Name = "Mailing Country")]
        public string MailingCountry { get; set; }
        [StringLength(20)]
        [Display(Name = "Mailing Zip Code")]
        public string MailingZipCode { get; set; }
        
    }
}
