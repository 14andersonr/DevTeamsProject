using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class ProgramUI
    {
        private readonly DeveloperRepo _DeveloperRepo = new DeveloperRepo();
        private readonly DevTeamRepo _DevTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedDevList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a new Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developers by Unique ID\n" +
                    "4. Update Existing Developers\n" +
                    "5. Delete Existing Developers\n\n" +
                    "6. Add a new DevTeam\n" +
                    "7. View All DevTeams\n" +
                    "8. View DevTeams by Unique ID\n" +
                    "9. Update Existing DevTeams\n" +
                    "10. Delete Existing DevTeams\n" +
                    "11. Add A Developer to an Existing DevTeam\n" +
                    "12. Remove A Developer From An Existing DevTeam\n\n" +
                    "13. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create Developer
                        AddNewDev();
                        break;
                    case "2":
                        //View All Developers
                        DisplayAllDevs();
                        break;
                    case "3":
                        //View by ID Developer
                        DisplayDevsByID();
                        break;
                    case "4":
                        //Update Existing Developer
                        UpdateExistingDev();
                        break;
                    case "5":
                        //Delete Existing Developer
                        DeleteExistingDev();
                        break;
                    case "6":
                        //Create Team
                        AddNewDevTeam();
                        break;
                    case "7":
                        //View All Teams
                        DisplayAllDevTeams();
                        break;
                    case "8":
                        //View by ID Team
                        DisplayDevTeamsByID();
                        break;
                    case "9":
                        //Update Existing Team
                        UpdateExistingDevTeam();
                        break;
                    case "10":
                        //Delete Existing Team
                        DeleteExistingDevTeam();
                        break;
                    case "11":
                        //Add Member to Existing Team
                        AddNewDevTeamMember();
                        break;
                    case "12":
                        //Remove Member From Existing Team
                        RemoveNewDevTeamMember();
                        break;
                    case "13":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewDev()
        {
            Console.Clear();
            Developer newDev = new Developer();

            //Name
            Console.WriteLine("Enter the name of the Developer:");
            newDev.Name = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Developer:");
            newDev.IDNumber = Console.ReadLine();

            //HasAccess
            Console.WriteLine("Does this Developer currently have access to PluralSight? Please answer 'y' or 'n'.");
            string hasAccessString = Console.ReadLine().ToLower();

            if (hasAccessString == "y")
            {
                newDev.HasPluralSightAccess = true;
            }
            else
            {
                newDev.HasPluralSightAccess = false;
            }

            _DeveloperRepo.AddDeveloperToList(newDev);
        }

        private void AddNewDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the name of the DevTeam:");
            newDevTeam.TeamName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the DevTeam:");
            newDevTeam.TeamID = Console.ReadLine();

            //Add to Team List
            DisplayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to add to this team.");
            
                string responseID = Console.ReadLine();
                Developer developer = _DeveloperRepo.GetDeveloperByID(responseID);
                newDevTeam.DevTeamMembers.Add(developer);

            _DevTeamRepo.AddDevTeamToList(newDevTeam);
        }

        private void AddNewDevTeamMember()
        {
            Console.Clear();

            DisplayAllDevTeams();

            Console.WriteLine("\nEnter the unique ID of the DevTeam you'd like to add a member to:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Call Object
            DevTeam newDevTeam = _DevTeamRepo.GetDevTeamByID(oldID);

            //Current Team Members
            DisplayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to add.");

            string responseID = Console.ReadLine();
            Developer developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Add(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.UpdateExistingDevTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("DevTeam succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update DevTeam.");
            }
        }

        private void RemoveNewDevTeamMember()
        {
            Console.Clear();

            DisplayAllDevTeams();

            Console.WriteLine("\nEnter the unique ID of the DevTeam you'd like to remove a member from:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Call Object
            DevTeam newDevTeam = _DevTeamRepo.GetDevTeamByID(oldID);

            //Current Team Members
            DisplayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to remove.");

            string responseID = Console.ReadLine();
            Developer developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Remove(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.UpdateExistingDevTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("DevTeam succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update DevTeam.");
            }
        }

        private void DisplayAllDevs()
        {
            Console.Clear();

            List<Developer> developerDirectory = _DeveloperRepo.GetDeveloperList();

            foreach (Developer developer in developerDirectory)
            {
                Console.WriteLine($"Name: {developer.Name},\n" +
                    $" ID Number: {developer.IDNumber}\n" +
                    $" PluralSight: {developer.HasPluralSightAccess}");
            }
        }

        private void DisplayAllDevTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _DevTeamRepo.GetDevTeamList();

            foreach (DevTeam devTeam in listOfTeams)
            {
                /*Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n" +
                    $" Members: {devTeam.DevTeamMembers}");*/

                Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n");
                    foreach (Developer dev in devTeam.DevTeamMembers) 
                        {
                            Console.WriteLine($"{dev.Name}, {dev.IDNumber}\n");
                        }
            }
        }

        private void DisplayDevsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Developer you'd like to see:");

            string iD = Console.ReadLine();

            Developer developer = _DeveloperRepo.GetDeveloperByID(iD);

            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.Name},\n" +
                    $"ID Number: {developer.IDNumber}\n" +
                    $"PluralSight Access: {developer.HasPluralSightAccess}");
            }
            else
            {
                Console.WriteLine("No Developer by that ID.");
            }
        }

        private void DisplayDevTeamsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the DevTeam you'd like to see:");

            string iD = Console.ReadLine();

            DevTeam devTeam = _DevTeamRepo.GetDevTeamByID(iD);

            if (devTeam != null)
            {
                Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n");
                foreach (Developer dev in devTeam.DevTeamMembers)
                {
                    Console.WriteLine($"{dev.Name}, {dev.IDNumber}\n");
                }
            }
            else
            {
                Console.WriteLine("No DevTeam by that ID.");
            }
        }

        private void UpdateExistingDev()
        {
            Console.Clear();

            DisplayAllDevs();

            Console.WriteLine("\nEnter the unique ID of the Developer you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Build a new object
            Developer newDev = new Developer();

            //Name
            Console.WriteLine("Enter the name of the Developer:");
            newDev.Name = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Developer:");
            newDev.IDNumber = Console.ReadLine();

            //HasAccess
            Console.WriteLine("Does this Developer currently have access to PluralSight? Please answer 'y' or 'n'.");
            string hasAccessString = Console.ReadLine().ToLower();

            if (hasAccessString == "y")
            {
                newDev.HasPluralSightAccess = true;
            }
            else
            {
                newDev.HasPluralSightAccess = false;
            }

            //Verify update worked
            bool updateWorked = _DeveloperRepo.UpdateExistingDeveloper(oldID, newDev);

            if (updateWorked)
            {
                Console.WriteLine("Developer succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }

        }

        private void UpdateExistingDevTeam()
        {
            Console.Clear();

            DisplayAllDevTeams();

            Console.WriteLine("\nEnter the unique ID of the DevTeam you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Build a new object
            DevTeam newDevTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the name of the DevTeam:");
            newDevTeam.TeamName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the DevTeam:");
            newDevTeam.TeamID = Console.ReadLine();

            //Current Team Members
            DisplayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to assign as the new Team Lead.");

            string responseID = Console.ReadLine();
            Developer developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Add(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.UpdateExistingDevTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("DevTeam succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update DevTeam.");
            }

        }

        private void DeleteExistingDev()
        {
            DisplayAllDevs();

            Console.WriteLine("\nEnter the unique ID of the Developer you'd like to remove");

            string input = Console.ReadLine();

            //Call the Delete Method
            bool wasDeleted = _DeveloperRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }


        }

        private void DeleteExistingDevTeam()
        {
            DisplayAllDevs();

            Console.WriteLine("\nEnter the unique ID of the DevTeam you'd like to remove");

            string input = Console.ReadLine();

            //Call the Delete Method
            bool wasDeleted = _DevTeamRepo.RemoveDevTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The DevTeam was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The DevTeam could not be deleted.");
            }


        }

        //Seed Method
        private void SeedDevList()
        {
            Developer paul = new Developer("Paul Giamatti", "1", true);
            Developer jerome = new Developer("Jerome McSwilly", "2", true);
            Developer lydia = new Developer("Lydia Stroul", "3", false);

            _DeveloperRepo.AddDeveloperToList(paul);
            _DeveloperRepo.AddDeveloperToList(jerome);
            _DeveloperRepo.AddDeveloperToList(lydia);

        }
    }
}
