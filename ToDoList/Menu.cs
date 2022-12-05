namespace ToDoList
{
    public class Menu
    {

        public static void StartMenu()
        {
            Console.WriteLine("\n\nMY TO DO LISTS \n\n" +
            "[O]pen recent list\n" +
            "[V]iew lists and listmenu\n" +
            "[C]reate new list\n" +
            "[D]elete list\n" +
            "[Q]uit");
        }





        public static void ListMenu()
        {

            Console.WriteLine("\n\n\nLISTMENU\n" +
     "[V]iew lists\n" +
     "[B]ack to startmenu\n" +
     "[R]ename list\n" +
     "[A]dd task\n" +
     "[M]ark task as complete\n" +
     "[T]o do menu\n" +
     "[D]elete task");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "b":
                    break;
                case "v":
                    CreateToDoList.ViewOneList();
                    break;

                case "r":
                    CreateToDoList.ChangeListName();
                    break;
                case "a":
                    AddNewTask.AddTask();
                    break;
                case "m":
                    AddNewTask.isCompleted();
                    break;
                case "t":
                    TaskMenu();
                    break;
                case "d":
                    AddNewTask.DeleteTask();
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }



        public static void TaskMenu()
        {
            Console.WriteLine("\n\n\nTO-DO MENU\n" +
           "[R]ename to-do\n" +
           "[D]elete to-to\n" +
           "[B]ack to list menu\n");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "r":
                    AddNewTask.ChangeTaskName();
                    break;
                case "d":
                    AddNewTask.DeleteTask();
                    break;
                case "b":
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }

        }


    }

}