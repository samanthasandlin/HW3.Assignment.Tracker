using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // declare an empty courses array
        string[] courses = new string[0];
        // declare an empty list assignments
        List<string> assignments = new List<string>();
        // declare an empty dictionary assignmentDetails
        Dictionary<string, string> assignmentDetails = new Dictionary<string, string>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nASSIGNMENT TRACKER");
            Console.WriteLine("1. Create Course (Array)");
            Console.WriteLine("2. Update Course (Array)");
            Console.WriteLine("3. Add Assignment (List)");
            Console.WriteLine("4. Update Assignment (List)");
            Console.WriteLine("5. Remove Assignment by Index (List)");
            Console.WriteLine("6. Add or Update Assignment Details (Dictionary)");
            Console.WriteLine("7. Remove Assignment by Name (for both List && Dictionary)");
            Console.WriteLine("8. Exit ");
            Console.WriteLine("Please choose:");

            string inputChoice = Console.ReadLine();
            int choice = 0;
            if (!int.TryParse(inputChoice, out choice))
            {
                choice = 0; 
            }

            if (choice == 1)
            {
                // option 1:
                Console.WriteLine("How many courses you are taking?");
                int numberOfCourses = Convert.ToInt16(Console.ReadLine());
                courses = new string[numberOfCourses];

                for (int i = 0; i < courses.Length; i++)
                {
                    Console.Write($"Course {i}: ");
                    courses[i] = Console.ReadLine();
                }

                Console.WriteLine("\nCurrent Course Array:");
                for (int i = 0; i < courses.Length; i++)
                {
                    Console.WriteLine($"Course {i}: {courses[i]}");
                }
            }
            else if (choice == 2)
            {
                // option 2: 
                if (courses.Length == 0)
                {
                    Console.WriteLine("The course array has not been created. Please use Option 1 first.");
                }
                else
                {
                    Console.WriteLine("\nCurrent Course Array:");
                    for (int i = 0; i < courses.Length; i++)
                    {
                        Console.WriteLine($"Course {i}: {courses[i]}");
                    }

                    Console.WriteLine("Please enter the course index to update:");
                    int courseIndex = Convert.ToInt16(Console.ReadLine());

                    if (courseIndex >= 0 && courseIndex < courses.Length)
                    {
                        Console.WriteLine("Please enter the new course name:");
                        courses[courseIndex] = Console.ReadLine();

                        Console.WriteLine("\nUpdated Course Array:");
                        for (int i = 0; i < courses.Length; i++)
                        {
                            Console.WriteLine($"Course {i}: {courses[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid course index.");
                    }
                }
            }
            else if (choice == 3)
            {
                // option 3:
                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                string enterMore = "y";
                while (enterMore == "y")
                {
                    Console.WriteLine("Please enter an assignment name:");
                    string name = Console.ReadLine();
                    assignments.Add(name);

                    Console.WriteLine("Do you want to add another assignment? (y/n):");
                    enterMore = Console.ReadLine().ToLower();
                }

                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }
            }
            else if (choice == 4)
            {
                // option 4: 
                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                Console.WriteLine("Please enter the assignment index to update:");
                int updateIndex = Convert.ToInt16(Console.ReadLine());

                if (updateIndex >= 0 && updateIndex < assignments.Count)
                {
                    string oldName = assignments[updateIndex];
                    Console.WriteLine("Please enter the new assignment name:");
                    string newName = Console.ReadLine();
                    assignments[updateIndex] = newName;

                    // Migrate dictionary entry if old assignment name is a key
                    if (assignmentDetails.ContainsKey(oldName))
                    {
                        string details = assignmentDetails[oldName];
                        assignmentDetails.Remove(oldName);
                        assignmentDetails[newName] = details;
                    }

                    Console.WriteLine("\nUpdated assignment list:");
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid assignment index.");
                }
            }
            else if (choice == 5)
            {
                // option 5: 
                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                Console.WriteLine("Please enter the assignment index to remove:");
                int removeIndex = Convert.ToInt16(Console.ReadLine());

                if (removeIndex >= 0 && removeIndex < assignments.Count)
                {
                    assignments.RemoveAt(removeIndex);

                    Console.WriteLine("\nUpdated assignment list:");
                    if (assignments.Count == 0)
                    {
                        Console.WriteLine("No assignment found.");
                    }
                    else
                    {
                        for (int i = 0; i < assignments.Count; i++)
                        {
                            Console.WriteLine($"{i}: {assignments[i]}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid assignment index.");
                }
            }
            else if (choice == 6)
            {
                // option 6:
                Console.WriteLine("Current Dictionay:");
                foreach (KeyValuePair<string, string> item in assignmentDetails)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                Console.WriteLine("Please enter assignment name (key):");
                string assignmentName = Console.ReadLine();
                Console.WriteLine("Please enter assignment description:");
                string description = Console.ReadLine();
                Console.WriteLine("Please enter assignment status:");
                string status = Console.ReadLine();

                string assignmentValue = description + " - " + status;
                assignmentDetails[assignmentName] = assignmentValue;

                Console.WriteLine("The Updated Dictionay:");
                foreach (KeyValuePair<string, string> item in assignmentDetails)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else if (choice == 7)
            {
                // option 7: 
                Console.WriteLine("\nCurrent assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                Console.WriteLine("Please enter assignment name to remove:");
                string nameToRemove = Console.ReadLine();

                if (assignments.Remove(nameToRemove))
                {
                    Console.WriteLine("Assignment removed from list.");
                }
                else
                {
                    Console.WriteLine("Assignment was not found.");
                }

                Console.WriteLine("\nUpdated assignment list:");
                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignment found.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i}: {assignments[i]}");
                    }
                }

                Console.WriteLine("Do you also want to remove a Dictionary entry? (y/n):");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("Please enter the Dictionary key to remove:");
                    string dictKey = Console.ReadLine();

                    if (assignmentDetails.Remove(dictKey))
                    {
                        Console.WriteLine("Dictionary entry removed.");
                    }
                    else
                    {
                        Console.WriteLine("Dictionary key not found.");
                    }

                    Console.WriteLine("The Updated Dictionay:");
                    foreach (KeyValuePair<string, string> item in assignmentDetails)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                }
            }
            else if (choice == 8)
            {
                // option 8: 
                Console.WriteLine("Good Work!");
                running = false;
            }
            else
            {
                // invalid choice message
                Console.WriteLine("Invalid choice. Please choose between 1-8.");
            }
        }
    }
}