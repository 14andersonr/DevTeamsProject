using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public bool HasPluralSightAccess { get; set; }

        public Developer() { }
        public Developer(string name, string iDNumber, bool hasPluralSightAccess)
        {
            Name = name;
            IDNumber  = iDNumber;
            HasPluralSightAccess  = hasPluralSightAccess;
        }
    }
}
