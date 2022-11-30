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


        do { 

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[O]pen recent list\n" +
                    "[V]iew all lists\n" +
                    "[C]reate new list\n" +
                    "[D]elete list\n" +
                    "[Q]uit");


                menuChoice = Console.ReadLine();


                switch (menuChoice)
                {
                    case "O":
                    case "o":
                        // Open recent list
                        break;

                   case "V":
                   case "v": CreateToDoList.ViewAllList();
                        break;
                    
                    
                   case "C":
                   case "c": CreateToDoList.CreateNewToDoList();
                        break;


                   case "D":
                   case "d": CreateToDoList.DeleteList();
                        break;

                    case "Q":
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