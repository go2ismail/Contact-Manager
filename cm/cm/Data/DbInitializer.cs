using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cm.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //look for any status
            if (context.StatusDeal.Any())
            {
                return; //database already seeded
            }

            foreach (var item in Models.StatusDealInit.GetAll())
            {
                context.StatusDeal.Add(item);
            }
            context.SaveChanges();

            foreach (var item in Models.StatusPriorityInit.GetAll())
            {
                context.StatusPriority.Add(item);
            }
            context.SaveChanges();
        }
    }
}
