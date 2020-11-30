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
        public string TeamID { get; set; }
        public List<Developer> DevTeamMembers { get; set; } = new List<Developer>();

        public DevTeam() { }
        public DevTeam(string teamName, string teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
