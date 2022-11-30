using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
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

            //console.writeline("what task to add?");
            //string tasktitle = console.readline();

            //var tasks = new list<task>();
            //tasks.add(new tasks { tasktitle = tasktitle, completed = false });

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
            }

            foreach (var title in json)
            {
                Console.WriteLine("All your lists:\n" + title.ListTitle +"\n");
                
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
            }

            Console.WriteLine("Which list to delete?\n");

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

  
            Console.WriteLine("Do you want to delete this list? y/n");
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

            Console.WriteLine("Which list do you want to change list-name on?");
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













    }
}