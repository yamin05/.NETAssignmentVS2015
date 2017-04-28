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

        private IList<string> Get_District_MaxCost_MaxHour_ForManager(string userId)
        {
            var repos = new UserRepository(context);
            var row = repos.GetAllForUser(userId);
            List<string> list = new List<string>();
            list.Add(row.District.ToString());
            list.Add(row.MaximumCost.ToString());
            list.Add(row.MaximumHours.ToString());
            return list;
        }
       
        public IList<ListInterventionForManager> GetInterventions(string userid)
        {
            var repos = new ListInterventionForManagerRepository(context);
            var rows = repos.GetAllIntervention(userid);
            List<ListInterventionForManager> list = new List<ListInterventionForManager>();
            foreach (var row in rows)
            {
                list.Add(row);

            }
            return list;
        }

        public IList<ListInterventions> GetInterventionsForUser()
        {
            var repos = new ListInterventionsRepository(context);
            var list = repos.GetAllInterventionsForUser(Utils.getInstance.GetCurrentUserId());
            return list;
        }

        public IList<ListInterventions> GetInterventionsForClient (string clientid)
        {
            var repos = new ListInterventionsRepository(context);
            var list = repos.GetAllInterventionsForClient(Utils.getInstance.GetCurrentUserId(), Convert.ToInt32(clientid));
            return list;
        }

        public IList<ListInterventions> GetInterventionsForClientInSameDistrict(string clientid)
        {
            var repos = new ListInterventionsRepository(context);
            var list = repos.GetAllInterventionsForClientInSameDistrict(Convert.ToInt32(clientid));
            return list;
        }

        public Dictionary<string, int> GetPossibleStatusUpdateForIntervention(string status)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            if (Status.Proposed.ToString().Equals(status))
            {
                list.Add(Status.Approved.ToString(), (int)Status.Approved);
                list.Add(Status.Cancelled.ToString(), (int)Status.Cancelled);
            }
            else if (Status.Approved.ToString().Equals(status))
            {
                list.Add(Status.Completed.ToString(), (int)Status.Completed);
                list.Add(Status.Cancelled.ToString(), (int)Status.Cancelled);
            }
            return list;
        }

        public IList<ListInterventionForManager> ListOfProposedInterventions(string userid)
        {
            List<ListInterventionForManager> interlist = new List<ListInterventionForManager>();
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
            var ManageruserId = HttpContext.Current.User.Identity.GetUserId();
            List<ListInterventionForManager> proposedinterlist = new List<ListInterventionForManager>();

            for (int i = 0; i <= interlist.Count-1; i++)
            {
                {
                    if (manager.MaximumHours >= interlist[i].InterventionHours && manager.MaximumCost >= interlist[i].InterventionCost
                        
                        )
                    {
                        proposedinterlist.Add(interlist[i]);
                    }
                }
            }
                        return proposedinterlist;
         }

      }

}

    
    

