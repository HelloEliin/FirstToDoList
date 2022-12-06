using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace ToDoList
{
    public class CreateToDoList
    {


        public string ListTitle { get; set; }
        public List<Task> Task { get; set; }

        public static void CreateNewToDoList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\nENTER NAME OF LIST\n");
            var listName = Console.ReadLine().ToUpper();
            if (String.IsNullOrEmpty(listName))
            {
                Console.WriteLine("You have to put a name on your list.");
                return;
            }

            var newList = new CreateToDoList()
            {
                ListTitle = listName,
                Task = new List<Task>()

            };

            json.Add(newList);
            CreateToDoListFile.UpDate(json);

            return;
        }


        public static void ViewAllList()
        {
            var json = CreateToDoListFile.GetJson();
            Validation.IsThereAnyLists();
            int index = -1;
            Console.WriteLine("\n\n\nALL OF YOUR LISTS\n");
            foreach (var title in json)
            {
                index++;
                Console.WriteLine("[" + index +"] " + title.ListTitle + "\n");
            }
            return;

        }


        public static void DeleteList()
        {

            var json = CreateToDoListFile.GetJson();
            int num = 0;

            Console.WriteLine("\n\n\nSELECT LIST TO DELETE \n");
            EveryListTitleInJson();
            var choosenList = Console.ReadLine();
            
            bool valid = int.TryParse(choosenList, out num);    
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool listExists = Validation.IsThereValidList(num);
            if (!listExists)
            {
                return;
            }

            Console.WriteLine("\nDo you want to delete this list? y/n");
            string yesOrNo = Console.ReadLine().ToLower();
            if (yesOrNo == "y")
            {
                Console.WriteLine("LIST DELETED.");
                json.RemoveAt(num);
                CreateToDoListFile.UpDate(json);
            }
            else if (yesOrNo == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Only 'y' or 'n'.");
            }

            return;

        }


        public static void ChangeListName()
        {
            var json = CreateToDoListFile.GetJson();
            int num = 0;

            Console.WriteLine("\n\n\nSELECT LIST TO RENAME \n");
            EveryListTitleInJson();

            var choosenList = Console.ReadLine();
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }
            bool validOrNot = Validation.IsThereValidList(num);

            if (!validOrNot)
            {
                return;
            }

            Console.WriteLine("ENTER NEW LISTNAME OR PRESS 'Q' TO QUIT.");
            string newListName = Console.ReadLine().ToUpper();
   
            if (String.IsNullOrEmpty(newListName))
            {
                Console.WriteLine("You have to put a name on your list.");
                return;
            }
            if(newListName == "Q")
            {
                return;
            }

            json[num].ListTitle = newListName;
            CreateToDoListFile.UpDate(json);
            return;
        }



        public static void ViewOneList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nSELECT LIST TO VIEW\n");
            EveryListTitleInJson();
            var choosenList = Console.ReadLine();
            int num = 0;
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }
            bool validOrNot = Validation.IsThereValidList(num);
            if (!validOrNot)
            {
                return;
            
            }
            Console.WriteLine(json[num].ListTitle);
            Validation.IsThereAnyTasks(num);
            AddNewTask.EveryTaskInList(num);


        }


        public static void RecentList()
        {
            var json = CreateToDoListFile.GetJson();

            Validation.IsThereAnyLists();
            json.Reverse();

            Console.WriteLine("\n\n\n" + json[0].ListTitle);

            if (json[0].Task.Count == 0)
            {
                Console.WriteLine("Ooops.. empty! No to-do's here!");
            }

            foreach (var task in json[0].Task)
            {
               
                if (task.Completed == true)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (task.Completed == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine(task.TaskTitle);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return;

        }


        public static void EveryListTitleInJson()
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;
            foreach (var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\nPress: " + "[" + index + "]" + "\n");
            }
        }











    }
}