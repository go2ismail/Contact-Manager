using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class Company : BaseAudit
    {
        public Company()
        {

        }

        public Company(ApplicationUser applicationUser)
        {
            this.CreateAt = DateTime.UtcNow;
            this.CreateBy = applicationUser;
        }

        public int CompanyId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Company Name")]
        public string CompanyName { get; set; }
        [StringLength(100)]
        [Display(Name = "Website")]
        public string Website { get; set; }
        [StringLength(20)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [StringLength(20)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [StringLength(200)]
        [Display(Name = "Tags")]
        public string Tag { get; set; }
        [StringLength(200)]
        [Display(Name = "Photo Url")]
        public string PhotoUrl { get; set; }

        //billing address
        [StringLength(100)]
        [Display(Name = "Billing Street")]
        public string BillingAddressStreet { get; set; }
        [StringLength(50)]
        [Display(Name = "Billing City")]
        public string BillingAddressCity { get; set; }
        [StringLength(100)]
        [Display(Name = "Billing State")]
        public string BillingState { get; set; }
        [StringLength(100)]
        [Display(Name = "Billing Country")]
        public string BillingCountry { get; set; }
        [StringLength(20)]
        [Display(Name = "Billing Zip Code")]
        public string BillingZipCode { get; set; }

        [Display(Name = "Copy Billing Address to Shipping Address")]
        public bool IsCopyBillingAddressToShippingAddress { get; set; } = true;

        //shipping address
        [StringLength(100)]
        [Display(Name = "Shipping Street")]
        public string ShippingAddressStreet { get; set; }
        [StringLength(50)]
        [Display(Name = "Shipping City")]
        public string ShippingAddressCity { get; set; }
        [StringLength(100)]
        [Display(Name = "Shipping State")]
        public string ShippingState { get; set; }
        [StringLength(100)]
        [Display(Name = "Shipping Country")]
        public string ShippingCountry { get; set; }
        [StringLength(20)]
        [Display(Name = "Shipping Zip Code")]
        public string ShippingZipCode { get; set; }

        //company will have many contacts
        [Display(Name = "Contacts")]
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        //company will have many deals
        [Display(Name = "Deals")]
        public ICollection<Deal> Deals { get; set; } = new HashSet<Deal>();

        //will have many Todos
        [Display(Name = "Todos")]
        public ICollection<Todo> Todos { get; set; } = new HashSet<Todo>();

        //will have many notes
        [Display(Name = "Notes")]
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    }
}
