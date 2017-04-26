using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ListInterventionsHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;

        public ListInterventionsHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);

        }

        public IList<string> Get_District_MaxCost_MaxHour_ForManager(string userId)
        {
            var repos = new UserRepository(context);
            var rows = repos.GetAllForUser(userId);
            List<string> list = new List<string>();
            foreach (var row in rows)
            {
                list.Add(row.District.ToString());
                list.Add(row.MaximumCost.ToString());
                list.Add(row.MaximumHours.ToString());
            }
            return list;
        }
        public IList<Interventions> GetInterventions(string userid)
        {
            var repos = new InterventionsRepository(context);
            var rows = repos.GetAllInterventions();
            List<Interventions> list = new List<Interventions>();
            foreach (var row in rows)
            {
                list.Add(row);

            }
            return list;
        }

        public IList<Interventions> ListOfProposedInterventions(string userid)
        {
            List<Interventions> interlist = new List<Interventions>();
            interlist = GetInterventions(userid).ToList();

            List<string> ManagerInfo = new List<string>();
            ManagerInfo = Get_District_MaxCost_MaxHour_ForManager(userid).ToList();

            string Dis = ManagerInfo.ElementAt(0);
            string maxihcost = ManagerInfo.ElementAt(1);
            string maxihour = ManagerInfo.ElementAt(2);
            Users manager = new Users();
            manager.District = Convert.ToInt32(Dis);
            manager.MaximumCost = Convert.ToInt32(maxihcost);
            manager.MaximumHours = Convert.ToDecimal(maxihour);
            var ManageruserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            List<Interventions> proposedinterlist = new List<Interventions>();

            for (int i = 0; i <= interlist.Count-1; i++)
            {
                {
                    if (manager.MaximumHours >= interlist[i].InterventionHour && manager.MaximumCost >= interlist[i].InterventionCost
                        && ManageruserId == interlist[i].UserId)
                    {
                        proposedinterlist.Add(interlist[i]);
                    }
                }
            }
                        return proposedinterlist;
         }

      }

}

    
    

