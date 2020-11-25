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
        private DeveloperRepo _DeveloperRepo = new DeveloperRepo();

        // Method that runs/starts the application
        public void Run() //Limit each method to a single responsibility
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Content\n" +
                    "2. View All Content\n" +
                    "3. View Content By Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //View All Content
                        DisplayAllContent();
                        break;
                    case "3":
                        //View Content By Title
                        DisplayContentByTitle();
                        break;
                    case "4":
                        //Update Existing Content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //Delete Existing Content
                        DeleteExistingContent();
                        break;
                    case "6":
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
        // Create new StreamingContent
        private void CreateNewContent()
        {
            Console.Clear();
            Developer newContent = new Developer(); //Made a Reference connection here to Repository and then hit CTRL + . to link.

            //Title
            Console.WriteLine("Enter the title for the content:");
            newContent.Title = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description for the content:");
            newContent.Description = Console.ReadLine();

            //Maturity Rating
            Console.WriteLine("Enter the rating for the content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //Star Rating
            Console.WriteLine("Enter the star count for the content (5.8, 10, 1.5, etc):");
            string starsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starsAsString);

            //IsFamilyFriendly
            Console.WriteLine("Is this content family friendly?");
            string familyFriendlyString = Console.ReadLine().ToLower();

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }

            //GenreType
            Console.WriteLine("Enter the genre number:\n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Bromance\n" +
                "6. Drama\n" +
                "7. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt; //This is Casting. Moving from string to int and casting as a specific number from the enum function.

            _contentRepo.AddContentToList(newContent);

            /*
                 Horror = 1,
                 RomCom,
                 SciFi,
                 Documentary,
                 Bromance,
                 Drama,
                 Action
             */
        }

        // View Current StreamingContent that is saved
        private void DisplayAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _contentRepo.GetContentList();

            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title},\n" +
                    $" Desc: {content.Description}");
            }
        }

        // View existing content by Title
        private void DisplayContentByTitle()
        {
            Console.Clear();
            //Prompt the user to give a title
            Console.WriteLine("Enter the title of the content you'd like to see:");

            //Get User's input
            string title = Console.ReadLine();

            //Find the content by that title
            StreamingContent content = _contentRepo.GetContentByTitle(title);

            //Display that content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Title: {content.Title},\n" +
                    $"Description: {content.Description}\n" +
                    $"Maturity Rating: {content.MaturityRating}\n" +
                    $"Stars: {content.StarRating}\n" +
                    $"Is Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Genre: {content.TypeOfGenre}");
            }
            else
            {
                Console.WriteLine("No content by that title.");
            }
        }

        // Update Existing Content
        private void UpdateExistingContent()
        {
            Console.Clear();

            //Display all Content
            DisplayAllContent();

            //Ask for the title of the content to update
            Console.WriteLine("\nEnter the title of the content you'd like to update:");

            //Get that title
            string oldTitle = Console.ReadLine();

            //Build a new object
            //Copied code from Create New Object and edited
            StreamingContent newContent = new StreamingContent(); //Made a Reference connection here to Repository and then hit CTRL + . to link.

            //Title
            Console.WriteLine("Enter the title for the content:");
            newContent.Title = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description for the content:");
            newContent.Description = Console.ReadLine();

            //Maturity Rating
            Console.WriteLine("Enter the rating for the content (G, PG, PG-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //Star Rating
            Console.WriteLine("Enter the star count for the content (5.8, 10, 1.5, etc):");
            string starsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starsAsString);

            //IsFamilyFriendly
            Console.WriteLine("Is this content family friendly?");
            string familyFriendlyString = Console.ReadLine().ToLower();

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }

            //GenreType
            Console.WriteLine("Enter the genre number:\n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Bromance\n" +
                "6. Drama\n" +
                "7. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt; //This is Casting. Moving from string to int and casting as a specific number from the enum function.

            //Verify update worked
            bool updateWorked = _contentRepo.UpdateExistingContent(oldTitle, newContent); //ONLY THING CHANGED FOR UPDATES!!!

            if (updateWorked)
            {
                Console.WriteLine("Content succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }

        }

        // Delete Existing Content
        private void DeleteExistingContent()
        {
            DisplayAllContent();

            //Get the Title they want to delete
            Console.WriteLine("\nEnter the title of the content you'd like to remove");

            string input = Console.ReadLine();

            //Call the Delete Method
            bool wasDeleted = _contentRepo.RemoveContentFromList(input);

            //If the content was deleted, say so.
            //Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The Content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }


        }

        //Seed Method
        private void SeedContentList()
        {
            StreamingContent sharknado = new StreamingContent("Sharknado", "Tornados, but with sharks.", "TV-14", 3.3, true, GenreType.Action);
            StreamingContent theRoom = new StreamingContent("The Room", "Banker's life gets turned upside down.", "R", 5.8, false, GenreType.Drama);
            StreamingContent rubber = new StreamingContent("Rubber", "Car tire comes to life and goes on a killing spree.", "R", 5.8, false, GenreType.Documentary);

            _contentRepo.AddContentToList(sharknado);
            _contentRepo.AddContentToList(theRoom);
            _contentRepo.AddContentToList(rubber);

        }
    }
}
