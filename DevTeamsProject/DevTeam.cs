using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public string TeamGoal { get; set; }
        public string TeamID { get; set; }
        public int NumberofTeamMembers { get; set; }

        public DevTeam() { }
        public DevTeam(string teamName, string teamGoal, string teamID, int numberOfTeamMembers)
        {
            teamName = TeamName;
            teamGoal  = TeamGoal;
            teamID = TeamID;
            numberOfTeamMembers  = NumberofTeamMembers;
        }
    }
}
