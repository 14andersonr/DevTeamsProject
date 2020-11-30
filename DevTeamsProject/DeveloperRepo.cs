using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();


        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer); //Fields have underscores. Properties don't
        }

        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(string originalID, Developer newID)
        {
            //Find the content
            Developer oldID = GetDeveloperByID(originalID);

            //Update the content
            if (oldID != null)
            {
                oldID.Name  = newID.Name;
                oldID.IDNumber  = newID.IDNumber;
                oldID.HasPluralSightAccess  = newID.HasPluralSightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveDeveloperFromList(string iD)
        {
            Developer developer = GetDeveloperByID(iD);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if (initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID(string iD)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.IDNumber == iD)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}
