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

            Console.WriteLine("Name of list: ");
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

            if (json?.Any() != true)
            {
                Console.WriteLine("You have no lists.");
                return;
            }

            Console.WriteLine("\n\nALL OF YOUR LISTS\n");
            foreach (var title in json)
            {
                Console.WriteLine(title.ListTitle);
                
            }

            return;

        }


        public static void DeleteList()
        {
            var json = CreateToDoListFile.GetJson();
            int deleteKey;
            int index = -1;



            if (json?.Any() != true)
            {
                Console.WriteLine("You have no lists to delete.");
                return;
            }

            Console.WriteLine("\n SELECT LIST TO DELETE \n");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\nPress: " + index + "\n");
    
            }
            
            
            deleteKey = Convert.ToInt32(Console.ReadLine());


                if (deleteKey > json.Count || deleteKey < 0)
            {
                Console.WriteLine("That list dont exist.");
                return;
            }

  
            Console.WriteLine("\nDo you want to delete this list? y/n");
            string yesOrNo = Console.ReadLine();
            if(yesOrNo == "y")
            {
                json.RemoveAt(deleteKey);
                CreateToDoListFile.UpDate(json);
            }

            return;


        }


        public static void ChangeListName()
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;

            if (json?.Any() != true)
            {
                Console.WriteLine("You have no lists.");
                return;
            }

            Console.WriteLine("\n SELECT LIST TO RENAME \n");
            foreach(var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\nPress: " + index + "\n");
            }
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
            int index = -1;

            if (json?.Any() != true)
            {
                Console.WriteLine("You have no lists.");
                return;
            }

            Console.WriteLine("\n SELECT LIST TO VIEW \n");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine("   LISTNAME   \n" + title.ListTitle + "\nPress: " + index + "\n");

            }

            int choosenList = Convert.ToInt32(Console.ReadLine());
            int order = -1;
            Console.WriteLine(json[choosenList].ListTitle);

                foreach (var task in json[choosenList].Task)
                {

                if (task.Completed == true)
                {
                   
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if(task.Completed == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                order++;
                Console.WriteLine(order + "  " + task.TaskTitle);
                Console.ForegroundColor = ConsoleColor.White;
                }    


        }


        public static void RecentList()
        {
            var json = CreateToDoListFile.GetJson();
            int order = -1;
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

                order++;
                Console.WriteLine(order + "  " + task.TaskTitle);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }











    }
}