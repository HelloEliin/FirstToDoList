namespace ToDoList
{
    public class Menu
    {

        public static void StartMenu()
        {
            Console.WriteLine("\n\nMY TO DO LISTS \n\n" +
            "[O]pen recent list\n" +
            "[V]iew all lists\n" +
            "[C]reate new list\n" +
            "[D]elete list\n" +
            "[Q]uit");
        }



        public static void ListMenu()
        {
            Console.WriteLine("\n\n LISTMENU \n" +
           "[V]iew list\n" +
           "[B]ack to startmenu\n" +
           "[R]ename list\n" +
           "[A]dd task\n" +
           "[M]ark task as complete\n" +
           "[E]dit task\n" +
           "[D]elete task");
        }


        public static void ListMenuChoices(string choice)
        {
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
                case "e":
                    AddNewTask.ChangeTaskName();
                    break;
                case "d":
                    AddNewTask.DeleteTask();
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }


    }

}