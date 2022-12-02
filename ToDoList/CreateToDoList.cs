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

            Console.WriteLine("ENTER NAME OF LIST");
            var listname = Console.ReadLine();

            if (String.IsNullOrEmpty(listname))
            {
                Console.WriteLine("You have to put a name on your list.");
                CreateNewToDoList();
                
            }

            var newList = new CreateToDoList()
            {
                ListTitle = listname,
                Task = new List<Task>()

            };

         
            json.Add(newList);
            CreateToDoListFile.UpDate(json); 

            return;
      
        }


        public static void ViewAllList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\nALL OF YOUR LISTS\n");
            EveryListTitleInJson();
            return;

        }


        public static void DeleteList()
        {

            var json = CreateToDoListFile.GetJson();
            int num = 0;

            Console.WriteLine("\n SELECT LIST TO DELETE \n");
            EveryListTitleInJson();
            string choosenList = Console.ReadLine();
            bool isValid = Validation.IsThereValidNumber(choosenList);

            if (isValid == false)
            {
                return;
            }

            Console.WriteLine("\nDo you want to delete this list? y/n");
            string yesOrNo = Console.ReadLine();
            if(yesOrNo == "y")
            {
                json.RemoveAt(num);
                CreateToDoListFile.UpDate(json);
            }
            else if(yesOrNo == "n")
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
            int index = -1;

            Console.WriteLine("\n SELECT LIST TO RENAME \n");

            EveryListTitleInJson();

            int listToChange = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new list name:");
            string newListName = Console.ReadLine();
            json[listToChange].ListTitle = newListName;
            CreateToDoListFile.UpDate(json);
            return;
        }



        public static void ViewOneList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\nSELECT LIST TO VIEW \n");
            EveryListTitleInJson();

            string choosenList = Console.ReadLine();
            bool isValid = Validation.IsThereValidNumber(choosenList);

            if(isValid == false)
            {
                return;
            }

            int num = Convert.ToInt32(choosenList);

            Console.WriteLine(json[num].ListTitle);

            foreach (var task in json[num].Task)
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


        }


        public static void RecentList()
        {
            var json = CreateToDoListFile.GetJson();
            json.Reverse();
            Console.WriteLine("\n\n\n" + json[0].ListTitle);

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
                Console.WriteLine(title.ListTitle + "\nPress: " + index + "\n");
            }
        }











    }
}