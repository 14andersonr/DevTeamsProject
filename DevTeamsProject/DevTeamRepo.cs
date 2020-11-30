using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddDevTeamToList(DevTeam devTeam)
        {
            _devTeams.Add(devTeam); //Fields have underscores. Properties don't
        }

        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }

        //DevTeam Update
        public bool UpdateExistingDevTeams(string originalID, DevTeam newID)
        {
            //Find the content
            DevTeam oldID = GetDevTeamByID(originalID);

            //Update the content
            if (oldID != null)
            {
                oldID.TeamName = newID.TeamName;
                oldID.TeamID = newID.TeamID;
                oldID.DevTeamMembers = newID.DevTeamMembers;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveDevTeamFromList(string iD)
        {
            DevTeam devTeam = GetDevTeamByID(iD);

            if (devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeam);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)

        public DevTeam GetDevTeamByID(string iD)
        {
            foreach (DevTeam devTeam in _devTeams)
            {
                if (devTeam.TeamID.ToLower() == iD.ToLower())
                {
                    return devTeam;
                }
            }

            return null;
        }

    }
}
