using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class StatusDeal
    {
        public int StatusDealId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Status")]
        public string StatusDealName { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Weight value must be between 0 and 100")]
        [Display(Name = "Status Deal Weight (0 - 100)")]
        public int Weight { get; set; } = 0;


    }

    public static class StatusDealInit
    {
        public static List<StatusDeal> GetAll()
        {
            List<StatusDeal> all = new List<StatusDeal>
            {
                new StatusDeal{StatusDealName = "Cold", Weight = 10},
                new StatusDeal{StatusDealName = "Warm", Weight = 50},
                new StatusDeal{StatusDealName = "Hot", Weight = 80},
                new StatusDeal{StatusDealName = "Won", Weight = 100},
                new StatusDeal{StatusDealName = "Lost", Weight = 0}
            };

            return all;
        }
    }
}
