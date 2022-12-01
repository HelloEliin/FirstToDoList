using System.Security.Cryptography.X509Certificates;

namespace ToDoList
{

    internal partial class Program
    {

        static void Main(string[] args)
        {
            



          var json = new CreateToDoListFile();
          json.CreateFile();
          string menuChoice;
          bool isRunning = true;
            string menuTwo;


        do { 

                Console.WriteLine("\nWhat do you want to do?\n");
                Console.WriteLine("" +
                    "[O]pen recent list\n" +
                    "[V]iew all lists\n" +
                    "[C]reate new list\n" +
                    "[D]elete list\n" +
                    "[Q]uit");


                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    
                    case "o":
                        // Open recent list
                        break;

                   case "v": CreateToDoList.ViewAllList();
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("" +
                                   "[V]iew list\n" +
                                   "[R]eturn to menu\n" +
                                   "[C]hange list-name\n" +
                                   "[A]dd task\n" +
                                   "[M]ark task as complete\n" +
                                   "[E]dit task\n" + 
                                   "[D]elete task");

                        menuTwo = Console.ReadLine().ToLower();

                        switch (menuTwo)
                        {
                            case "r":
                                break;
                            case "v":
                                CreateToDoList.ViewOneList();
                                break;

                            case "c":
                                CreateToDoList.ChangeListName();
                                break;
                            case "a":
                                AddNewTask.AddTask();
                                break;
                            case "m":
                                AddNewTask.isCompleted();
                                break;
                            case "e":
                                AddNewTask.ChangeTaskName();
                                break;
                            case "d":
                                // Delete task
                                break;
                            default:
                                Console.WriteLine("Try again.");
                                break;
                        }

                        break;
                    
                   case "c": CreateToDoList.CreateNewToDoList();
                        break;

                   case "d": CreateToDoList.DeleteList();
                        break;

                    case "q":
                        Console.WriteLine("Do you want to quit? y/n");
                        string yesOrNo = Console.ReadLine();

                            if (yesOrNo == "y")
                            {
                                isRunning = false;
                            }

                        break;
                        

                    default:
                        Console.WriteLine("Try again.");
                        
                        break;
                }



            } while (isRunning);






        }
    }
}