using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEyesAbrarov.Data
{
    public static class DbAccess
    {
        public delegate void NewItemAddDelegate();

        public static event NewItemAddDelegate NewItemAddEvent;

        public static List<Agent> GetAgents() => DBContext.context.Agent.ToList();

        public static void AddAgent(Agent agent)
        {
            if(agent.ID == 0)
            {
                DBContext.context.Agent.Add(agent);
            }
            DBContext.context.SaveChanges();
            NewItemAddEvent?.Invoke();
        }

        public static void DeleteAgent(Agent agent)
        {
            DBContext.context.Agent.Remove(agent);
            DBContext.context.SaveChanges();
            NewItemAddEvent?.Invoke();
        }
        

    }
}
