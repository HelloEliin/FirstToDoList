﻿namespace ToDoList
{
    public class Menu
    {

        public static void StartMenu()
        {
            Console.WriteLine("\n\n\n\n[MY DO-DO LISTS]\n\n" +
            "[O]pen recent list\n" +
            "[V]iew lists and listmenu\n" +
            "[C]reate new list\n" +
            "[D]elete list\n" +
            "[Q]uit");
        }





        public static void ListMenu()
        {

            Console.WriteLine("\n\n\n\nLISTMENU\n" +
            "\n--- [1] LISTS TO BE COMPLETE WITHIN A WEEK\n" +
            "--- [2] ADD LISTS TO BE COMPLETE WITHIN A WEEK \n" +
            "--- [3] EXPIRED LISTS \n" +
            "--- [4] FINISHED LISTS \n\n" +
            "[V]iew lists\n" +
            "[B]ack to startmenu\n" +
            "[R]ename list\n" +
            "[A]dd to-do\n" +
            "[M]ark task as complete\n" +
            "[T]o do menu\n" +
            "[D]elete to-do\n" +
            "[S]ort lists");

            string choice = Console.ReadLine().ToLower();

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
                case "s":
                    CreateToDoList.SortLists();
                    break;
                case "1":
                    CreateToDoList.ShowWeeklyLists();
                    break;
                case "2":
                    CreateToDoList.AddListToCompleteInAWeek();
                    break;
                case "3":
                    CreateToDoList.UnFinishedLists();
                    break;
                case "4":
                    CreateToDoList.FinishedLists();
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

            var choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "r":
                    AddNewTask.ChangeTaskName();
                    break;
                case "d":
                    AddNewTask.DeleteTask();
                    break;
                case "b": ListMenu();
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }

        }


    }

}