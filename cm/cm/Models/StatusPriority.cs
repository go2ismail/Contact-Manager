using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Models
{
    public class StatusPriority
    {
        public int StatusPriorityId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Priority")]
        public string StatusPriorityName { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Code")]
        public string ColorCode { get; set; } = "#00FF00";
    }

    public static class StatusPriorityInit
    {
        public static List<StatusPriority> GetAll()
        {
            List<StatusPriority> all = new List<StatusPriority>
            {
                new StatusPriority(){StatusPriorityName = "High", ColorCode = "#00FF00"},
                new StatusPriority(){StatusPriorityName = "Low", ColorCode = "#00FF00"}
            };

            return all;
        }
    }
}
